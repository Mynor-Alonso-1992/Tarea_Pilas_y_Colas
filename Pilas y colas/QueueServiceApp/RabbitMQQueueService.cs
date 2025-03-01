using RabbitMQ.Client;
using System;
using System.Text;

namespace QueueServiceApp
{
    public class RabbitMQQueueService : IQueueService
    {
        private readonly string _queueName = "mi_cola";
        private readonly ConnectionFactory _factory;

        
        public RabbitMQQueueService()
        {
            _factory = new ConnectionFactory() { HostName = "localhost" };

        }

        public void Enqueue(string message)
        {
            using (var connection = _factory.CreateConnection())
               using (var channel = connection.CreateModel())
         {
                channel.QueueDeclare(queue: _queueName,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($" [x] Sent '{message}'");
            }
        }

        public string? Dequeue()
        {
            using (var connection = _factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                var result = channel.BasicGet(queue: _queueName, autoAck: true);
                if (result == null)
                {
                    return null;
                }

                return Encoding.UTF8.GetString(result.Body.ToArray());
            }
        }
    }
}
