using System;
using System.ServiceModel;

namespace ServerChatService
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ChatService : IChatService
    {
        public delegate void MessagePostEventHandler(object sender, ServiceEventArgs e);
        public static event MessagePostEventHandler MessagePostedEvent;

        IChatContract ServiceCallback = null;
        MessagePostEventHandler MessageHandler = null;

        public void Subscribe()
        {
            ServiceCallback = OperationContext.Current.GetCallbackChannel<IChatContract>();
            MessageHandler = new MessagePostEventHandler(MessagePostedHandler);
            MessagePostedEvent += MessageHandler;

            PublishMessage("ADMIN", "Someone joined");
        }


        public void Unsubscribe()
        {
            MessagePostedEvent -= MessageHandler;
        }

        public void PublishMessage(string username, string text)
        {
            ServiceEventArgs se = new ServiceEventArgs();
            se.Message = text;
            se.Username = username;
            MessagePostedEvent(this, se);
        }

        public void MessagePostedHandler(object sender, ServiceEventArgs se)
        {
            ServiceCallback.MessagePosted(se.Username, se.Message);

        }
    }

    public class ServiceEventArgs : EventArgs
    {
        public string Username;
        public string Message;
    }
}
