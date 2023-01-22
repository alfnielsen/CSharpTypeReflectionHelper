using System.Reflection;
using System.Runtime.CompilerServices;

// CS8618: Non-nullable field is uninitialized
// ReSharper disable InconsistentNaming // "_" in name
// ReSharper disable ConvertNullableToShortForm // Convert Nullable<T> to T?
// ReSharper disable ClassNeverInstantiated.Global

namespace CSharpTypeReflectionHelper;

public static class TypeReflectionExtension
{
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
    
    /// <summary>
    /// Is the type a nullable reference type
    /// </summary>
    /// <remarks>
    /// This is tested in the global test project<br/>
    /// Nullable reference types are enabled by default in C# 8.0 and later.<br/>
    /// https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/#libraries-reflection-apis-for-nullability-information
    /// </remarks>
    /// <param name="property"></param>
    /// <returns></returns>
    public static bool IsNullableReference(this PropertyInfo property)
    {
        var nullabilityInfo = NullabilityContext.Create(property);
        return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }
    private static readonly NullabilityInfoContext NullabilityContext = new NullabilityInfoContext();


    
    // A required property has the "RequiredMemberAttribute" attribute
    // https://learn.microsoft.com/da-dk/dotnet/csharp/language-reference/proposals/csharp-11.0/required-members
    public static bool HasRequiredModifier(this PropertyInfo p)
    {
        return p.IsDefined(typeof(RequiredMemberAttribute));
    }
    
    
    //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#833-default-constructors
    //https://stackoverflow.com/questions/27144511/how-to-check-a-type-for-parameterless-constructor
    public static bool HasDefaultConstructor(this PropertyInfo p)
    {
        var type = p.PropertyType;
        return type.IsValueType || (!type.IsAbstract && type.GetConstructor(Type.EmptyTypes) != null);
    }

}