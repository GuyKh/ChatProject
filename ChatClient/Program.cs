using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");

            Console.WriteLine("Enter your username");
            string username = Console.ReadLine();
            while (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Please enter a valid username");
                username = Console.ReadLine();
            }

            Client client = new Client(username);

            string _text = string.Format("[{0} has Joined]", username);
            do
            {
                client.Post(_text);

                _text = Console.ReadLine();
            } while (_text.ToLower() != "exit");

            client.Post(string.Format("[{0} left]", username));
            


        }
    }
}
