using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace FunctionChat
{
    public static class FunctionChat
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
          [HttpTrigger(AuthorizationLevel.Anonymous, Route = "chatHub/negotiate")] HttpRequest req,
          [SignalRConnectionInfo(HubName = "chatHub")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("SendMessage")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "chatHub/SendMessage")] object message,
            [SignalR(HubName = "chatHub")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    
                    Target = "RecieveMessage",
                    Arguments = new[] { message }
                });
        }

    }
}
