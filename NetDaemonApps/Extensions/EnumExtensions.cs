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
}