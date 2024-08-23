using FirebaseAdmin.Auth;

namespace GameplanAPI.Common.Middleware
{
    public sealed class AuthMiddleware(RequestDelegate next)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            var authHeader = httpContext.Request.Headers.Authorization.ToString();

            if (!string.IsNullOrEmpty(authHeader) && authHeader.StartsWith("Bearer "))
            {
                var idToken = authHeader.Substring("Bearer ".Length).Trim();

                try
                {
                    var decodedToken = await FirebaseAuth.DefaultInstance.VerifyIdTokenAsync(idToken);

                    if (decodedToken != null)
                    {
                        httpContext.Items["UserId"] = decodedToken.Uid;
                    }
                }
                catch (FirebaseAuthException)
                {
                    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await httpContext.Response.WriteAsync("Unauthorized: Invalid or expired token");
                    return;
                }
            }

            await next(httpContext);
        }
    }
}
