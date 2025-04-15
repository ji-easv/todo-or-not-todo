using Microsoft.AspNetCore.Identity.Data;
using Shared.Responses;

namespace UserMicroservice.Application.Services.Interfaces;

public interface IUserService
{
    /// <summary>
    /// Authenticates a user based on the provided login request.
    /// </summary>
    /// <param name="request">The login request containing user credentials.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="AuthResponse"/> with authentication details.</returns>
    Task<AuthResponse> Authenticate(LoginRequest request);

    /// <summary>
    /// Registers a new user based on the provided registration request.
    /// </summary>
    /// <param name="request">The registration request containing user details and credentials.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains an <see cref="AuthResponse"/> with authentication details for the newly registered user.</returns>
    Task<AuthResponse> Register(RegisterRequest request);
}