using Microsoft.AspNetCore.Mvc;
using StoreApplication;
using StoreApplication.Singletons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApplicationUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet("{firstname}/{password}")]
        public ViewModelCustomer get(string firstname, string password)
        {
            return CustomerSingleton.Instance.FindCust(firstname, password);
        }
        [HttpGet]
        public List<ViewModelCustomer> Get()
        {
            return CustomerSingleton.Instance.Customers;
        }
        [HttpGet("{id}")]
        public ViewModelCustomer findCust(int id) {


            return CustomerSingleton.Instance.FindById(id);
        
        }
        [HttpPost("newcustomer")]//post to customers/newcustomer
        public  ActionResult<ViewModelCustomer>  addCust([FromBody] ViewModelCustomer newCust)
        {
            if (!ModelState.IsValid) return BadRequest();

            CustomerSingleton.Instance.Add(newCust);
            
            return newCust;

        }
        //load customer orders by id

    }
}
