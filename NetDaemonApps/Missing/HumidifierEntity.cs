namespace NetDaemonApps;

public record HumidifierEntity : Entity<HumidifierEntity, EntityState<HumidifierAttributes>, HumidifierAttributes>
{
	public HumidifierEntity(IHaContext haContext, string entityId) : base(haContext, entityId)
	{
	}

	public HumidifierEntity(Entity entity) : base(entity)
	{
	}
}