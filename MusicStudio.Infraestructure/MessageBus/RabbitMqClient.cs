using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStudio.Infraestructure.MessageBus
{
    public class RabbitMqClient : IMessageBusClient
    {
        private readonly IConnection _connection;
        public RabbitMqClient(IConnection producerConnection)
        {
            _connection = producerConnection;
        }
        public void Publish(object message, string RoutingKey, string exchange)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
            };
            var channel = _connection.CreateModel();
            var payload= JsonConvert.SerializeObject(message,settings);
            var body = Encoding.UTF8.GetBytes(payload);
            channel.BasicPublish(exchange, RoutingKey, null, body);
        }
    }
}
