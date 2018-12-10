using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.Api.Middleware
{
    public class UserKeyValidators
    {
        private readonly RequestDelegate _next;

        public UserKeyValidators(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (!context.Request.Headers.Keys.Contains("user-key"))
            {
                context.Response.StatusCode = 400; //Bad Request                
                await context.Response.WriteAsync("User Key is missing");
                return;
            }
            else
            {
                var userkeyList = new List<string>{"arshad","asjad"};
                if (!userkeyList.Contains(context.Request.Headers["user-key"]))
                {
                    context.Response.StatusCode = 401; //UnAuthorized

                    await context.Response.WriteAsync("Invalid User Key");
                    return;
                }
            }

            await _next.Invoke(context);
        }
    }

    #region ExtensionMethod
    public static class UserKeyValidatorsExtension
    {
        public static IApplicationBuilder ApplyUserKeyValidation(this IApplicationBuilder app)
        {
            app.UseMiddleware<UserKeyValidators>();
            return app;
        }
    }
    #endregion
}
