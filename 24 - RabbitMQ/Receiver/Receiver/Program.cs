using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Receiver
{
    class Program
    {
        private const string UName = "guest";
        private const string Pwd = "guest";
        private const string HName = "localhost";

        static void Main(string[] args)
        {
            ConnectionFactory connectionFactory = new ConnectionFactory
            {
                HostName = HName,
                UserName = UName,
                Password = Pwd,
            };
            
            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            channel.BasicQos(0, 1, false);
            MessageReceiver messageReceiver = new MessageReceiver(channel);
            channel.BasicConsume("ReportPDF", false, messageReceiver);
            Console.ReadLine();

        }
    }
}
