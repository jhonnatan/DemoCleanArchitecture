using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DemoCleanArchitecture.WebApi.Pipeline
{
    public static class ProblemDetailsHelper
    {
        public static void SetTraceId(ProblemDetails details, HttpContext httpContext)
        {
            // this is the same behaviour that Asp.Net core uses
            var traceId = Activity.Current?.Id ?? httpContext.TraceIdentifier;
            details.Extensions["traceId"] = traceId;
        }
    }
}
