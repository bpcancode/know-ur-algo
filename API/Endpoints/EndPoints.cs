using API.Dtos.Request;
using API.Services.Interface;

namespace API.Endpoints;

public static class EndPoints
{
    public static IEndpointRouteBuilder MapEndPoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("api/signin", async (LoginDto dto, IAuthService authService) => 
            TypedResults.Ok(await authService.LoginUser(dto)));

        endpoints.MapPost("api/signup", async (RegisterDto dto, IAuthService authService) =>
            TypedResults.Ok(await authService.RegisterAsync(dto)));

        return endpoints;
    }
}
