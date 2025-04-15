namespace UserMicroservice.Domain.Exceptions;

public abstract class CustomException(string error) : Exception(error);
