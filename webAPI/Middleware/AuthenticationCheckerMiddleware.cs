using System.Text;

namespace webAPI.Middleware
{
    public class AuthenticationCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _relm;
        public AuthenticationCheckerMiddleware( RequestDelegate next , string relm)
        {
                this._next = next;
                this._relm = relm;   
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if(!context.Request.Headers.ContainsKey("Authorization"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");
                return;
            }
            if(!context.Request.Headers.ContainsKey("AppType"))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Header is missing");
                return;
            }
            var header = context.Request.Headers["Authorization"].ToString();
            var hed = context.Request.Headers["AppType"].ToString();
            var encodedcreds = header.Substring(6);
            var creds = Encoding.UTF8.GetString(Convert.FromBase64String(encodedcreds));
            string[] uidpwd = creds.Split(':');
            string uid = uidpwd[0];
            string password = uidpwd[1];
            if(uid != "Nasir" && password != "123")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");
                return;
            }
            if(hed != "Broker")
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("UnAuthorized");
                return;
            }
            await _next(context);
        }


    }
}
