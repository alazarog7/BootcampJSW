using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ApiGateway.Handlers
{
    public class RemoveEncodingDelegatingHandler: DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage requestMessage, CancellationToken cancellation)
        {
            requestMessage.Headers.AcceptEncoding.Clear();
            return await base.SendAsync(requestMessage, cancellation);
        }
    }
}
