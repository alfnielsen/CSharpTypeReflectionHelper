using System.Reflection;
using System.Runtime.CompilerServices;

namespace CSharpTypeReflectionHelper;

public static class PropertyIsExtensions
{
    // Do not work for generic methods!
    public static bool InvokeExtension(string extensionName, PropertyInfo propertyInfo)
    {
        var method = typeof(PropertyIsExtensions).GetMethod(extensionName, BindingFlags.Public | BindingFlags.Static);
        if (method is null)
        {
            throw new ArgumentException($"Extension {extensionName} not found on PropertyIsExtensions");
        }
        return (bool)method.Invoke(null, new object[] { propertyInfo });
    }
    
    /// Is a Record type?
    public static bool IsRecord(this PropertyInfo propertyInfo)
    {
        return propertyInfo.PropertyType.IsRecord();
    }
    
    /// Is a type IsIParsable?
    public static bool IsIParsable(this PropertyInfo propertyInfo)
    {
        return propertyInfo.PropertyType.IsIParsable();
    }

    /// Is a type IsINumber?
    public static bool IsINumber(this PropertyInfo propertyInfo)
    {
        return propertyInfo.PropertyType.IsINumber();
    }

    /// Alias for typeof(T).IsAssignableFrom(source);
    public static bool IsAssignableFrom<T>(this Type source) where T : class
    {
        return typeof(T).IsAssignableFrom(source);
    }
    /// Alias for typeof(T).IsAssignableFrom(source);
    public static bool IsAssignableTo<T>(this Type source) where T : class
    {
        return typeof(T).IsAssignableTo(source);
    }

    /// Is the type a nullable reference type
    /// This is tested in the global test project<br/>
    /// Nullable reference types are enabled by default in C# 8.0 and later.<br/>
    /// https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/#libraries-reflection-apis-for-nullability-information
    public static bool IsNullableReference(this PropertyInfo property)
    {
        var nullabilityInfo = NullabilityContext.Create(property);
        return nullabilityInfo.WriteState is NullabilityState.Nullable;
    }
    private static readonly NullabilityInfoContext NullabilityContext = new NullabilityInfoContext();
    
    /// Is the type a nullable value type
    /// Nullable value types equal to Nullable&lt;T&gt; where T is a value type.<br/>
    /// https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/#libraries-reflection-apis-for-nullability-information
    public static bool IsNullableValueType(this PropertyInfo property)
    {
        return property.PropertyType.IsValueType && Nullable.GetUnderlyingType(property.PropertyType) != null;
    }

    /// Is Enum? (nullable enum)
    /// Enum is a struct is C# (Aka: A ValueType, so: TEnum? == Nullable<TEnum>)
    public static bool IsNullableEnum(this PropertyInfo property)
    {
        return property.PropertyType.IsNullableEnum();
    }

    /// Is Enum ro Enum? (enum and nullable enum)
    /// Enum is a struct is C# (Aka: A ValueType, so: TEnum? == Nullable<TEnum>)
    public static bool IsEnumOrNullableEnum(this PropertyInfo property)
    {
        return property.PropertyType.IsNullableEnum() || property.PropertyType.IsEnum;
    }
    
    /// Is Enum (NOT nullable enum)
    public static bool IsEnum(this PropertyInfo property)
    {
        return property.PropertyType.IsEnum;
    }
    
    
    /// Is property declared virtual
    public static bool IsVirtual(this PropertyInfo propertyInfo)
    {
        return propertyInfo.GetAccessors().Any(x => x.IsVirtual);
    }

    // Is property declared required
    // (In C# syntax it's a required accibility modifier)
    // A required property has the "RequiredMemberAttribute" attribute
    // https://learn.microsoft.com/da-dk/dotnet/csharp/language-reference/proposals/csharp-11.0/required-members
    public static bool IsRequired(this PropertyInfo p)
    {
        return p.IsDefined(typeof(RequiredMemberAttribute));
    }
        
        
}