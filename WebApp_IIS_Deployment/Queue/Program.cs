using Azure.Storage.Queues.Models;

using Azure.Storage.Queues;
using System;
using System.Threading.Tasks;

namespace Queue
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Azure Queue Storage client library v12 - .NET quickstart sample\n");
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=trainingstorage22;AccountKey=U2KacLoYoEHJT8e2el59cbeGqRVvbehCZs56vbUFwuFrZfGAD49jVy75BVLjYgYM4pES2p2kFuTa+AStzZcqzQ==;EndpointSuffix=core.windows.net";
            // Create a unique name for the queue
            string first = "new";

            Console.WriteLine($"Creating queue: {first}");

            // Instantiate a QueueClient which will be
            // used to create and manipulate the queue
            QueueClient newQ = new QueueClient(connectionString, first);

            // Create the queue
            await newQ.CreateAsync();
            Console.WriteLine("\nAdding messages to the queue...");

            // Send several messages to the queue
            await newQ.SendMessageAsync("First message");
            await newQ.SendMessageAsync("Second message");

            // Save the receipt so we can update this message later
            SendReceipt receipt = await newQ.SendMessageAsync("Third message");
            Console.WriteLine("\nPeek at the messages in the queue...");

            // Peek at messages in the queue

            Console.WriteLine("\nUpdating the third message in the queue...");

            // Update a message using the saved receipt from sending the message
            await newQ.UpdateMessageAsync(receipt.MessageId, receipt.PopReceipt, "Third message has been updated");


        }
    }
}