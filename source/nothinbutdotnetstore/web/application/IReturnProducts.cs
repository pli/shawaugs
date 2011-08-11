using System.Collections.Generic;

namespace nothinbutdotnetstore.web.application
{
    public interface IReturnProducts
    {
        IEnumerable<Product> get_products_of_a_department(Department department);
    }
}