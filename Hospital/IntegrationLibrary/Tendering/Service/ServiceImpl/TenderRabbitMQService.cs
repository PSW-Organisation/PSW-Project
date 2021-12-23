using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Service.ServiceInterfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationLibrary.Tendering.Service.ServiceImpl
{
    public class TenderRabbitMQService : ITenderPublishingService
    {
        public IConnection connection;
        public IModel channel;

        public TenderRabbitMQService()
        {
            initConnection("localhost", "tenders");
        }
      

        public bool AnnounceTender(Tender tender, string exchangeName)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tender));

            channel.BasicPublish(
                    exchange: exchangeName,
                    routingKey: "",
                     basicProperties: null,
                body: body);
            return true;
        }

        public bool initConnection(string connectionName, string exchangeName)
        {
            var factory = new ConnectionFactory() { HostName = connectionName };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: exchangeName, ExchangeType.Fanout);
            return true;
        }
    }
}
