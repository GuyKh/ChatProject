using System;
using System.ServiceModel;
using ChatClient.ServiceReference1;

namespace ChatClient
{
    class Client
    {
        public delegate void MyEventCallbackHandler(string Text, string Username);
        public static event MyEventCallbackHandler MyEventCallbackEvent;
        private string _username;
        delegate void SafeThreadCheck(string text);

        [CallbackBehavior(UseSynchronizationContext = false)]
        public class ServiceCallback : IChatServiceCallback
        {

            public void MessagePosted(string username, string Message)
            {
                MyEventCallbackEvent(username, Message);
            }
        }

        private ChatServiceClient client;

        public Client(string username)
        {
            _username = username;
            InstanceContext context = new InstanceContext(new ServiceCallback());
            client = new ChatServiceClient(context);

            MyEventCallbackHandler callbackHandler = new MyEventCallbackHandler(WriteMessage);
            MyEventCallbackEvent += callbackHandler;

            client.Subscribe();
        }

        public void Post(string message)
        {
            client.PublishMessage(_username, message);
        }

        public void WriteMessage(string Username, string Text)
        {
            Console.WriteLine("[{0}]: {1}", Username, Text);
        }
    }
}
