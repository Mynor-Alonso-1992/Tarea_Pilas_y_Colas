using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.SQS;
using Amazon.SQS.Model;

namespace QueueServiceApp
{
    public class AmazonSQSQueue : IQueueService
    {
        private readonly AmazonSQSClient _sqsClient;
        private readonly string _queueUrl;

        public AmazonSQSQueue(string queueUrl, RegionEndpoint region)
        {
            _sqsClient = new AmazonSQSClient(region);
            _queueUrl = queueUrl;
        }


        void IQueueService.Enqueue(string message)
        {
            var sendMessageRequest = new SendMessageRequest { QueueUrl = _queueUrl, MessageBody = message };
            _sqsClient.SendMessageAsync(sendMessageRequest);
        }

        string IQueueService.Dequeue()
        {
            var receiveMessageRequest = new ReceiveMessageRequest { QueueUrl = _queueUrl, MaxNumberOfMessages = 1 };
            // Obtener la respuesta de manera síncrona
            var response = _sqsClient.ReceiveMessageAsync(receiveMessageRequest).Result;

            if (response.Messages.Count > 0)
            {
                var message = response.Messages[0];
                _sqsClient.DeleteMessageAsync(_queueUrl, message.ReceiptHandle);
                return message.Body;
            }
            return null;
        }
    }
}
