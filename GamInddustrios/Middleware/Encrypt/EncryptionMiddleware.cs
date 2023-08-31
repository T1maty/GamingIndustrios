namespace GamingIndustrios.Middleware.Encrypt
{
    public class EncryptionMiddleware
    {
        private readonly RequestDelegate _next;

        public EncryptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Body = EncryptStream(httpContext.Response.Body);
            httpContext.Request.Body = DecryptStream(httpContext.Request.Body);
            if (httpContext.Request.QueryString.HasValue)
            {
                string decryptedString = DecryptString(httpContext.Request.QueryString.Value.Substring(1));
                httpContext.Request.QueryString = new QueryString($"?{decryptedString}");
            }
            await _next(httpContext);
            await httpContext.Request.Body.DisposeAsync();
            await httpContext.Response.Body.DisposeAsync();
        }

        private Stream EncryptStream(Stream body)
        {
            throw new NotImplementedException();
        }

        private Stream DecryptStream(Stream body)
        {
            throw new NotImplementedException();
        }

        private string DecryptString(string decrypt)
        {
            throw new NotImplementedException();
        }
    }
}
