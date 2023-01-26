using System.Reflection;

namespace CSharpTypeReflectionHelper.HelperExtensions;

public static class MemberExtensions
{
    public static IEnumerable<MemberInfo> GetDeclaredMembers(this Type type) => type.GetTypeInfo().DeclaredMembers;
    
    public static Type? GetUnderlyingType(this MemberInfo member)
    {
        return member.MemberType switch
        {
            MemberTypes.Event => ((EventInfo) member).EventHandlerType,
            MemberTypes.Field => ((FieldInfo) member).FieldType,
            MemberTypes.Method => ((MethodInfo) member).ReturnType,
            MemberTypes.Property => ((PropertyInfo) member).PropertyType,
            _ => throw new ArgumentException(
                "Input MemberInfo must be if type EventInfo, FieldInfo, MethodInfo, or PropertyInfo")
        };
    }
    
    public static IEnumerable<PropertyInfo> GetPropertyMembers(this IEnumerable<MemberInfo> list)
    {
        return list.Where(x => x.MemberType == MemberTypes.Property)
            .Select(x => (PropertyInfo) x);
    }
    
    public static IEnumerable<PropertyInfo> GetDeclaredPropertyMembers(this Type type)
        => type.GetDeclaredMembers().GetPropertyMembers();


}