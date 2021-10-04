using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SotreApplicationBusinessLayer;
using System.Linq;
using ModelsLayer;
using StoreApplicationDbContext.Models;
using Serilog;

namespace StoreApplication.Singletons
{
    public class StoreSingleton
    {
        private static StoreSingleton _storeSingleton;
        private static readonly StoreRepository _storeRepo = new StoreRepository();
        private static readonly OrderRepository _orderRepo = new OrderRepository();
        private const string _logFilePath = @"/Users/13478/desktop/StoreApplication/log/log.txt";
        public static StoreSingleton Instance
        {
            get
            {
               if(_storeSingleton==null)
                {
                    _storeSingleton = new StoreSingleton();
                }
                return _storeSingleton;
            }
        }
        public List<ViewModelStore> Stores
        {
            get
            {
                //select from linq:projects 
                //here convert each entity to a list element
               // Select() method, which allows you to take the data from the data source and shape it into something else.
                return _storeRepo.Load().Select(s=>
                new ViewModelStore()
                {
             StoreId = s.StoreId,
             StoreName= s.StoreName,
             StoreLocation= s.StoreLocation



                }
                ).ToList();

            }
        }

        public List<ViewModelInventory> GetInventory(int storeId)
        {
            return _storeRepo.GetInventory(storeId);
        }

        //place order
        public bool PlaceOrder(ViewModelOrder order)
        {
            Log.Information("PlaceOrder STORESINGLE TON");
            Order newOrder = new Order {
                CustomerId = order.CustomerId,
                OrderDate = DateTime.Now,
                OrderTotal = order.OrderTotal,
                StoreId = order.StoreId,
                OrderProducts = order.OrderProducts.Select(o =>
                    new OrderProduct { ProductId = o.ProductId, Quantity = o.Quantity }).ToList()
            };
            _orderRepo.Insert(newOrder);
               _storeRepo.Update(newOrder.StoreId, newOrder.OrderProducts);
            return true;
        }
        //load store orders with customer info

        public List<ViewModelOrder> StoreOrders(int storId)
        {
            Log.Information("StoreOrders by Id");
            return _storeRepo.GetOrders(storId)
                .Select(so => new ViewModelOrder()
                {
                    CustomerId = so.CustomerId,
                    FirstName = so.Customer.FirstName,
                    LastName = so.Customer.LastName,
                    OrderId = so.OrderId,
                    OrderDate = so.OrderDate,
                    OrderTotal = so.OrderTotal,
                    OrderProducts = so.OrderProducts
                        .Select(op => new ViewModelOrderProduct()
                        {
                            ProductId = op.ProductId,
                            Quantity = op.Quantity
                        }).ToList()
                }).ToList();
        }


    }
}
