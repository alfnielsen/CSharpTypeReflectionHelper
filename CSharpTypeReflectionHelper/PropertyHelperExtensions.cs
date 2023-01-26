using System.Reflection;
using System.Runtime.CompilerServices;

namespace CSharpTypeReflectionHelper;

public static class PropertyHelperExtensions
{
    
    /// <summary>
    /// Provide a Parse method for all IParseable types.
    /// This includes all primitive types, enums. (numbers and enums)
    /// </summary>
    /// <param name="s"></param>
    /// <param name="provider"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T Parse<T>(this string s, IFormatProvider? provider = null)
        where T : IParsable<T>
    {
        return T.Parse(s, provider);
    }
    
    /// <summary>
    /// Does the type implement an interface or class.
    /// Alias for typeof(T).IsAssignableFrom(source);
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static bool Implements<T>(this Type source) where T : class
    {
        return typeof(T).IsAssignableFrom(source);
    }

    // A required property has the "RequiredMemberAttribute" attribute
    // https://learn.microsoft.com/da-dk/dotnet/csharp/language-reference/proposals/csharp-11.0/required-members
    public static bool IsRequiredModifier(this PropertyInfo p)
    {
        return p.IsDefined(typeof(RequiredMemberAttribute));
    }
        
        
}