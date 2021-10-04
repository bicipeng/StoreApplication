using System.Collections.Generic;
//using ModelsLayer;
using SotreApplicationBusinessLayer;
using System.Linq;
using StoreApplicationDbContext.Models;
using Serilog;

namespace StoreApplication.Singletons
{
    public class CustomerSingleton
    {
        private static CustomerSingleton _customerSingleton;
        private static readonly CustomerRepository _customerRepo = new CustomerRepository();
        private const string _logFilePath = @"/Users/13478/desktop/StoreApplication/log/log.txt";
      

        public static CustomerSingleton Instance
        {
            get
            {
                if (_customerSingleton == null)
                {
                    _customerSingleton = new CustomerSingleton();
                }
                return _customerSingleton;
            }
        }
        /*
        public List<ViewModelCustomer> Customers { get; private set; }
        public void LoadCustomers()
        {
            Customers = _customerRepo.Select().Select(c=> 
            new ViewModelCustomer() { 
                 FirstName = c.FirstName,
                 LastName = c.LastName,
            }
            ).ToList();
        }
                public void RefreshData()
        {
            _customers = null;
        }
        public List<ViewModelCustomer> _customers = null;
        public List<ViewModelCustomer> Customers
        {
            get
            {
                if (_customers == null)
                {
                    _customers = _customerRepo.Select().Select(c =>
                    new ViewModelCustomer()
                    {
                        FirstName = c.FirstName,
                        LastName = c.LastName,
                    }
                    ).ToList();
                }
                return _customers;
            }
        }
        */
    
        public List<ViewModelCustomer> Customers
        {
             
            get
            {
                //select from linq:projects eachele of a sequence into a new form
                //here convert each entity to a list element
                return _customerRepo.Load().Select(c =>
                new ViewModelCustomer()
                {
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    CustomerId = c.CustomerId,
                    CustPassword=c.CustPassword,
                }
                ).ToList();

            }
        }

        //revisit, what's the need of type conversion for the Customer class
        public void Add(ViewModelCustomer vmCust)
        {
            Log.Information("VieModelCUst{}");

            var entityCust = new Customer { FirstName = vmCust.FirstName, LastName = vmCust.LastName, CustPassword = vmCust.CustPassword };
            _customerRepo.Insert(entityCust);
            vmCust.CustomerId = entityCust.CustomerId;
        }

        public ViewModelCustomer FindCust(string fn, string ln)
        {
            Log.Information("VieModelFindCust by name{} customer");
            var aCust = _customerRepo.Search(fn, ln);
            if (aCust == null)
            {
                return null;
            }
            else
            {
                return new ViewModelCustomer()
                {
                    FirstName = aCust.FirstName,
                    LastName = aCust.LastName,
                    CustomerId = aCust.CustomerId,
                    CustPassword= aCust.CustPassword,
                };
            }
        }

        //find cust by id

        public ViewModelCustomer FindById(int id)
        {
            var foundCust = _customerRepo.getById(id);
            if (foundCust == null)
            {
                return null;
            }
            else
            {
                return new ViewModelCustomer()
                {
                    FirstName = foundCust.FirstName,
                    LastName = foundCust.LastName,
                    CustomerId = foundCust.CustomerId,
                    CustPassword = foundCust.CustPassword,
                };
            }
        }
        public List<ViewModelOrder> CustOrder(int custId)
        {
            Log.Information("VieModelCUst{} custOrder");
            return _customerRepo.ListOrder(custId)
                .Select(o => new ViewModelOrder()
                {
                    CustomerId = custId,
                    OrderDate = o.OrderDate,
                    OrderId = o.OrderId,
                    OrderTotal = o.OrderTotal,
                    OrderProducts = o.OrderProducts
                        .Select(op => new ViewModelOrderProduct() { 
                             ProductId = op.ProductId,
                             Quantity = op.Quantity
                        }).ToList()
                }).ToList();
        }

    }
}