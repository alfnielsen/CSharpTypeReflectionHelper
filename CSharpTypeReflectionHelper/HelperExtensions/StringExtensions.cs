using System.Text.RegularExpressions;

namespace CSharpTypeReflectionHelper.HelperExtensions;

public static class StringExtensions
{
    /// Provide a Parse method for all IParseable types.
    /// This includes all primitive types, enums. (numbers and enums)
    public static T Parse<T>(this string s, IFormatProvider? provider = null)
        where T : IParsable<T>
    {
        return T.Parse(s, provider);
    }
    
    /// Provide string replace with regex pattern.
    public static string ReplaceRegExp(this string input, string pattern, string replacement, RegexOptions options = RegexOptions.IgnoreCase)
    {
        return Regex.Replace(input, pattern, replacement, options);
    }
        
    /// Provide string match with regex pattern.
    public static bool MatchRegExp(this string input, string pattern, RegexOptions options = RegexOptions.IgnoreCase)
    {
        return Regex.IsMatch(input, pattern, options);
    }

}