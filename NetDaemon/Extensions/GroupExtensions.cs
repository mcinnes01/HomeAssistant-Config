
namespace NetDaemon.Extensions;

public static class GroupExtensions
{
    public static bool IsGroup(this Entity? entity)
        => entity?.WithAttributesAs<Models.GroupAttributes>().Attributes?.EntityIds?.Any() ?? false;

    public static IEnumerable<Entity> GetMembers(this Entity entity, bool recursive = true)
    {
        var ids = entity?.WithAttributesAs<Models.GroupAttributes>().Attributes?.EntityIds;            
        if (entity?.HaContext == null)
            throw new ArgumentNullException(nameof(entity));

        if (!recursive)
            return ids?.Select(id => new Entity(entity.HaContext, id)) ?? Enumerable.Empty<Entity>();

        if (!(ids?.Any() ?? false))
            return Enumerable.Empty<Entity>();

        var entities = new HashSet<Entity>();            

        foreach (var id in ids)
        {
            var member = new Entity(entity.HaContext, id);
            if (recursive && member.IsGroup())
            {
                var innerEntities = member.GetMembers(true);
                foreach (var innerEntity in innerEntities)
                    entities.Add(innerEntity);
            }
            else
                entities.Add(member);
        }

        return entities;
    }
}

