using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QueueServiceApp;


namespace QueueServiceApp
{
    public interface IQueueService
    {
        void Enqueue(string message);  // Agregar un mensaje a la cola
        string Dequeue();             // Extraer un mensaje de la cola
    }

}
