using NServiceBus;

namespace PublisherEndpoint1
{
    public class Handler : IHandleMessages<T>
    {
        public IBus Bus { get; set; }

        #region IMessageHandler<T> Members

        public void Handle(T message)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
