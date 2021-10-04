using System;
using Xunit;
using StoreApplication;
using StoreApplication.Singletons;

namespace StoreApplication.Tests
{
    public class UnitTest1
    {//test cust
        private static readonly CustomerSingleton _customerSingleton = CustomerSingleton.Instance;
        private static readonly StoreSingleton _storeSingleton = StoreSingleton.Instance;
        [Fact]
        public void getCutomers()
        {
            //search customer by name and password
            var findcust =_customerSingleton.FindCust("ken", "1234");
            Assert.NotNull(findcust);
        }

        [Fact]
        public void getAllCutomers()
        {
            //get all custs
            var listAllCust = _customerSingleton.Customers;
            Assert.NotNull(listAllCust);
        }

      

        [Fact]
        public void findCustByid()
        {
            //get cust by id
            var cust = _customerSingleton.FindById(8);
            Assert.NotNull(cust);
        }

        [Fact] //get customer order by custIdd
        public void findOrderByid()
        {
            //get cust by id
            var cust = _customerSingleton.CustOrder(8);
            Assert.NotNull(cust);
        }

        //STORES TESTS

        [Fact] //GET ALL STORES.
        public void allstores()
        {
            //get cust by id
            var stores = _storeSingleton.Stores;
            Assert.NotNull(stores);
        }

        [Fact] //GET Iventory by Id
        public void storeInvent()
        {
            //get cust by id
            var stores = _storeSingleton.GetInventory(3);
            Assert.NotNull(stores);
        }

        [Fact] //GET order by StoreId
        public void storeOrder()
        {
            //get cust by id
            var stores = _storeSingleton.StoreOrders(3);
            Assert.NotNull(stores);
        }




    }
}
