using System.Web;

namespace nothinbutdotnetstore.web.core
{
    public class RawHandler : IHttpHandler
    {
        IProcessWebRequests front_controller;
        ICreateRequestsTheFrontControllerCanProcess request_mapper;

        public RawHandler(IProcessWebRequests front_controller, ICreateRequestsTheFrontControllerCanProcess request_mapper)
        {
            this.front_controller = front_controller;
            this.request_mapper = request_mapper;
        }

        public void ProcessRequest(HttpContext context)
        {
            var mappedContext = request_mapper.map_from(context);
            front_controller.process(mappedContext);
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}