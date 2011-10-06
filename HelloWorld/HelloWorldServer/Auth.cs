using log4net;
using NServiceBus;

namespace HelloWorldServer
{
    public class Auth : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }

        public void Handle(IMessage message)
        {
            if (!Authorized(message.GetHeader("user")))
            {
                LogManager.GetLogger("Auth").Warn("User not authorized.");
                Bus.DoNotContinueDispatchingCurrentMessageToHandlers();
            }
            else
                LogManager.GetLogger("Auth").Info("User authorized.");
        }

        private static bool Authorized(string user)
        {
            return user == "udi";
        }
    }
}
