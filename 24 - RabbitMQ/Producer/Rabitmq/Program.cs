using RabbitMQ.Client;
using System;
using System.Text;

namespace Rabitmq
{
    class Program
    {
        static void Main(string[] args)
        {
            Headersmessages headersmessages = new Headersmessages();

            headersmessages.SendMessage();

            Console.ReadLine();
        }
    }
}
