using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApplicationDbContext.Models;
using SotreApplicationBusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace SotreApplicationBusinessLayer
{
    public class CustomerRepository: IRpository<Customer>
    { 
        private  AstoreApplicationDBContext context;

        public CustomerRepository()
        {

            context = new AstoreApplicationDBContext();
        }

        public bool Delete(int Id)
        {
            throw new System.NotImplementedException();
        }
        public bool Insert(Customer entry )
        {
            //add customer
            //  _da.Database.ExecuteSqlRaw("insert into Customer.Customer(Name) values ({0})", customer.Name);
         
            context.Customers.Add(entry);
            context.SaveChanges();
            return true;
        }

        public List<Customer> Load()
        {
            return context.Customers.FromSqlRaw("SELECT*FROM Customer.Customer").ToList();
    }
        public bool Update()
        {
            throw new System.NotImplementedException();
        }

        public Customer Search(string fn, string pw)
        {
            return context.Customers.FromSqlRaw($"SELECT * FROM Customer.Customer WHERE Customer.FirstName = '{fn}' and Customer.CustPassword = '{pw}'").FirstOrDefault();
        }
        //get customer by id
        public Customer getById(int id)
        {
            return context.Customers.FromSqlRaw($"SELECT * FROM Customer.Customer WHERE Customer.CustomerId ={id}").FirstOrDefault();
        }
        public List<Order> ListOrder(int custId)
        {
            return context.Orders.FromSqlRaw($"SELECT * FROM Store.[Order] o WHERE o.CustomerId = {custId} ").ToList();
        }

    }
}