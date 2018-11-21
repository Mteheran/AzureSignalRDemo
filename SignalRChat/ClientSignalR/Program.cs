using Microsoft.AspNetCore.SignalR.Client;
using SignalRChat.Hubs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientSignalR
{
    class Program
    {
        public static void Main(string[] args)
        {

            var con = new HubConnectionBuilder().
                    WithUrl("http://localhost:53732/chatHub").
                    Build();

            con.On<ChatMessage>("RecieveMessage", (chatMessage) =>
            {
                Console.WriteLine(chatMessage.User + " - " + chatMessage.Message);
            });

            con.StartAsync().Wait();

            while (true)
            {
                var message = Console.ReadLine();

                con.InvokeAsync("SendMessage", new ChatMessage() { User = "Console", Message = message }).Wait();
            }
        }
    }
}
