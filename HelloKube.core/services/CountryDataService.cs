using System;
using System.Collections.Generic;
using System.Linq;

namespace HelloKube.core.services
{
    public class CountryDataService
    {
        private core.dal.WideWorldContext _ctx;
        public CountryDataService(core.dal.WideWorldContext ctx){
            _ctx = ctx;

        }

        public List<core.dal.Countries> GetCountryList(){
            return _ctx.Countries.ToList();
        }
    }
}