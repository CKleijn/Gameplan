namespace GameplanAPI.Shared.Abstractions.Handling
{
    public static class Errors<TEntity> where TEntity : Entity
    {
        public static Error NotFound(Guid id) => new($"{typeof(TEntity).Name}.NotFound", $"The {typeof(TEntity).Name} with GUID '{id}' was not found");
        public static readonly Error AlreadyExists = new($"{typeof(TEntity).Name}.AlreadyExists", $"This {typeof(TEntity).Name} already exists");
    }
}
