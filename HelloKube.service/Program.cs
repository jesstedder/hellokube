using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace HelloKube.service
{
    class Program
    {
        // AutoResetEvent to signal when to exit the application.
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);
        private static IBusControl _bus;
        static void Main(string[] args)
        {
            // Fire and forget
            Task.Run(() =>
            {
                var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional:true)
            .AddJsonFile("config/externalsettings.json", optional:false);

            var Configuration = builder.Build();
            Console.WriteLine($"Connecting to: {Configuration["RabbitMQ:Uri"]}");
        
            _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri(Configuration["RabbitMQ:Uri"]), h =>
                {
                    h.Username(Configuration["RabbitMQ:UserName"]);
                    h.Password(Configuration["RabbitMQ:Password"]);
                });

            });
                
                var random = new Random(10);
                _bus.Start();

                while (true)
                {
                    // Write here whatever your side car applications needs to do.
                    // In this sample we are just writing a random number to the Console (stdout)
                    var nxt = random.Next();
                    Console.WriteLine($"Loop = {nxt}");
                    _bus.Publish<HelloKube.core.models.ServerTimeMessage>(new core.models.ServerTimeMessage(){
                        ServerTime = DateTime.Now,
                        ExtraDetails = nxt.ToString()
                    });

                    // Sleep as long as you need.
                    Thread.Sleep(5000);
                }
            });

            // Handle Control+C or Control+Break
            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Exit");
                _bus.Stop();

                // Allow the manin thread to continue and exit...
                waitHandle.Set();
            };

            // Wait
            waitHandle.WaitOne();
        }
    }
}

