using System;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;

namespace Azure.ConsoleClient
{
    class Program
    {
        static string connectionString = "Endpoint=sb://mslearnfromindia.servicebus.windows.net/;SharedAccessKeyName=vala;SharedAccessKey=j7QYg1Rlx7vlgig2PPfth2fBTmFI5YojhZ08ymierEc=";
        static ServiceBusClient client;
        static ServiceBusProcessor processor;

        static async Task Main(string[] args)
        {
            string topicName = "place-order";
            string subscriptionName = "process-payment";
            client = new ServiceBusClient(connectionString);
            processor = client.CreateProcessor(topicName, subscriptionName, new ServiceBusProcessorOptions());
            try
            {
                processor.ProcessMessageAsync += MessageHandler;
                processor.ProcessErrorAsync += ErrorHandler;
                await processor.StartProcessingAsync();
                
                Console.WriteLine("Wait for a minute and then press any key to end the processing");
                Console.ReadKey();

                Console.WriteLine("\nStopping the receiver...");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopped receiving messages");
            }
            finally
            {
                await processor.DisposeAsync();
                await client.DisposeAsync();
            }
        }

        // handle received messages
        private static async Task MessageHandler(ProcessMessageEventArgs args)
        {
            string body = args.Message.Body.ToString();
            Console.WriteLine($"Received: {body}");
            await args.CompleteMessageAsync(args.Message);
        }

        // handle any errors when receiving messages
        private static Task ErrorHandler(ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception.ToString());
            return Task.CompletedTask;
        }
    }
}
