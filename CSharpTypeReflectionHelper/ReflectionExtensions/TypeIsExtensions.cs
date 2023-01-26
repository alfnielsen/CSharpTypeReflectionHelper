using System.Numerics;
using System.Reflection;

namespace CSharpTypeReflectionHelper;

/// <summary>
/// All extension methods are Func<type, bool>
/// </summary>
public static class TypeIsExtensions
{
    /// Generic invoke an extension method
    public static bool InvokeExtension(string extensionName, Type type)
    {
        var method = typeof(TypeIsExtensions).GetMethod(extensionName, BindingFlags.Public | BindingFlags.Static);
        if (method is null)
        {
            throw new ArgumentException($"Extension {extensionName} not found on TypeIsExtensions");
        }
        return (bool)method.Invoke(null, new object[] { type });
    }

    /// Is a Record type? (This method can change in the future! C# do not have an official way to detect a record type)
    public static bool FuncIsRecord(Type type)
    {
        return type.GetMethods().Any(m => m.Name == "<Clone>$");
    }
    
    /// Is a Record type?
    public static bool IsRecord(this Type type)
    {
        return FuncIsRecord(type);
    }

    // Is a (class) Record type? // There is no way to detect a class record type! (At the moment)
    // public static bool FuncIsClassRecord(Type type)
    // {
    //     return type.IsClass && type.IsRecord();
    // }


    /// Is IParsable<>
    public static bool FuncIsIParsable(Type type)
    {
        return type.GetInterfaces().Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(IParsable<>));   
    }
    
    /// Is IParsable<>
    public static bool IsIParsable(this Type type)
    {
        return FuncIsIParsable(type);
    }

    /// Is INumber<>
    public static bool FuncIsINumber(Type type)
    {
        return type.GetInterfaces().Any(c => c.IsGenericType && c.GetGenericTypeDefinition() == typeof(INumber<>));   
    }
    
    /// Is INumber<>
    public static bool IsINumber(this Type type)
    {
        return FuncIsINumber(type);
    }

    /// Is the type a nullable value type
    /// Nullable value types equal to Nullable<T> where T is a value type.<br/>
    /// https://devblogs.microsoft.com/dotnet/announcing-net-6-preview-7/#libraries-reflection-apis-for-nullability-information
    public static bool FuncIsNullableValueType(Type type)
    {
        return Nullable.GetUnderlyingType(type) != null;
    }
    
    /// Is the type a nullable value type
    public static bool IsNullableValueType(this Type type)
    {
        return FuncIsNullableValueType(type);
    }

    ///  Enum is a struct is C# (Aka: A ValueType, so: TEnum? == Nullable<TEnum>)
    public static bool FuncIsNullableEnum(this Type type)
    {
        var u = Nullable.GetUnderlyingType(type);
        return (u != null) && u.IsEnum;
    }
    ///  Enum is a struct is C# (Aka: A ValueType, so: TEnum? == Nullable<TEnum>)
    public static bool IsNullableEnum(this Type type)
    {
        return FuncIsNullableEnum(type);
    }
    
    
}