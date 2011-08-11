using System;
using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.application.stubs
{
    public class StubProductRepository : IReturnProducts

    {
        public IEnumerable<Product> get_products_of_a_department(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Product { Name = x.ToString("Product 0"), Description = x.ToString("Description 0"), Price = x});
        }
    }
}