using Cz.Bkk.Generic.Common.Model.Response;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Cz.Bkk.Generic.Common.Message
{
    /// <summary>
    /// This class is used for enveloping the messages
    /// </summary>
    public class Invocation
    {
        /// <summary>
        /// Sync version
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public static Message<TReturn> InvokeMessage<TReturn>(Func<TReturn> method)
        {
            var result = new Message<TReturn>();

            try
            {
                result.Response = method();
            }
            catch (Exception ex)
            {
                SetErrorState(ref result, ex);
            }

            return result;
        }

        /// <summary>
        /// Async version
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="method"></param>
        /// <returns></returns>
        public static async Task<Message<TReturn>> InvokeAsyncMessage<TReturn>(Func<Task<TReturn>> method)
        {
            var result = new Message<TReturn>();

            try
            {
                // Create async function
                Func<Task<TReturn>> function = async () => await method();
                // Await it
                result.Response = await function();
            }
            catch (Exception ex)
            {
                SetErrorState(ref result, ex);
            }

            return result;
        }

        /// <summary>
        /// Setting the correct error state with a message from exception
        /// </summary>
        /// <typeparam name="TReturn"></typeparam>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        private static void SetErrorState<TReturn>(ref Message<TReturn> message, Exception ex)
        {
            message.State = MessageState.ERROR;
            message.Text = ex?.Message;
        }
    }
}
