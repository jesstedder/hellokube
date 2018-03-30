using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;

namespace HelloKube.service
{
    class Program
    {
        // AutoResetEvent to signal when to exit the application.
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            // Fire and forget
            Task.Run(() =>
            {
                var random = new Random(10);
                var bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    var host = sbc.Host(new Uri("rabbitmq://localhost/"), h =>
                    {
                        h.Username("user");
                        h.Password("bitnami");
                    });

    /*
        sbc.ReceiveEndpoint(host, "hello-kube-service", endpoint =>
        {
            endpoint.Handler<HelloKube.core.models.ServerTimeMessage>(async context =>
            {
                await Console.Out.WriteLineAsync($"Received: {context.Message.Value}");
            });
        });
        */
                });
                bus.Start();

                while (true)
                {
                    // Write here whatever your side car applications needs to do.
                    // In this sample we are just writing a random number to the Console (stdout)
                    Console.WriteLine($"Loop = {random.Next()}");
                    bus.Publish<HelloKube.core.models.ServerTimeMessage>(new core.models.ServerTimeMessage(){
                        ServerTime = DateTime.Now,
                        ExtraDetails = random.Next().ToString()
                    });

                    // Sleep as long as you need.
                    Thread.Sleep(5000);
                }
            });

            // Handle Control+C or Control+Break
            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Exit");

                // Allow the manin thread to continue and exit...
                waitHandle.Set();
            };

            // Wait
            waitHandle.WaitOne();
        }
    }
}

