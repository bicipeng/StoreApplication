using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApplicationDbContext.Models;

namespace SotreApplicationBusinessLayer
{
    public class OrderRepository : IRpository<Order>
    {
        private AstoreApplicationDBContext context;
        public OrderRepository()
        {
            context = new AstoreApplicationDBContext();
        }
        public bool Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Order entry)
        {
            context.Orders.Add(entry);
            context.SaveChanges();
            return true;
        }

        public List<Order> Load()
        {
            throw new NotImplementedException();
        }

        public bool Update()
        {
            throw new NotImplementedException();
        }
    }
}

