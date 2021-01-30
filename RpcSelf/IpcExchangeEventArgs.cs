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

namespace RpcSelf
{
    /// <summary>
    /// Event arguments for the <see cref="RpcSelfHost{T}.MessageReceived"/> event.
    /// Implements the <see cref="System.EventArgs" />
    /// </summary>
    /// <typeparam name="T">The type of object to transmit data with.</typeparam>
    /// <seealso cref="System.EventArgs" />
    public class IpcExchangeEventArgs<T>: EventArgs where T: class
    {
        /// <summary>
        /// Gets or sets the data object.
        /// </summary>
        /// <value>The data object.</value>
        public T Object { get; set; }
    }
}
