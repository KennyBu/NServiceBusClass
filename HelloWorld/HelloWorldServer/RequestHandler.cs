using log4net;
using Messages;
using NServiceBus;

namespace HelloWorldServer
{
    public class RequestHandler : IHandleMessages<Request>
    {
        private ISaySomething saysSomething;

        public RequestHandler(ISaySomething saySomething)
        {
            saysSomething = saySomething;
        }


        public void Handle(Request message)
        {
            LogManager.GetLogger("RequestHandler").Info(message.SaySomething.Value);
            LogManager.GetLogger("RequestHandler").Info(saysSomething.InResponseTo(
                message.SaySomething.Value));
        }
    }
}