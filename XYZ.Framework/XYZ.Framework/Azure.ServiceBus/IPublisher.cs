using System;
using XYZ.Framework.Azure.ServiceBus.Topics;
using System.Threading.Tasks;

namespace XYZ.Framework.Azure.ServiceBus
{
    public interface IPublisher
    {
        Task Publish<T>(T message) where T : Topic;
    }
}
