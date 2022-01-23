using System;
using System.Threading.Tasks;

namespace XYZ.Framework.Azure.ServiceBus.Topics
{
    public interface ITopicHandler
    {
    }

    public interface ITopicHandler<T> : ITopicHandler where T : Topic
    {
        Task Handle(T message);
    }
}
