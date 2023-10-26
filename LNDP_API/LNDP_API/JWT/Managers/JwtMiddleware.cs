
using System.Security.Claims;
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
        var path = context.Request.Path.ToString().ToLower();
        var authorizeAttribute = context.GetEndpoint()?.Metadata.GetMetadata<AuthorizeAttribute>();
        var allowAnonymousAttribute = context.GetEndpoint()?.Metadata.GetMetadata<AllowAnonymousAttribute>();

        if (authorizeAttribute != null && allowAnonymousAttribute == null)
        {
            // Esta acción requiere autorización, verifica el token y el rol.
            var authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                var token = authorizationHeader.Split(" ").Last();
                var validToken = _jwtService.GetValidToken(token);
                if (validToken == null)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorizated");
                    return;
                }
                var claims = validToken.Claims;
                context.Items["UserId"] = int.Parse(claims.First(x => x.Type == "userId").Value);
                var roleClaim = claims.FirstOrDefault(x => x.Type.EndsWith("/claims/role"))?.Value;
                bool isMethodValid;
                switch (roleClaim)
                {
                    case "Admin":
                        isMethodValid = RoutesManager.IsAdminRoute(path, context.Request.Method);
                        break;
                    case "Visual":
                        isMethodValid = RoutesManager.IsVisualRoute(path, context.Request.Method);
                        break;
                    case "Crew":
                        isMethodValid = RoutesManager.IsCrewRoute(path, context.Request.Method);
                        break;
                    default:
                        isMethodValid = false;
                        break;
                }
                if (!isMethodValid)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Unauthorized");
                    return;
                }
                context.Items["UserRole"] = roleClaim;
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                await context.Response.WriteAsync("Unauthorized");
                return;
            }
        }
        await _next(context);
    }
}