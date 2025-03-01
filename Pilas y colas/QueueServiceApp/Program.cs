using Amazon;
using QueueServiceApp;
using RabbitMQ.Util;
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Elige un proveedor de cola:");
        Console.WriteLine("1 - Memoria");
        Console.WriteLine("2 - RabbitMQ");
        string? opcion = Console.ReadLine();

        IQueueService queueService = opcion == "2" ? new RabbitMQQueueService() : new AmazonSQSQueue("https://sqs.us-east-2.amazonaws.com/390844785433/Tarea_cola.fifo", RegionEndpoint.USEast1); ;
        QueueManager manager = new QueueManager(queueService);

        // Prueba de Enqueue y Dequeue
        manager.SendMessage("Hola, esto es un mensaje de prueba.");
        manager.ReceiveMessage();
    }
}
