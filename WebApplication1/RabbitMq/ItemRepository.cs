using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace WebApplication1.RabbitMq
{
    public class ItemRepository
    {
        public void Add(Item item)
        {
            const string exchange = "performance";
            const string queue = "items";
            const string routingKey = "new.item";

            var messageJson = JsonConvert.SerializeObject(item);
            var body = Encoding.UTF8.GetBytes(messageJson);

            using (var connection = Services.ConnectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    //channel.ExchangeDeclare(exchange: exchange, type: "direct");

                    //channel.QueueDeclare(queue, true, false, true);

                    //channel.QueueBind(queue, exchange, routingKey);

                    channel.BasicPublish(exchange, routingKey, basicProperties: null, body: body);
                }
            }
        }
    }

    public static class Services
    {
        public static ConnectionFactory ConnectionFactory
        {
            get
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "localhost",
                    Port = 5672,
                    UserName = "guest",
                    Password = "guest"
                };

                return factory;
            }
        }
    }
}
