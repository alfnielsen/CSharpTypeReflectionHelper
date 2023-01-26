using System.Text.RegularExpressions;

namespace CSharpTypeReflectionHelper;

public static class StringHelperExtensions
{
    public static string ReplaceRegex(this string input, string pattern, string replacement, RegexOptions options = RegexOptions.IgnoreCase)
    {
        return Regex.Replace(input, pattern, replacement, options);
    }
}