using System;

namespace HelloKube.service.jobs
{
    public class CacheCountryListJob
    {
        public void Execute(){
            var cfg = Program.Configuration;
            var dbConnString = cfg["SqlServer:ConnectionString"];
            var ctx = HelloKube.core.dal.WideWorldContext.Create(dbConnString);
            var ctrySvc = new HelloKube.core.services.CountryDataService(ctx);
            var countryList = ctrySvc.GetCountryList();
            var cache = HelloKube.core.services.CacheService.Connection.GetDatabase();
            cache.StringSet("country-list", Newtonsoft.Json.JsonConvert.SerializeObject(countryList));
            Console.WriteLine("Finished caching country list");
            

        }

    }
}