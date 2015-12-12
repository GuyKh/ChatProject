using System;
using ServerChatService;
using System.ServiceModel;

namespace ChatServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (System.ServiceModel.ServiceHost host = new System.ServiceModel.ServiceHost(typeof(ChatService)))
            {
                host.Open();

                Console.WriteLine("Service up and running at:");
                foreach (var ea in host.Description.Endpoints)
                {
                    Console.WriteLine(ea.Address);
                }

                Console.WriteLine("Click Enter to Exit");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
