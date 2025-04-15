using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Shared.Responses;
using UserMicroservice.Application.Services.Interfaces;
using UserMicroservice.Domain.Entities;
using UserMicroservice.Domain.Exceptions;

namespace UserMicroservice.Application.Services;

public class UserService(IJwtService jwtService, UserManager<ApplicationUser> userManager)
    : IUserService
{
    public async Task<AuthResponse> Authenticate(LoginRequest request)
    {
        if (string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            throw new WrongUsernameOrPasswordException();
        }

        var user = await userManager.FindByEmailAsync(request.Email);
        if (user == null)
        {
            throw new WrongUsernameOrPasswordException();
        }

        var result = await userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            throw new WrongUsernameOrPasswordException();
        }

        var roles = await userManager.GetRolesAsync(user);
        var token = jwtService.GenerateJwtToken(user, roles, null);

        return new AuthResponse()
        {
            Email = user.Email!,
            UserId = user.Id,
            Token = token
        };
    }

    public async Task<AuthResponse> Register(RegisterRequest request)
    {
        var user = new ApplicationUser()
        {
            Email = request.Email,
            UserName = request.Email,
        };
        var result = await userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
        {
            throw new RegistrationException(result.Errors.ToList());
        }

        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
        await userManager.ConfirmEmailAsync(user, token);

        return await Authenticate(new LoginRequest()
        {
            Email = request.Email,
            Password = request.Password,
        });
    }
    
}