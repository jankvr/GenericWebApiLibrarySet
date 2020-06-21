using System;
using System.Threading.Tasks;
using Cz.Bkk.Generic.Common.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Cz.Bkk.Generic.ProjectBase.MessageHandling
{
    /// <summary>
    /// Used for intercepting the message.
    /// </summary>
    public class MessageMiddleware
    {
        private readonly RequestDelegate request;

        /// <summary>
        /// Injected constructor
        /// </summary>
        /// <param name="request"></param>
        public MessageMiddleware(RequestDelegate request)
        {
            this.request = request;
        }

        /// <summary>
        /// Invoke method
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            await request.Invoke(context);
        }
    }
}
