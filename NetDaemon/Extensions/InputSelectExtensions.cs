namespace NetDaemon.Extensions;

public static class InputSelectExtensions
{
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
    =>target.State == @option.ToString();

    public static bool IsOption(this EntityState<InputSelectAttributes>? target, Enum @option)
    => target?.State == @option.ToString();

    public static bool IsNotOption(this InputSelectEntity target, Enum @option)
    => target.State != @option.ToString();

    public static bool IsNotOption(this EntityState<InputSelectAttributes>? target, Enum @option)
    => target?.State != @option.ToString();
    
    public static InputSelectSetOptionsParameters ToOptions<T>() where T : Enum => 
    new InputSelectSetOptionsParameters
    {
        Options = Enum.GetNames(typeof(T))
    };
        
    public static bool IsCleaning(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(LightControlModeOptions.Cleaning) ?? false;
    public static bool IsCleaning(this InputSelectEntity? entity)
    => entity?.EntityState?.IsCleaning() ?? false;
    public static bool IsManual(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(RoomModeOptions.Manual) ?? false;
    public static bool IsManual(this InputSelectEntity? entity)
    => entity?.EntityState?.IsManual() ?? false;
    public static bool IsMotion(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(LightControlModeOptions.Motion) ?? false;
    public static bool Cleaning(this InputSelectEntity entity)
    => entity.IsOption(LightControlModeOptions.Cleaning);
    public static void Manual(this InputSelectEntity entity)
    => entity.SelectOption(LightControlModeOptions.Manual);
    public static bool Motion(this InputSelectEntity enetity)
    => enetity.IsOption(LightControlModeOptions.Motion);
}