using IntegrationLibrary.Pharmacies.Model;
using IntegrationLibrary.Pharmacies.Repository.RepoInterfaces;
using IntegrationLibrary.Tendering.Model;
using IntegrationLibrary.Tendering.Repository.RepoInterfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationLibrary.Tendering.Service.ServiceImpl
{
    public class TenderResponseRabbitMqService : BackgroundService
    {
        private IConnection connection;
        private IModel channel;
        private readonly IServiceScopeFactory serviceScopeFactory;


        public TenderResponseRabbitMqService(IServiceScopeFactory scopeFactory)
        {
            this.serviceScopeFactory = scopeFactory;
            InitRabbitMQ();
        }
        public void InitRabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            connection = factory.CreateConnection();
            channel = connection.CreateModel();
            channel.ExchangeDeclare(exchange: "tenderResponses", ExchangeType.Topic);
            using (var scope = serviceScopeFactory.CreateScope())
            {

                var pharmacyRepository = scope.ServiceProvider.GetRequiredService<PharmacyRepository>();
                foreach (Pharmacy p in pharmacyRepository.GetAll())
                {

                    Console.WriteLine(p.PharmacyName);
                    channel.QueueDeclare(
                        queue: p.PharmacyComunicationInfo.PharmacyApiKey,
                        durable: false,
                                exclusive: false,
                                    autoDelete: false,
                                    arguments: null
                                    );
                    channel.QueueBind(
                               queue: p.PharmacyComunicationInfo.PharmacyApiKey,
                               exchange: "tenderResponses",
                               routingKey: p.PharmacyComunicationInfo.PharmacyApiKey //
                               );
                }

            }

        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            channel.Close();
            connection.Close();
            return base.StopAsync(cancellationToken);
        }

        public override Task StartAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var jsonMessage = Encoding.UTF8.GetString(body);
                TenderResponse dto = JsonConvert.DeserializeObject<TenderResponse>(jsonMessage);
                HandleMessage(dto);

                
                Console.WriteLine(jsonMessage);
                //channel.BasicAck(ea.DeliveryTag, false);
            };
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var pharmacyRepository = scope.ServiceProvider.GetRequiredService<PharmacyRepository>();
                foreach (Pharmacy p in pharmacyRepository.GetAll())
                {

                    channel.BasicConsume(
                               queue: p.PharmacyComunicationInfo.PharmacyApiKey,
                               autoAck: true,
                               consumer: consumer
                               );
                }
            }
            return base.StartAsync(stoppingToken);
        }
        private bool HandleMessage(TenderResponse tenderResponse)
        {
            if (tenderResponse == null)
            {
                return false;
            }
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var tenderResponseRepository = scope.ServiceProvider.GetRequiredService<TenderResponseRepository>();
                tenderResponse.Id = tenderResponseRepository.GenerateId();
                var tenderItemRepositor = scope.ServiceProvider.GetRequiredService<TenderItemRepository>();
                foreach(TenderItem tenderItem in tenderResponse.TenderItems)
                {
                    tenderItem.Id = tenderItemRepositor.GenerateId();
                    tenderItemRepositor.Save(tenderItem);
                }
                var pharmacyRepository = scope.ServiceProvider.GetRequiredService<PharmacyRepository>();
                foreach(Pharmacy p in pharmacyRepository.GetAll())
                {
                    if (p.PharmacyComunicationInfo.PharmacyApiKey.Equals(tenderResponse.PharmacyApiKey)){
                        tenderResponse.PharmacyId = p.Id;
                    }
                }
                tenderResponseRepository.Save(tenderResponse);
            }
            return true;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}