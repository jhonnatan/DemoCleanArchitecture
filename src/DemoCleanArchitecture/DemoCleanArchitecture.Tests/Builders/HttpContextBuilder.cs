using Microsoft.AspNetCore.Http;

namespace DemoCleanArchitecture.Tests.Builders
{
    public class HttpContextBuilder
    {
        public DefaultHttpContext HttpContext { get; set; }

        public static HttpContextBuilder New()
        {
            return new HttpContextBuilder
            {
                HttpContext = new DefaultHttpContext
                {
                    User = ClaimBuilder.New().Build()
                }
            };
        }

        public DefaultHttpContext Build()
        {
            return HttpContext;
        }
    }
}
