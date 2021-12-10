using IntegrationLibrary.Model;
using IntegrationLibrary.Repository;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace IntegrationLibrary.Service
{
    public class RabbitMQService : BackgroundService
    {
        private IConnection connection;
        private IModel channel;
        private readonly IServiceScopeFactory serviceScopeFactory;
        
        
      public RabbitMQService(IServiceScopeFactory scopeFactory)
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
            channel.ExchangeDeclare(exchange: "medicineBenefit", ExchangeType.Topic);
            using (var scope = serviceScopeFactory.CreateScope()) {

                var pharmacyRepository = scope.ServiceProvider.GetRequiredService<PharmacyRepository>();
                     foreach (Pharmacy p in pharmacyRepository.GetAll())
                     {
                    channel.QueueDeclare(
                            queue: p.PharmacyName,
                            durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null
                        );

                    channel.QueueBind(
                               queue: p.PharmacyName,
                               exchange: "medicineBenefit",
                               routingKey: p.PharmacyName
                               ) ;
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
                MedicineBenefit dto = JsonConvert.DeserializeObject<MedicineBenefit>(jsonMessage);
                HandleMessage(dto);

                Console.WriteLine(dto.MedicineBenefitContent);
                Console.WriteLine(jsonMessage);
                //channel.BasicAck(ea.DeliveryTag, false);
            };
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var pharmacyRepository = scope.ServiceProvider.GetRequiredService<PharmacyRepository>();
                foreach (Pharmacy p in pharmacyRepository.GetAll())
                {

                    channel.BasicConsume(
                               queue: p.PharmacyName,
                               autoAck: true,
                               consumer: consumer
                               );
                }
            }
            return base.StartAsync(stoppingToken);
        }
        private void HandleMessage(MedicineBenefit medicineBenefit)
        {
            using (var scope = serviceScopeFactory.CreateScope()) {
                var medicineBenefitRepository = scope.ServiceProvider.GetRequiredService<MedicineBenefitRepository>();
                medicineBenefit.Id = medicineBenefitRepository.GenerateId();
                medicineBenefit.Published = true;
                medicineBenefitRepository.Save(medicineBenefit);
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
