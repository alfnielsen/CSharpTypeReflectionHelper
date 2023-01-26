namespace CSharpTypeReflectionHelper.HelperExtensions;

public static class TypeExtensions
{
    /// Alias for typeof(T).IsAssignableFrom(source);
    public static bool IsAssignableFrom<T>(this Type source) where T : class
    {
        return typeof(T).IsAssignableFrom(source);
    }
    
    /// Alias for typeof(T).IsAssignableTo(source);
    public static bool IsAssignableTo<T>(this Type source) where T : class
    {
        return typeof(T).IsAssignableTo(source);
    }

}