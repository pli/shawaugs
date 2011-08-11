using System;
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewProductsInADepartment))]
    public class ViewProductsInADepartmentSpecs
    {
        public abstract class concern : Observes<IProcessAnApplicationBehaviour,
                                            ViewProductsInADepartment>
        {
        }

        public class when_processing_a_request : concern
        {
            Establish c = () =>
            {
                view_engine = depends.on<IRenderReports>();
                product_repository = depends.on<IReturnProducts>();
                products = new List<Product> { new Product() };
                department = fake.an<Department>();
                request = fake.an<IContainRequestInformation>();

                request.setup(x => x.map<Department>()).Return(department);
                product_repository.setup(x => x.get_products_of_a_department(department)).Return(products);

            };

            Because b = () =>
                sut.process(request);

            It should_pass_the_response_from_the_repository_to_the_view_engine_to_be_rendered = () =>
                view_engine.received(x => x.render(products));

            static IContainRequestInformation request;
            static IReturnProducts product_repository;
            static IRenderReports view_engine;
            static IEnumerable<Product> products;
            static Department department;
        }
    }
}