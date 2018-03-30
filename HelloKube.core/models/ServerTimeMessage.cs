using System;

namespace HelloKube.core.models
{
    public class ServerTimeMessage{
        public DateTime ServerTime { get; set; }
        public string ExtraDetails { get; set; }
    }
}