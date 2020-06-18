namespace Cz.Bkk.Generic.Common.Model.Response
{
    /// <summary>
    /// Generic message used widely in WebApi project
    /// </summary>
    public class Message<T>
    {
        /// <summary>
        /// Final state
        /// </summary>
        public MessageState State { get; set; }
        /// <summary>
        /// If something is messed up, this will provide additional information
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Response
        /// </summary>
        public T Response { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Message()
        {
            State = MessageState.OK;
        }
    }
}
