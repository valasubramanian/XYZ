using System;
using XYZ.Framework.Azure.ServiceBus.Topics;
using System.Threading.Tasks;

namespace XYZ.Framework.Azure.ServiceBus
{
    public interface ISubscriber
    {
        Task Subscribe<T>(T topic) where T : Topic;
    }
}
