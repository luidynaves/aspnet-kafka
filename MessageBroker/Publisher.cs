using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace aspnet_kafka.MessageBroker
{
    public class Publisher : IPublisher
    {
        private readonly ProducerConfig _producerConfig;
        private readonly string _topicName;
        private readonly IProducer<string, string> _producer;

        public Publisher(TopicConfig topicConfig)
        {
            _producerConfig = topicConfig.ProducerConfig;
            _topicName = topicConfig.TopicName;
            _producer = topicConfig.Producer;
        }

        public async Task Publish<T>(string key, T message)
        {
            string serializedMessage = JsonConvert.SerializeObject(message);

            DeliveryResult<string, string> dr = 
                await _producer.ProduceAsync(_topicName, new Message<string, string>
                {
                    Key = key,
                    Value = serializedMessage
                });
        }
    }
}