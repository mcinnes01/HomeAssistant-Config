using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace NetDaemonApps.Extensions;

public static class EnumExtensions
{
    public static string? GetDescription(this Enum enumeration)
    {
        var attr =
            enumeration
            .GetType()
            .GetMember(enumeration.ToString())
            .Where(m => m.MemberType == MemberTypes.Field)
            .FirstOrDefault()?
            .GetCustomAttribute(typeof(DescriptionAttribute), false);


        return (attr as DescriptionAttribute)?.Description;
    }

    public static string GetId(this Enum enumeration)
    {
        var s = enumeration.ToString();
        StringBuilder sb = new StringBuilder(s.Length);
        sb.Append(Char.ToLower(s[0]));

        for (int i = 1; i < s.Length; i++)
        {
            if (Char.IsLower(s[i]))
                sb.Append(s[i]);
            else
            {
                sb.Append('_');
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }

    public static E ToEnum<E>(this string value) where E : struct
    {
        string normalized = value.Replace("_", null);
        return Enum.Parse<E>(normalized, true);
    }
    
    public static InputSelectSetOptionsParameters ToOptions<T>() where T : Enum => 
    new InputSelectSetOptionsParameters
    {
        Options = string.Join(", ", Enum.GetNames(typeof(T)))
    };

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

    public static List<string> ToList<T>() where T : Enum
    => Enum.GetNames(typeof(T)).ToList();

    public static bool IsBright(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(BedroomModeOptions.Bright) ?? false;
    public static bool IsBright(this InputSelectEntity? entity)
    => entity?.EntityState?.IsBright() ?? false;

    public static bool IsCleaning(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(LightControlModeOptions.Cleaning) ?? false;
    public static bool IsCleaning(this InputSelectEntity? entity)
    => entity?.EntityState?.IsCleaning() ?? false;

    public static bool IsManual(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(BedroomModeOptions.Manual) ?? false;
    public static bool IsManual(this InputSelectEntity? entity)
    => entity?.EntityState?.IsManual() ?? false;

    public static bool IsMotion(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(LightControlModeOptions.Motion) ?? false;
    public static bool IsMotion(this InputSelectEntity? entity)
    => entity?.EntityState?.IsMotion() ?? false;

    public static bool IsMovie(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(SnugModeOptions.Movie) ?? false;
    public static bool IsMovie(this InputSelectEntity? entity)
    => entity?.EntityState?.IsMovie() ?? false;

    public static bool IsNormal(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(BedroomModeOptions.Normal) ?? false;
    public static bool IsNormal(this InputSelectEntity? entity)
    => entity?.EntityState?.IsNormal() ?? false;

    public static bool IsRelaxing(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(BedroomModeOptions.Relaxing) ?? false;
    public static bool IsRelaxing(this InputSelectEntity? entity)
    => entity?.EntityState?.IsRelaxing() ?? false;

    public static bool IsShowering(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(BathroomModeOptions.Showering) ?? false;
    public static bool IsShowering(this InputSelectEntity? entity)
    => entity?.EntityState?.IsShowering() ?? false;

    public static bool IsSleeping(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(BedroomModeOptions.Sleeping) ?? false;
    public static bool IsSleeping(this InputSelectEntity? entity)
    => entity?.EntityState?.IsSleeping() ?? false;

    public static bool IsTelevision(this EntityState<InputSelectAttributes>? state)
    => state?.IsOption(LoungeModeOptions.Television) ?? false;
    public static bool IsTelevision(this InputSelectEntity? entity)
    => entity?.EntityState?.IsTelevision() ?? false;

    public static bool Bright(this InputSelectEntity locationMode)
    => locationMode.IsOption(BedroomModeOptions.Bright);
    public static bool Cleaning(this InputSelectEntity locationMode)
    => locationMode.IsOption(LightControlModeOptions.Cleaning);
    public static void Manual(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LightControlModeOptions.Manual);
    public static bool Motion(this InputSelectEntity locationMode)
    => locationMode.IsOption(LightControlModeOptions.Motion);
    public static bool Movie(this InputSelectEntity locationMode)
    => locationMode.IsOption(SnugModeOptions.Movie);
    public static void Normal(this InputSelectEntity locationMode)
    => locationMode.SelectOption(RoomModeOptions.Normal);
    public static bool Relaxing(this InputSelectEntity locationMode)
    => locationMode.IsOption(BedroomModeOptions.Relaxing);
    public static bool Showering(this InputSelectEntity locationMode)
    => locationMode.IsOption(BathroomModeOptions.Showering);
    public static bool Sleeping(this InputSelectEntity locationMode)
    => locationMode.IsOption(BedroomModeOptions.Sleeping);
    public static void Television(this InputSelectEntity locationMode)
    => locationMode.SelectOption(LoungeModeOptions.Television);
}