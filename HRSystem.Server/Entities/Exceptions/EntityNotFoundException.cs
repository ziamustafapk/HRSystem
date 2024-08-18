namespace HRSystem.Server.Entities.Exceptions
{
    public class EntityNotFoundException : NotFoundException
    {
        public EntityNotFoundException(int id, string entity)
            : base($"{entity} with id : {id} doesn't exist in the database.")
        {
        }
    }
}
