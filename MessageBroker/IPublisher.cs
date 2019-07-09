using System.Threading.Tasks;

namespace aspnet_kafka.MessageBroker
{
    public interface IPublisher
    {
         Task Publish<T>(string key, T message);
    }
}