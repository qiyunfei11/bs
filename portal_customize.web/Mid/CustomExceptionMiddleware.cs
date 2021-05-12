using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using portal_customize.web.model;

namespace portal_customize.web.Mid
{

        public class CustomExceptionMiddleware
        {
            private readonly RequestDelegate _next;
            public CustomExceptionMiddleware(RequestDelegate next)
            {
                _next = next;
            }
            public async Task Invoke(HttpContext context)
            {
                try
                {
                    context.Response.Headers.Add("access-control-allow-headers", "POST, GET, PUT, DELETE, OPTIONS");
                    context.Response.Headers.Add("access-control-allow-methods", "Authorization,Content-Type,If-Match,If-Modified-Since,If-None-Match,If-Unmodified-Since,X-Requested-With");
                    context.Response.Headers.Add("access-control-allow-origin", "https://test-oa.fmc-asia.cn");
                    context.Response.Headers.Add("access-control-expose-headers", "User-Token-Csrf");
                    context.Response.Headers.Add("cache-control", "no-store, no-cache, must-revalidate");
                    context.Response.Headers.Add("pragma", "no-cache");
                context.Response.ContentType = "application/json";
                await _next.Invoke(context);
                }
                catch (Exception ex)
                {
                    await HandleExceptionAsync(context, ex).ConfigureAwait(false);
                }
            }
            private static Task HandleExceptionAsync(HttpContext context, Exception exception)
            {
                context.Response.ContentType = "application/json";
                var statusCode = HttpStatusCode.InternalServerError;
                var result = JsonConvert.SerializeObject(new Result()
                {
                    StatusCode = statusCode,
                    ErrorMessage = exception.Message
                });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode =(int) statusCode;
                return context.Response.WriteAsync(result);
            }
        }
 }
