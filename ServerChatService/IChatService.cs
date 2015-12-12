using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServerChatService
{
    [ServiceContract(Namespace = "http://ServerChatService.Service",
    SessionMode = SessionMode.Required, CallbackContract = typeof(IChatService))]
    public interface IChatService
    {
        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Subscribe();

        [OperationContract(IsOneWay = false, IsInitiating = true)]
        void Unsubscribe();

        [OperationContract(IsOneWay = false)]
        void PublishMessage(string username, string text);
    }

    public interface IChatContract
    {
        [OperationContract(IsOneWay = true)]
        void MessagePosted(string username, string text);
    }
}
