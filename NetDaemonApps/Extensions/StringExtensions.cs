
using System.Text;

namespace NetDaemonApps.Extensions;

internal static class StringExtensions
{
    public static string? Prettify(this string? s)
    {
        if (String.IsNullOrWhiteSpace(s))
            return s;

        StringBuilder sb = new StringBuilder(s.Length);
        sb.Append(Char.ToLower(s[0]));

        bool uppercase = false;
        foreach (var c in s)
        {
            if (Char.IsLetter(c) || Char.IsDigit(c))
            {
                sb.Append(uppercase ? Char.ToUpper(c) : c);
                uppercase = false;
            }
            else
            {
                sb.Append(' ');
                uppercase = true;
            }                        
        }

        return sb.ToString();
    }

    public static string MakeId(this string s)
    {
        s = s.Trim().ToLowerInvariant().Normalize();

        if (String.IsNullOrWhiteSpace(s))
            throw new ArgumentException("Cannot produce an unique id from an empty string");

        StringBuilder sb = new StringBuilder(s.Length);

        if (!Char.IsAscii(s[0]) && !Char.IsLetter(s[0]) && s[0] != '_')
            sb.Append('_');

        foreach(var c in s)
        {
            if (Char.IsAscii(c) && Char.IsLetter(c))
                sb.Append(c);
            else
                sb.Append('_');
        }

        return sb.ToString();
    }

}
