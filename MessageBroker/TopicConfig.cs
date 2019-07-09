using Confluent.Kafka;

namespace aspnet_kafka.MessageBroker
{
    public class TopicConfig
    {
        public TopicConfig(ProducerConfig producerConfig, string topicName)
        {
            ProducerConfig = producerConfig;
            TopicName = topicName;
            Producer = new ProducerBuilder<string, string>(producerConfig).Build();
        }

        public ProducerConfig ProducerConfig { get; private set; }

        public IProducer<string, string> Producer {get; private set;}
        public string TopicName { get; private set; }
    }
}