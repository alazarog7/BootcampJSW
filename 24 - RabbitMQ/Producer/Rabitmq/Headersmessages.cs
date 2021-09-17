using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rabitmq
{
    public class Headersmessages
    {
        private const string UName = "guest";
        private const string PWD = "guest";
        private const string HName = "localhost";

        public void SendMessage()
        {
            //Main entry point to the RabbitMQ .NET AMQP client
            var connectionFactory = new ConnectionFactory()
            {
                UserName = UName,
                Password = PWD,
                HostName = HName
            };

            var connection = connectionFactory.CreateConnection();
            var model = connection.CreateModel();
            var properties = model.CreateBasicProperties();
            properties.Persistent = false;
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            dictionary.Add("format", "excel");
            //dictionary.Add("format", "pdf");
            //dictionary.Add("format-2", "pdfx");
            properties.Headers = dictionary;
            byte[] messagebuffer = Encoding.Default.GetBytes("Send headers to Exchange 'format=pdf' ");
            model.BasicPublish("headers.exchange", "", properties, messagebuffer);
            Console.WriteLine("Message Sent From : headers.exchange ");
            Console.WriteLine("Routing Key : Does not need routing key");
            Console.WriteLine("Message Sent");

        }
    }
}
