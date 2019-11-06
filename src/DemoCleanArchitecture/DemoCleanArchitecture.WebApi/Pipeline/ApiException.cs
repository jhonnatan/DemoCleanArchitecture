using System;

namespace DemoCleanArchitecture.WebApi.Pipeline
{
    public class ApiException : Exception
    {
        public int HttpStatusCode { get; set; }
        public string Title { get; }

        public ApiException(int httpStatusCode, string title, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
            Title = title;
        }

        public static ApiException NotFound(string id)
        {
            return new ApiException(404, "NotFound", "Could not find item with id " + id);
        }
    }
}
