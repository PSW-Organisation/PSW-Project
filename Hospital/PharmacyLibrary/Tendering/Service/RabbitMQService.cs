using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PharmacyAPI.Model;
using PharmacyLibrary.Repository.HospitalRepository;
using PharmacyLibrary.Tendering.Adapters;
using PharmacyLibrary.Tendering.DTO;
using PharmacyLibrary.Tendering.Repository.RepoImpl;
using PharmacyLibrary.Tendering.Repository.RepoInterfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PharmacyLibrary.Tendering.Service
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
            channel.ExchangeDeclare(exchange: "tenders", ExchangeType.Fanout);
            using (var scope = serviceScopeFactory.CreateScope())
            {

                var hospitalRepository = scope.ServiceProvider.GetRequiredService<IHospitalRepository>();
                foreach (Hospital h in hospitalRepository.Get())
                {

                    Console.WriteLine(h.HospitalName);
                    channel.QueueDeclare(
                        queue: h.HospitalName,
                        durable: false,
                                exclusive: false,
                                    autoDelete: false,
                                    arguments: null
                                    );
                    channel.QueueBind(
                               queue: h.HospitalName,
                               exchange: "tenders",
                               routingKey: h.HospitalName
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
                TenderDTO dto = JsonConvert.DeserializeObject<TenderDTO>(jsonMessage);
                HandleMessage(dto);

                Console.WriteLine(jsonMessage);
                //channel.BasicAck(ea.DeliveryTag, false);
            };
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var hospitalRepository = scope.ServiceProvider.GetRequiredService<IHospitalRepository>();
                foreach (Hospital h in hospitalRepository.Get())
                {

                    channel.BasicConsume(
                               queue: h.HospitalName,
                               autoAck: true,
                               consumer: consumer
                               );
                }
            }
            return base.StartAsync(stoppingToken);
        }
        private bool HandleMessage(TenderDTO dto)
        {
            if (dto == null)
            {
                return false;
            }
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var tenderRepository = scope.ServiceProvider.GetRequiredService<ITenderRepository>();
                tenderRepository.Add(TenderAdapter.TenderDtoToTender(dto));
            }
            return true;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
    }
}
