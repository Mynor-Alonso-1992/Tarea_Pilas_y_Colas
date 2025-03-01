using QueueServiceApp;

public class QueueManager
{
    private readonly IQueueService _queueService;

    public QueueManager(IQueueService queueService)
    {
        _queueService = queueService;
    }

    public void SendMessage(string message)
    {
        _queueService.Enqueue(message);
    }

    public void ReceiveMessage()
    {
        string? message = _queueService.Dequeue();
        Console.WriteLine(message != null ? $"Mensaje recibido: {message}" : "No hay mensajes en la cola.");
    }
}
