using Microsoft.AspNetCore.Identity;

namespace UserMicroservice.Domain.Exceptions;

public class RegistrationException(string error) : CustomException(error)
{
    public List<IdentityError> IdentityErrors { get; set; } = new();

    public RegistrationException(List<IdentityError> identityErrors) : this("Registration failed")
    {
        IdentityErrors = identityErrors;
    }
}