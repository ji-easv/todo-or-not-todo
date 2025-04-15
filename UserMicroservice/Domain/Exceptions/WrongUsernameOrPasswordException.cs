namespace UserMicroservice.Domain.Exceptions;

public class WrongUsernameOrPasswordException(string error) : CustomException(error)
{
    public WrongUsernameOrPasswordException() : this("Wrong username or password") { }
}
