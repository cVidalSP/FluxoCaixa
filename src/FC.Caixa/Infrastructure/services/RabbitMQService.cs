using RabbitMQ.Client;
using System.Text.Json;
using System.Text;

namespace FC.Caixa.Infrastructure.services
{
    public class RabbitMQService
    {
        private readonly string _hostname = "localhost";
        private readonly string _queueName = "movimentacao_queue";
        private readonly string _username = "guest";
        private readonly string _password = "guest";

        private IConnection _connection;

        public RabbitMQService()
        {
            CriarConexao();
        }

        private void CriarConexao()
        {
            if (_connection == null || !_connection.IsOpen)
            {
                var factory = new ConnectionFactory()
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
        }

        public void EnviarMovimentacao(object movimentacao)
        {
            using (var channel = _connection.CreateModel())
            {
                // Declare a queue (in case it does not exist)
                channel.QueueDeclare(queue: _queueName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                // Serializar a movimentação para JSON
                var mensagem = JsonSerializer.Serialize(movimentacao);
                var body = Encoding.UTF8.GetBytes(mensagem);

                // Enviar a mensagem
                channel.BasicPublish(exchange: "",
                                     routingKey: _queueName,
                                     basicProperties: null,
                                     body: body);

                Console.WriteLine($"[x] Enviado para fila: {mensagem}");
            }
        }
    }
}
