using System;

namespace HelloKube.service.jobs
{
    public class ServerTimeJob
    {
        public void Execute()
        {
            // Write here whatever your side car applications needs to do.
            // In this sample we are just writing a random number to the Console (stdout)
            var random = new Random(10);

            var nxt = random.Next();
            Console.WriteLine($"Loop = {nxt}");
            Program._bus.Publish<HelloKube.core.models.ServerTimeMessage>(new core.models.ServerTimeMessage()
            {
                ServerTime = DateTime.Now,
                ExtraDetails = nxt.ToString()
            });


        }

        public void HelloWorld(){
            Console.WriteLine("Hello there");
        }
    }

}