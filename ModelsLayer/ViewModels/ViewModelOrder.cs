using System;
using System.Collections.Generic;

namespace StoreApplication
{
    public class ViewModelOrder:ViewModelCustomer
    {

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
        public List<ViewModelOrderProduct> OrderProducts {get;set;}
    }
    public class ViewModelOrderProduct
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}