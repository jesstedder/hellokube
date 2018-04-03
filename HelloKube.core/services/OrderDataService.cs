using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace HelloKube.core.services
{
    public class OrderDataService
    {
        private core.dal.WideWorldContext _ctx;
        public OrderDataService(core.dal.WideWorldContext ctx){
            _ctx = ctx;
        }

        public List<core.dal.Orders> GetOrders(int top){
            return _ctx.Orders
            .Include(o=>o.Customer)
            .Take(top).ToList();
        }
    }
}