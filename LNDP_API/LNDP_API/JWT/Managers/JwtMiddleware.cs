
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TTTAPI.JWT.Managers;
using TTTAPI.JWT.Models;

public class JwtMiddleware
{
    private readonly RequestDelegate _next;
    private IJwtService _jwtService;

    public JwtMiddleware(RequestDelegate next, IJwtService jwtService)
    {
        _next = next;
        _jwtService = jwtService;
    }

   public async Task Invoke(HttpContext context)
    {
        var authorizeAttribute = context.GetEndpoint()?.Metadata.GetMetadata<AuthorizeAttribute>();
        var allowAnonymousAttribute = context.GetEndpoint()?.Metadata.GetMetadata<AllowAnonymousAttribute>();

        if (authorizeAttribute != null && allowAnonymousAttribute == null)
        {
            // Esta acción requiere autorización, verifica el token y el rol.
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(token))
            {
                var claims = _jwtService.GetTokenClaims(token);
                var roleClaim = claims.FirstOrDefault(x => x.Type.EndsWith("/claims/role"))?.Value;
                
                if (!string.IsNullOrEmpty(roleClaim) && (roleClaim == "Admin" || roleClaim == "Crew"))
                {
                    context.Items["UserRole"] = roleClaim;
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("Forbidden");
                    return;
                }
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }
        await _next(context);
    }
}