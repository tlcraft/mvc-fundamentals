using System.Web.Http;

namespace OwinMiddleware
{
    public class GreetingController : ApiController
    {
        public Greeting Get()
        {
            return new Greeting { Text = "Hello Greeting!" };
        }
    }
}
