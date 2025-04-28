using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace NetDaemon.Extensions;

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
    public static List<string> ToList<T>() where T : Enum
    => Enum.GetNames(typeof(T)).ToList();
}