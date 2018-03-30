using System;
using Microsoft.AspNetCore.SignalR;
using MassTransit;
using HelloKube.core.models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace HelloKube.Hubs{
    public class ServerTimeConsumer : IConsumer<HelloKube.core.models.ServerTimeMessage> {

        public async Task Consume(ConsumeContext<ServerTimeMessage> context)
        {

            //NOTE:  This is a hack because I couldn't figure out how to inject the signalr hubcontext into the consumer
            await Startup.NotificationHubContext.Clients.All.SendAsync("SendMessage", $"ServerTime: {context.Message.ServerTime:HH:mm} Random: {context.Message.ExtraDetails}");
        }
    }
}