using System;
using System.Threading.Tasks;

namespace XYZ.Framework.Azure.ServiceBus.Topics
{
    public interface TopicHandler
    {
    }

    public interface TopicHandler<T> : TopicHandler where T : Topic
    {
        Task Handle(T @event);
    }
}
