using System.Reflection;
using CSharpTypeReflectionHelper;

namespace Tests.common;

public static class IsTestAssetMethods
{
    
    /// Validate all property member-type on object:
    public static void AllDeclaredPropertyMembersTypesMatch<TExtension>(Type testObject, bool except, string testName )
    {
        bool Predicate(PropertyInfo member) => TypeIsExtensions.InvokeExtension(typeof(TExtension).Name, member.PropertyType);
        TestAssetMethods.DeclaredPropertyMembersPropertyListAsset(testObject, except, Predicate, testName);
    }
    
    /// Validate all member on object:
    public static void AllPropertiesTypeMatch<TExtension>(Type testObject, bool except, string testName )
    {
        bool Predicate(PropertyInfo property) => TypeIsExtensions.InvokeExtension(typeof(TExtension).Name, property.PropertyType);
        TestAssetMethods.PropertyListAsset(testObject, except, Predicate, testName);
    }
    
    /// Validate all member on object:
    public static void AllTypesMatch<TExtension>(IEnumerable<Type> types, bool except, string testName )
    {
        bool Predicate(Type type) => TypeIsExtensions.InvokeExtension(typeof(TExtension).Name, type);
        TestAssetMethods.TypeListAsset(types, except, Predicate, testName);
    }

}

