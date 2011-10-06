using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Messages;
using NServiceBus;
using SecurityServiceAdapter;

namespace WebApplication1
{
    public class Global : System.Web.HttpApplication
    {
        public static IBus Bus { get; private set; }

        protected void Application_Start(object sender, EventArgs e)
        {
            Bus = NServiceBus.Configure.WithWeb()
                    .CustomConfigurationSource(new ConfigSource())
                    .Log4Net()
                    .DefaultBuilder()
                    .RijndaelEncryptionService()
                    .XmlSerializer("http://acme.com")
                    .MsmqTransport()
                    .UnicastBus()
                    .LoadMessageHandlers()
                    .CreateBus()
                    .Start();

            Bus.OutgoingHeaders["user"] = "udi";
            Bus.Send(new Action<Query>(q => q.NumberOfResponses = 10));
        }


        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            Bus.OutgoingHeaders["user"] = "udi";
        }


    }
}
