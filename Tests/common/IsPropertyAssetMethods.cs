using System.Reflection;
using CSharpTypeReflectionHelper;

namespace Tests.common;

public static class IsPropertyAssetMethods
{
    
    /// Validate all property member-type on object:
    public static void AllDeclaredPropertyMembersMatch<TExtension>(Type testObject, bool except, string testName )
    {
        bool Predicate(PropertyInfo propertyInfo) => PropertyIsExtensions.InvokeExtension(typeof(TExtension).Name, propertyInfo);
        TestAssetMethods.DeclaredPropertyMembersPropertyListAsset(testObject, except, Predicate, testName);
    }
    
    /// Validate all member on object:
    public static void AllPropertiesTypeMatch<TExtension>(Type testObject, bool except, string testName )
    {
        bool Predicate(PropertyInfo propertyInfo) => PropertyIsExtensions.InvokeExtension(typeof(TExtension).Name, propertyInfo);
        TestAssetMethods.PropertyListAsset(testObject, except, Predicate, testName);
    }

}

