using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreApplication;
using StoreApplication.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApplicationUI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //get order based on orders/storid
        [HttpGet("{id}")]
        public List<ViewModelOrder> GetSotreOrders(int id)
        {
          return StoreSingleton.Instance.StoreOrders(id);
       }

        [HttpPost("neworder")]
        public ActionResult AddOrder([FromBody] ViewModelOrder newOrder)
        {
            if (!ModelState.IsValid) return BadRequest();

            StoreSingleton.Instance.PlaceOrder(newOrder);

            // return newCust;
            return Ok(new { Success = true});
        }

        [HttpGet("customer/{id}")]//customer/orderid 
        public List<ViewModelOrder> listCustomerOrders(int id)
        {


            return CustomerSingleton.Instance.CustOrder(id);

        }

    }
}
