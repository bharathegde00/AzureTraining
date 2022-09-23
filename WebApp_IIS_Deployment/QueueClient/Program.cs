using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

namespace QueuesQuickstartV12
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Azure Queue Storage client library v12 - .NET quickstart sample\n");
            Console.WriteLine("Enter Queue Name");
            string queueName = Console.ReadLine();
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=trainingstorage22;AccountKey=U2KacLoYoEHJT8e2el59cbeGqRVvbehCZs56vbUFwuFrZfGAD49jVy75BVLjYgYM4pES2p2kFuTa+AStzZcqzQ==;EndpointSuffix=core.windows.net";
            QueueClient queueClient = new QueueClient(connectionString, queueName);
            PeekedMessage[] peekedMessages = await queueClient.PeekMessagesAsync(maxMessages: 10);
            foreach (PeekedMessage peekedMessage in peekedMessages)
            {
                // Display the message
                Console.WriteLine($"Message: {peekedMessage.MessageText}");
            }
        }
    }
}