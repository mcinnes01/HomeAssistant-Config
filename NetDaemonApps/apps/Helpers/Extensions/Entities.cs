namespace Helpers.Extensions;

public static class EntityExtensions
{
    public static Entities MyEntities(this IHaContext ha) => new (ha);
    public static Services Services(this IHaContext ha) => new (ha);
  
    public static bool IsOpen(this BinarySensorEntity? entity) => entity.IsOn();
    public static bool IsClosed(this BinarySensorEntity? entity) => entity.IsOff();
    public static bool IsOpen(this EntityState? entity) => entity.IsOn();
    public static bool IsClosed(this EntityState? entity) => entity.IsOff();

    public static void SwitchTo(this SwitchEntity? heaterSwitch, string? newState)
    {
        if (heaterSwitch?.State != newState)
        {
            if (newState == "on")
            {
                heaterSwitch?.TurnOn();
            }
            else
            {
                heaterSwitch?.TurnOff();
            }
        }
    }

    public static IDisposable WhenTurnsOn<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
        => entity.StateChanges().Where(c => (c.Old?.IsOff() ?? false) && (c.New?.IsOn() ?? false)).Subscribe(action);

    public static IDisposable WhenTurnsOff<TEntity, TAttributes>(this Entity<TEntity, EntityState<TAttributes>, TAttributes> entity,
        Action<StateChange<TEntity, EntityState<TAttributes>>> action)
        where TAttributes : class
        where TEntity : Entity<TEntity, EntityState<TAttributes>, TAttributes>
        => entity.StateChanges().Where(c => (c.Old?.IsOn() ?? false) && (c.New?.IsOff() ?? false)).Subscribe(action);

    public static void SelectOption<T>(this InputSelectEntity target, T @option)
        where T : Enum
    {
        if(string.IsNullOrEmpty(option.ToString()))
            throw new NullReferenceException();

        // if (!nameof(T).Contains(nameof(target)))
        //     throw new ArrayTypeMismatchException();

        target.SelectOption(option.ToString());
    }

    public static T AsOption<T>(this InputSelectEntity? target)
        where T : struct
    {
        try   
        {   
            if(string.IsNullOrEmpty(target?.State))
                throw new NullReferenceException();

            T option = (T)Enum.Parse(typeof(T), target.State);   
            if (!Enum.IsDefined(typeof(T), option))
                throw new ArgumentOutOfRangeException($"Value: {target.State} not found for type: {nameof(T)}");
  
            return option;   
        }   
        catch 
        {   
            throw;
        }  
    }

    public static T AsOption<T>(this EntityState<InputSelectAttributes> target)
        where T : struct
    {
        try   
        {   
            if(string.IsNullOrEmpty(target?.State))
                throw new NullReferenceException();

            T option = (T)Enum.Parse(typeof(T), target.State);   
            if (!Enum.IsDefined(typeof(T), option))
                throw new ArgumentOutOfRangeException($"Value: {target.State} not found for type: {nameof(T)}");
  
            return option;
        }   
        catch 
        {   
            throw;
        }  
    }

    public static bool IsOption(this InputSelectEntity target, Enum @option)
    {
        return target.State == @option.ToString();
    }

    public static bool IsNotOption(this InputSelectEntity target, Enum @option)
    {
        return target.State != @option.ToString();
    }

    public static bool IsOption(this EntityState<InputSelectAttributes>? target, Enum @option)
    {
        return target?.State == @option.ToString();
    }

    public static bool IsNotOption(this EntityState<InputSelectAttributes>? target, Enum @option)
    {
        return target?.State != @option.ToString();
    }
    
    public static bool IsHome(this PersonEntity? entity) => entity?.State == "home";
}