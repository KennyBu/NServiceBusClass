using Messages;
using NServiceBus;

namespace WebApplication1
{
    public class QueryResultMessageHandler :IHandleMessages<QueryResult>
    {
        public void Handle(QueryResult message)
        {
            var result = message.ToString();
        }
    }
}