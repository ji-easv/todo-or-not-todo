using UserMicroservice.Domain.Entities;

namespace UserMicroservice.Application.Services.Interfaces;

public interface IJwtService
{
    string GenerateJwtToken(ApplicationUser user, IEnumerable<string> roles, IDictionary<string, dynamic>? customClaims, Guid? tenantId = null);
}
