using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Hangfire;

namespace HelloKube.service
{
    class Program
    {
        // AutoResetEvent to signal when to exit the application.
        private static readonly AutoResetEvent waitHandle = new AutoResetEvent(false);
        public static IBusControl _bus;
        //private static BackgroundJobServer _jobServer;
        static void Main(string[] args)
        {

            Console.WriteLine("Starting hellokube.service");
            var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true)
        .AddJsonFile("config/externalsettings.json", optional: false);

            var Configuration = builder.Build();
            Console.WriteLine($"Connecting to: {Configuration["RabbitMQ:Uri"]}");
                GlobalConfiguration.Configuration.UseSqlServerStorage(Configuration["SqlServer:ConnectionString"]);
            BackgroundJobServer _jobServer = new BackgroundJobServer();
            
            // Fire and forget
            Task.Run(() =>
            {

                _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
                {
                    var host = sbc.Host(new Uri(Configuration["RabbitMQ:Uri"]), h =>
                    {
                        h.Username(Configuration["RabbitMQ:UserName"]);
                        h.Password(Configuration["RabbitMQ:Password"]);
                    });

                });

                _bus.Start();

                jobs.ServerTimeJob stj = new jobs.ServerTimeJob();
                RecurringJob.AddOrUpdate("rmq-sample-job", () => stj.Execute(), Cron.Minutely, TimeZoneInfo.Local);
                //_jobServer = new BackgroundJobServer();

                


            });

            // Handle Control+C or Control+Break
            Console.CancelKeyPress += (o, e) =>
            {
                Console.WriteLine("Exit");
                _bus.Stop();
                _jobServer.Dispose();


                // Allow the manin thread to continue and exit...
                waitHandle.Set();
            };

            // Wait
            waitHandle.WaitOne();
        }
    }
}

