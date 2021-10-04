using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApplication.Singletons;
using StoreApplication;

namespace StoreApplicationUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StoresController : Controller
    {
        // GET: ProductsController
        /*
        public ActionResult Index()
        {
            return View();
        }
        */
        [HttpGet]
        public List<ViewModelStore> Index()
        {
            return StoreSingleton.Instance.Stores;
        }

        //get inventory base on store id 


        //get store orders based on 

        //get inventory based by Store id  stores/id
        [HttpGet("{id}")]
        public List<ViewModelInventory> GetStoreInventory(int id)
        {
            return StoreSingleton.Instance.GetInventory(id);
        }

    }
}
