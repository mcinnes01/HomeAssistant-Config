namespace NetDaemon.Extensions;


public static class ContextExtensions
{
    public static IEnumerable<PersonEntity> GetFamily(this IHaContext context)
        => context.GetAllEntities()
        .Where(e => e.EntityId.StartsWith("person."))
        .Where(e => !e.EntityId.StartsWith("person.guest"))
        .Select(e => new PersonEntity(e));

    public static IEnumerable<PersonEntity> GetGuests(this IHaContext context)
        => context.GetAllEntities()
        .Where(e => e.EntityId.StartsWith("person.guest"))
        .Select(e => new PersonEntity(e));

    public static IEnumerable<InputSelectEntity> GetPersonStates(this IHaContext context)
        => context.GetAllEntities()
        .Where(e => e.EntityId.StartsWith("person.guest"))
        .Select(e => new InputSelectEntity(e));

    public static string? GetEntityId(this IHaContext context, string entity)
        => context.GetAllEntities()
        .Select(e => e.EntityId)
        .FirstOrDefault(e => e == entity);
}