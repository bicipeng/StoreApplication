using System;

using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using StoreApplication.Singletons;
using Serilog;

namespace StoreApplication
{
    class Program
    {
        private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        private const string _logFilePath = @"/Users/13478/desktop/StoreApplication/log/log.txt";
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.File(_logFilePath).CreateLogger();
            #region
            /*
            ViewModelCustomer newCustomer  = new ViewModelCustomer();
            newCustomer.FirstName = "Mandy";
            newCustomer.LastName ="K";
            System.Console.WriteLine($"newCustomer: {newCustomer.FirstName}");*/
            #endregion


            /*  using (AstoreApplicationDBContext context = new AstoreApplicationDBContext())
              {

                  /*
                  var customers = context.Customers.FromSqlRaw<Customer>("SELECT * FROM Customer.Customer").ToList();
                  foreach(var cust in customers)
                  {
                      Console.WriteLine($"Customer firstName{cust.FirstName}, lastname LastName {cust.LastName}");
                  }*/



            //   }
            Log.Information("Program.cs");

            //Console.WriteLine("Welcome,here are the customers!!!");

            //foreach (var cus in _customerSingleton.Customers)
            //{
            //    Console.WriteLine($"Customer firstName{cus.FirstName}, LastNAME{cus.LastName}, pasword {cus.CustPassword}");
            //}


            //Console.WriteLine("Welcome,here are the stores");
            //foreach (var store in _storeSingleton.Stores)
            //{
            //    Console.WriteLine($" {store.StoreName} , {store.StoreLocation}");

            //}

            //foreach(var storeInventory in _storeSingleton.GetInventory(1))
            //{
            //    Console.WriteLine($"{storeInventory.ProductId} ,{storeInventory.ProductName} , {storeInventory.ProductDescription},{storeInventory. ProductPrice}, {storeInventory.Quantity}");
            //}
            //place a new order

            //  ViewModelOrder newOrder = new ViewModelOrder {
            //  CustomerId = 1,
            // OrderDate = DateTime.Now,
            //   StoreId = 1,
            //      OrderTotal = 20
            //};
            //newOrder.OrderProducts = new List<ViewModelOrderProduct>();
            //  newOrder.OrderProducts.Add(new ViewModelOrderProduct {ProductId = 1, Quantity = 2 });
            // newOrder.OrderProducts.Add(new ViewModelOrderProduct { ProductId = 3, Quantity = 50 });

            //   _storeSingleton.PlaceOrder(newOrder);


            //add new customer

            //Console.WriteLine("ENETER CUSTOERM'S FirstName");
            //string fName = Console.ReadLine();C
            //Console.WriteLine("ENETER CUSTOERM'S LastName");
            //string lName = Console.ReadLine();
            //Console.WriteLine("ENETER CUSTOERM'S Password");
            //string pWord = Console.ReadLine();

            //ViewModelCustomer newCust = new ViewModelCustomer()
            //{
            //    FirstName = fName,
            //    LastName = lName,
            //    CustPassword = pWord
            //};
            //_customerSingleton.Add(newCust);

            //find cust by name
            //var cust = _customerSingleton.FindCust("ken", "abba");
            //Console.WriteLine($"{cust.FirstName} {cust.LastName} {cust.CustomerId}");

            //fid cust by id
            //var cust = _customerSingleton.FindCust("ken","1234");
            //Console.WriteLine($"{cust.FirstName} {cust.LastName} {cust.CustomerId}");


            //var custOrder = _customerSingleton.CustOrder(1);
            //foreach (var order in custOrder)
            //{
            //    Console.WriteLine($"{order.CustomerId} , {order.OrderDate},{order.OrderId},{order.OrderTotal}");
            //    foreach (var pro in order.OrderProducts)
            //    {
            //        Console.Write($"{pro.ProductId},{pro.Quantity}");
            //    }
            //}

            var storeOrder = _storeSingleton.StoreOrders(1);
            Console.WriteLine("hiiiiiiii");
            foreach (var order in storeOrder)
            {
                Console.WriteLine($"{order.CustomerId} ,{order.FirstName} {order.LastName} , {order.OrderDate},{order.OrderId},{order.OrderTotal}");
                foreach (var pro in order.OrderProducts)
                {
                    Console.WriteLine($"\t{pro.ProductId},{pro.Quantity}");
                }
            }

        }
    }
}
