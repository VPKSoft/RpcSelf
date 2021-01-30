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
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RpcSelf
{
    /// <summary>
    /// A class to send TCP data containing objects of type of <typeparamref name="T"/> serialized to JSON.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RpcSelfClient<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RpcSelfClient{T}"/> class.
        /// </summary>
        /// <param name="port">The port to use for TCP communication.</param>
        public RpcSelfClient(int port): this(IPAddress.Loopback.ToString(), port)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RpcSelfClient{T}"/> class.
        /// </summary>
        /// <param name="hostName">The host name for the <see cref="TcpClient"/> to connect to.</param>
        /// <param name="port">The port to use for TCP communication.</param>
        public RpcSelfClient(string hostName, int port)
        {
            Port = port;
            HostName = hostName;
        }

        /// <summary>
        /// Gets or sets the port to use with the TCP communication.
        /// </summary>
        /// <value>The port to use with the TCP communication.</value>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the host name to use with the TCP communication.
        /// </summary>
        /// <value>The host name to use with the TCP communication.</value>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="TcpClient"/> client instance to use with the TCP communication.
        /// </summary>
        /// <value>The <see cref="TcpClient"/> client instance to use with the TCP communication.</value>
        internal TcpClient Client { get; set; }

        /// <summary>
        /// Sends the specified data object to the TCP server as a JSON string.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <param name="exception">An exception object in case one occurs within the method.</param>
        /// <returns><c>true</c> if the <paramref name="data"/> was sent successfully, <c>false</c> otherwise.</returns>
        public bool SendData(T data, out Exception exception)
        {
            exception = null;
            try
            {
                using (Client = new TcpClient(HostName, Port))
                {
                    using var clientStream = Client.GetStream();
                    var sendBytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data));
                    clientStream.Write(sendBytes, 0, sendBytes.Length);
                    return true;
                }
            }
            catch (Exception e)
            {
                exception = e;
                return false;
            }
        }

        /// <summary>
        /// An event which is occurs when data should be encrypted via an external algorithm.
        /// </summary>
        public EventHandler<RequestDataEncryptionEventArgs> RequestDataEncryption;

        /// <summary>
        /// Encrypts the specified data bytes via the <see cref="RequestDataEncryption"/> event if subscribed.
        /// </summary>
        /// <param name="dataBytes">The data bytes to encrypt.</param>
        /// <returns>A System.Byte[] array containing the encrypt bytes.</returns>
        private byte[] Encrypt(byte[] dataBytes)
        {
            var args = new RequestDataEncryptionEventArgs {Data = dataBytes};
            RequestDataEncryption?.Invoke(this, args);
            return args.Data;
        }

        /// <summary>
        /// Sends the specified data object to the TCP server as a JSON string asynchronously.
        /// </summary>
        /// <returns><c>true</c> if the <paramref name="data"/> was sent successfully, <c>false</c> otherwise.</returns>
        public async Task<bool> SendDataAsync(T data)
        {
            return (await SendDataExAsync(data)).Key;
        }

        /// <summary>
        /// Sends the specified data object to the TCP server as a JSON string asynchronously.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns>A KeyValuePair&lt;System.Boolean, Exception&gt; containing the information if the data was sent successfully and an exception in case the operation was unsuccessful.</returns>
        public async Task<KeyValuePair<bool, Exception>> SendDataExAsync(T data)
        {
            try
            {
                using (Client = new TcpClient(HostName, Port))
                {
                    using var clientStream = Client.GetStream();
                    var sendBytes = Encrypt(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(data)));
                    await clientStream.WriteAsync(sendBytes, 0, sendBytes.Length);
                    return new KeyValuePair<bool, Exception>(true, null);
                }
            }
            catch (Exception e)
            {
                return new KeyValuePair<bool, Exception>(false, e);
            }
        }

        /// <summary>
        /// Sends the specified data object to the TCP server as a JSON string.
        /// </summary>
        /// <param name="data">The data to send.</param>
        /// <returns><c>true</c> if the <paramref name="data"/> was sent successfully, <c>false</c> otherwise.</returns>
        public bool SendData(T data)
        {
            return SendData(data, out _);
        }
    }
}
