namespace HRSystem.Server.Entities.Exceptions;

public class AlreadyExistException : Exception
{
    public AlreadyExistException(string entity)
        : base($"{entity} already exist in the database.")
    {
    }
}