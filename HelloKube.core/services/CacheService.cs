using System;
using StackExchange.Redis;

namespace HelloKube.core.services
{
    public class CacheService{
        public static string ConnectionString { get; set; }
        private static Lazy<ConnectionMultiplexer> lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
        {
            return ConnectionMultiplexer.Connect(ConnectionString);
        });



        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }        
    }
}