using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Shared.Responses;
using UserMicroservice.Application.Services.Interfaces;
using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Presentation.Apis;

public static class AuthApi
{
    public static RouteGroupBuilder AddAuthApi(this IEndpointRouteBuilder app)
    {
        var api = app.MapGroup("/Auth");

        api.MapPost("/Login", Login)
            .WithName("Login")
            .AllowAnonymous();

        api.MapPost("/Register", Register)
            .WithName("Register")
            .AllowAnonymous();

        return api;
    }

    public static async Task<Results<Ok<AuthResponse>, ProblemHttpResult>> Login(
        IUserService userService,
        [FromBody] LoginRequest request)
    {
        var authResponse = await userService.Authenticate(request);

        return TypedResults.Ok(authResponse);
    }

    public static async Task<Results<Ok, ProblemHttpResult>> Register(
        UserManager<ApplicationUser> userManager,
        [FromBody] RegisterRequest request)
    {
        throw new NotImplementedException();


        return TypedResults.Ok();
    }
}