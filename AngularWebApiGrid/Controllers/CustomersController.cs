using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Linq.Dynamic;
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

        // GET api/customers
        public PagedResult<Customer> Get(int pageNo = 1, int pageSize = 50, [FromUri] string[] sort = null)
        {
            // Determine the number of records to skip
            int skip = (pageNo - 1) * pageSize;

            IQueryable<Customer> queryable = demoContext.Customers;

            // Add the sorting
            if (sort != null)
                queryable = queryable.ApplySorting(sort);
            else
                queryable = queryable.OrderBy(c => c.Id);

            // Get the total number of records
            int totalItemCount = queryable.Count();

            // Retrieve the customers for the specified page
            var customers = queryable
                .Skip(skip)
                .Take(pageSize)
                .ToList();

            // Return the paged results
            return new PagedResult<Customer>(customers, pageNo, pageSize, totalItemCount);
        }
    }
}