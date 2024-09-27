using FC.Relatorio.DTOs;
using FC.Relatorio.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace FC.Relatorio.Infra
{
    public class RabbitMQConsumer : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "movimentacao_queue"; 
        private readonly string _username = "guest"; 
        private readonly string _password = "guest";

        public RabbitMQConsumer(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory()
            {
                HostName = _hostname,
                UserName = _username,
                Password = _password
            };

            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var mensagem = Encoding.UTF8.GetString(body);

                var movimentacaoDto = JsonSerializer.Deserialize<MovimentacaoCaixaDTO>(mensagem);

                if (movimentacaoDto is not null) 
                {
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var scopedService = scope.ServiceProvider.GetRequiredService<IRelatorioService>();

                        await scopedService.CriarRegistro(movimentacaoDto);
                    }
                }

            };

            channel.BasicConsume(queue: _queueName, autoAck: true, consumer: consumer);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken); // Faz o serviço continuar rodando
            }
        }
    }
}
