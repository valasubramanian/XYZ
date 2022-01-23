using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XYZ.Framework.Azure.ServiceBus.Managers;

namespace XYZ.Framework.Azure.ServiceBus
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAzureServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("AzureServiceBus:ConnectionString");
            services.AddSingleton<IConnectionManager>(connectionManager =>
            {
                return new ConnectionManager(connectionString);
            });
            services.AddSingleton<ITopicManager, TopicManager>();
            services.AddSingleton<ISubscriptionManager, SubscriptionManager>();
            services.AddScoped<IPublisher, Publisher>();
            services.AddScoped<ISubscriber, Subscriber>();
        }
    }
}
