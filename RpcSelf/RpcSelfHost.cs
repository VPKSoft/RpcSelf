#region License
/*
MIT License

Copyright(c) 2021 Petteri Kautonen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;

namespace RpcSelf
{
    /// <summary>
    /// A class to accept TCP data containing objects of type of <typeparamref name="T"/> deserialized as JSON via a client class.
    /// Implements the <see cref="System.IDisposable" />
    /// </summary>
    /// <typeparam name="T">The type of object to transmit data with.</typeparam>
    /// <seealso cref="System.IDisposable" />
    public class RpcSelfHost<T> : IDisposable where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RpcSelfHost{T}"/> class.
        /// </summary>
        /// <param name="port">The port to use for TCP communication.</param>
        public RpcSelfHost(int port): this(IPAddress.Loopback, port, false)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RpcSelfHost{T}"/> class.
        /// </summary>
        /// <param name="address">The address for the <see cref="TcpListener"/> class instance.</param>
        /// <param name="port">The port to use for TCP communication.</param>
        /// <param name="asyncThreadingContext">if set to <c>true</c> an asynchronous threading context is used to raise the <see cref="MessageReceived"/> event.</param>
        public RpcSelfHost(IPAddress address, int port, bool asyncThreadingContext)
        {
            AsyncThreadingContext = asyncThreadingContext;
            context = SynchronizationContext.Current ?? new SynchronizationContext();
            Server = new TcpListener(address, port);
            Server.Start();
            ServerListenerThread = new Thread(RpcListener);
            ServerListenerThread.Start();
        }

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="MessageReceived"/> event should be raised in an asynchronous threading context.
        /// </summary>
        /// <value><c>true</c> if the <see cref="MessageReceived"/> event should be raised in an asynchronous threading context; otherwise, <c>false</c>.</value>
        public bool AsyncThreadingContext { get; set; }

        readonly SynchronizationContext context;

        /// <summary>
        /// Gets or sets the server listener thread.
        /// </summary>
        /// <value>The server listener thread.</value>
        private Thread ServerListenerThread { get; }

        /// <summary>
        /// A value to indicate whether to stop the TPC listener thread.
        /// </summary>
        private volatile bool stopped;

        /// <summary>
        /// Gets the <see cref="TcpListener"/> instance acting as server.
        /// </summary>
        /// <value>The <see cref="TcpListener"/> instance acting as server.</value>
        private TcpListener Server { get; }

        /// <summary>
        /// Occurs when an object data was received via TCP protocol.
        /// </summary>
        public EventHandler<IpcExchangeEventArgs<T>> MessageReceived;

        /// <summary>
        /// The TCP listener thread function.
        /// </summary>
        internal void RpcListener()
        {
            try
            {
                while (!stopped)
                {
                    var tcpClientTask = Server.AcceptTcpClientAsync();
                    var result = tcpClientTask.Result;
                    if (result != null)
                    {
                        var stream = result.GetStream();

                        var eventObject = SerializeFromStream(stream);

                        if (AsyncThreadingContext)
                        {
                            context.Post(
                                delegate
                                {
                                    MessageReceived?.Invoke(this, new IpcExchangeEventArgs<T> {Object = eventObject});
                                }, null);
                        }
                        else
                        {
                            context.Send(
                                delegate
                                {
                                    MessageReceived?.Invoke(this, new IpcExchangeEventArgs<T> {Object = eventObject});
                                }, null);
                        }
                    }

                    Thread.Sleep(100);
                }
            }
            catch (ThreadInterruptedException)
            {
                // ignore the ThreadAbortException instance..
            }
        }

        /// <summary>
        /// Serializes and object from the specified stream containing JSON data of the object.
        /// </summary>
        /// <param name="stream">The stream to read the object JSON data from.</param>
        /// <returns>An instance of the <see cref="T"/> object.</returns>
        internal T SerializeFromStream(Stream stream)
        {
            var buffer = new byte[10000];
            using var objectStream = new MemoryStream();
            var bytesRead = stream.Read(buffer, 0, buffer.Length);

            while (bytesRead != 0)
            {
                objectStream.Write(buffer, 0, bytesRead);
                bytesRead = stream.Read(buffer, 0, buffer.Length);
            }

            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(Decrypt(objectStream.ToArray())));
        }

        /// <summary>
        /// Closes the TCP connection used by this instance.
        /// </summary>
        public void Close()
        {
            if (stopped)
            {
                return;
            }

            stopped = true;

            var safeJoin = false;
            for (int i = 0; i < 5000; i += 100)
            {
                if (ServerListenerThread.Join(100))
                {
                    safeJoin = true;
                    break;
                }
            }

            if (!safeJoin)
            {
                ServerListenerThread.Interrupt();
            }
        }

        /// <summary>
        /// An event which is occurs when data should be decrypted via an external algorithm.
        /// </summary>
        public EventHandler<RequestDataDecryptionEventArgs> RequestDataDecryption;

        /// <summary>
        /// Decrypts the specified data bytes via the <see cref="RequestDataDecryption"/> event if subscribed.
        /// </summary>
        /// <param name="dataBytes">The data bytes to decrypt.</param>
        /// <returns>A System.Byte[] array containing the decrypted bytes.</returns>
        private byte[] Decrypt(byte[] dataBytes)
        {
            var args = new RequestDataDecryptionEventArgs {Data = dataBytes};

            if (AsyncThreadingContext)
            {
                context.Post(
                    delegate
                    {
                        RequestDataDecryption?.Invoke(this, args);
                    }, null);
            }
            else
            {
                context.Send(
                    delegate
                    {
                        RequestDataDecryption?.Invoke(this, args);
                    }, null);
            }

            return args.Data;
        }

        #region Dispose
        /// <summary>
        /// A value indicating whether the <see cref="Dispose(bool)"/> has been called.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            // Check to see if Dispose has already been called.
            if(!disposed)
            {
                // Note disposing has been done.
                disposed = true;

                if (disposing)
                {
                    Close();
                }
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="RpcSelfHost{T}"/> class.
        /// </summary>
        ~RpcSelfHost()
        {
            Dispose(false);
        }
        #endregion
    }
}
