using Newtonsoft.Json;
using PharmacyLibrary.Model;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Service
{
    public class RabbitMQPublishService : IPublishService
    {

        public IConnection connection;
        public IModel channel;

        public RabbitMQPublishService()
        {
            initConnection();
        }
        public bool initConnection()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "medicineBenefit", ExchangeType.Topic);
            return true;
        }

        public bool SendMedicineBenefit(MedicineBenefit medicineBenefit)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(medicineBenefit));
            channel.BasicPublish(
                exchange: "medicineBenefit",
                routingKey: "Flos",
                basicProperties: null,
                body: body);
            return true;
         }
    }
}
