using System;
using System.ServiceModel;
using ChatClient.ServiceReference1;

namespace ChatClient
{
    class Client
    {
        public delegate void MyEventCallbackHandler(string Text, string Username);
        public static event MyEventCallbackHandler MyEventCallbackEvent;

        delegate void SafeThreadCheck(string text);

        [CallbackBehavior(UseSynchronizationContext = false)]
        public class ServiceCallback : IChatServiceCallback
        {

            public void MessagePost(string username, string Message)
            {
                MyEventCallbackEvent(username, Message);
            }
        }


        public Client()
        {
            InstanceContext context = new InstanceContext(new ServiceCallback());
            ChatServiceClient client = new ChatServiceClient(context);

            MyEventCallbackHandler callbackHandler = new MyEventCallbackHandler(WriteMessage);
            MyEventCallbackEvent += callbackHandler;

            client.Subscribe();
        }

        public void WriteMessage(string Text, string Username)
        {
            Console.WriteLine("[{0}]: {1}", Username, Text);
        }
    }
}
