using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChatProject
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IChatService" in both code and config file together.
    [ServiceContract]
    public interface IChatService
    {

        [OperationContract]
        void Send(Message message);

    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Message
    {
        private string _message;
        private string _user;

        [DataMember]
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }

        [DataMember]
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
