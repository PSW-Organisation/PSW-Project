using Newtonsoft.Json;
using PharmacyLibrary.Tendering.Model;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace PharmacyLibrary.Tendering.Service
{
    public class TenderResponsePublishRabbitMQService : ITenderResponsePublishService
    {
        public IConnection connection;
        public IModel channel;

        public TenderResponsePublishRabbitMQService()
        {
            initConnection("localhost");
        }
        public bool AnnounceResponse(TenderResponse tender)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(tender));
            channel.BasicPublish(
                exchange: "tenderResponses",
                routingKey: tender.PharmacyApiKey,
                basicProperties: null,
                body: body);
            return true;
        }

        public bool initConnection(string connectionName)
        {
            var factory = new ConnectionFactory() { HostName = connectionName };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "tenderResponses", ExchangeType.Topic);
            return true;
        }
    }
}
