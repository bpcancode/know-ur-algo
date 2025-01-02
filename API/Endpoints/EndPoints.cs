using API.Dtos.Algorithm;
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

        // User Apis
        endpoints.MapGet("api/user", () => async () => TypedResults.Ok() );

        // Visualization Apis

        endpoints.MapGet("api/visualization", () => TypedResults.Ok("Hello World"));

        // Algorithm endpoints
        endpoints.MapGet("api/algorithm", async (IAlgorithmService algorithmService) =>
            TypedResults.Ok(await algorithmService.GetAlgorithms()));

        endpoints.MapPost("api/algorithm", async (AlgorithmCreateDto dto, IAlgorithmService algorithmService) =>
            TypedResults.Ok(await algorithmService.CreateDto(dto)));

        // Tags endpoints
        endpoints.MapGet("api/tags", async (ITagService tagService) => TypedResults.Ok(await tagService.GetTags()));

        // Course endpoints
        endpoints.MapGet("api/courses", async (ICourseService courseService) => TypedResults.Ok(await courseService.GetCourses()));

        return endpoints;
    }
}
