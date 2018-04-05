using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HelloKube.Middleware{
public class LogHeadersMiddleware  
{
    private readonly RequestDelegate next;
    public static readonly List<string> RequestHeaders = new List<string>();
    public static readonly List<string> ResponseHeaders = new List<string>();

    public LogHeadersMiddleware(RequestDelegate next)
    {
        this.next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var uniqueRequestHeaders = context.Request.Headers
            .Where(x => RequestHeaders.All(r => r != x.Key))
            .Select(x => x.Key);
        RequestHeaders.AddRange(uniqueRequestHeaders);

        await this.next.Invoke(context);
        var uniqueResponseHeaders = context.Response.Headers
            .Where(x => ResponseHeaders.All(r => r != x.Key))
            .Select(x => x.Key);
        ResponseHeaders.AddRange(uniqueResponseHeaders);
    }
}    
}