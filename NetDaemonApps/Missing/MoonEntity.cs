namespace NetDaemonApps;

public record AMoonEntity : Entity<AMoonEntity, EntityState<AMoonAttributes>, AMoonAttributes>
{
	public AMoonEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
	{
	}

	public AMoonEntity(Entity entity) : base(entity)
	{
	}
}