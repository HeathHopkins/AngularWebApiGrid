using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AngularWebApiGrid.Models;

namespace AngularWebApiGrid.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly DemoContext demoContext;

        public CustomersController()
        {
            demoContext = new DemoContext();
        }

        // GET api/<controller>
        public IEnumerable<Customer> Get()
        {
            return demoContext.Customers;
        }
    }
}