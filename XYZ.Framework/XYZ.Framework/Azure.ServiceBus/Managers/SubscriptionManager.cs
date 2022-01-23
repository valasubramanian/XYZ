using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XYZ.Framework.Azure.ServiceBus.Topics;

namespace XYZ.Framework.Azure.ServiceBus.Managers
{
  public class SubscriptionManager : ISubscriptionManager
  {
    private IConnectionManager _connectionManager;
    private ITopicManager _topicManager;
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, string> _topicHandlers;
    private readonly Dictionary<string, string> _topicAssemblies;

    public SubscriptionManager(
      IConnectionManager connectionManager,
      ITopicManager topicManager,
      IServiceProvider serviceProvider)
    {
      this._connectionManager = connectionManager;
      this._topicManager = topicManager;
      this._serviceProvider = serviceProvider;
      this._topicHandlers = new Dictionary<string, string>();
      this._topicAssemblies = new Dictionary<string, string>();
    }

    public async Task SubscribeTopic<T, TH>()
      where T : Topic
      where TH : ITopicHandler
    {
      string topicName = typeof (T).Name;
      string[] typeSplits = topicName.Split('.', '+');
      string exactTopicName = typeSplits[typeSplits.Length - 1];
      bool topicCreated = await this._topicManager.CreateTopic(exactTopicName);
      if (!topicCreated)
      {
        topicName = (string) null;
        typeSplits = (string[]) null;
        exactTopicName = (string) null;
      }
      else
      {
        string assemblyFullName = typeof (TH).Assembly.FullName;
        string assemblyName = assemblyFullName.Split(',')[0];
        ManagementClient managementClient = new ManagementClient(this._connectionManager.GetConnectionString());
        bool flag = await managementClient.SubscriptionExistsAsync(exactTopicName, assemblyName);
        if (!flag)
        {
          SubscriptionDescription subscriptionAsync = await managementClient.CreateSubscriptionAsync(exactTopicName, assemblyName);
        }
        this.RegisterMessageHandler<T, TH>(exactTopicName, assemblyName);
        assemblyFullName = (string) null;
        assemblyName = (string) null;
        managementClient = (ManagementClient) null;
        topicName = (string) null;
        typeSplits = (string[]) null;
        exactTopicName = (string) null;
      }
    }

    private void RegisterMessageHandler<T, TH>(string topicName, string subscriptionName)
      where T : Topic
      where TH : ITopicHandler
    {
      SubscriptionClient subscriptionClient = new SubscriptionClient(this._connectionManager.GetConnectionString(), topicName, subscriptionName, ReceiveMode.ReceiveAndDelete, RetryPolicy.Default);
      if (subscriptionClient == null)
        return;

      if (!this._topicHandlers.ContainsKey(topicName))
        this._topicHandlers.Add(topicName, typeof (TH).AssemblyQualifiedName);
      if (!this._topicAssemblies.ContainsKey(topicName))
        this._topicAssemblies.Add(topicName, typeof (T).AssemblyQualifiedName);

      subscriptionClient.RegisterMessageHandler((Func<Message, CancellationToken, Task>) (async (message, token) =>
      {
        bool flag = await this.ProcessTopicMessage(message);
        if (!flag)
          return;
        await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
      }), new MessageHandlerOptions(new Func<ExceptionReceivedEventArgs, Task>(this.HandlingEventExceptionHandler))
      {
        MaxConcurrentCalls = 1,
        AutoComplete = false
      });
    }

    private async Task<bool> ProcessTopicMessage(Message message)
    {
      string topicHandlerName = string.Empty;
      string topicAssemblyName = string.Empty;
      this._topicHandlers.TryGetValue(message.Label, out topicHandlerName);
      this._topicAssemblies.TryGetValue(message.Label, out topicAssemblyName);
      if (!string.IsNullOrEmpty(topicHandlerName) && !string.IsNullOrEmpty(topicAssemblyName))
      {
        Type typeOfHandler = Type.GetType(topicHandlerName);
        Type typeOfTopic = Type.GetType(topicAssemblyName);
        object handler = Activator.CreateInstance(typeOfHandler);
        if (handler != null)
        {
          string messageBody = Encoding.UTF8.GetString(message.Body);
          object objMessage = JsonConvert.DeserializeObject(messageBody);
          Type handlerType = typeof (ITopicHandler<>).MakeGenericType(typeOfTopic);
          await (Task) handlerType.GetMethod("Handle").Invoke(handler, new object[1]
          {
            objMessage
          });
          return true;
        }
        typeOfHandler = (Type) null;
        typeOfTopic = (Type) null;
        handler = (object) null;
      }
      return false;
    }

    private Task HandlingEventExceptionHandler(
      ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
      return Task.CompletedTask;
    }

    public async Task UnSubscribeTopic<T>() where T : Topic
    {
    }
  }
}
