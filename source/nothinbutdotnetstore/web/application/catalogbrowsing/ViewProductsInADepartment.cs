using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewProductsInADepartment : IProcessAnApplicationBehaviour
    {
        IRenderReports view_engine;
        IReturnProducts product_repository;

        public ViewProductsInADepartment(): this(Stub.of<StubReportEngine>(), Stub.of<StubProductRepository>())
        {
        }

        public ViewProductsInADepartment(IRenderReports view_engine, IReturnProducts product_repository)
        {
            this.view_engine = view_engine;
            this.product_repository = product_repository;
        }

        public void process(IContainRequestInformation request)
        {
            view_engine.render(product_repository.get_products_of_a_department(request.map<Department>()));
        }
    }
}