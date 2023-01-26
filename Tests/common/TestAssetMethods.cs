using System.Reflection;
using CSharpTypeReflectionHelper;

namespace Tests.common;


public static class TestAssetMethods
{
    
    /// Validate all member on object: (Used on static classes)
    public static void DeclaredPropertyMembersPropertyListAsset(Type testObject, bool except, Func<PropertyInfo, bool> predicate, string testName )
    {
        var members = testObject.GetDeclaredPropertyMembers();
        NamedListAsset(members, except, predicate, testName);
    }
    
    /// Validate all properties on object:
    public static void PropertyListAsset(Type testObject, bool except, Func<PropertyInfo, bool> predicate, string testName )
    {
        var properties = testObject.GetProperties();
        NamedListAsset(properties, except, predicate, testName);
    }    
    
    /// Validate all properties on object:
    public static void TypeListAsset(IEnumerable<Type> typeList, bool except, Func<Type, bool> predicate, string testName )
    {
        NamedListAsset(typeList, except, predicate, testName);
    }
    
    // --------------- Lowest level ---------------
    public static void NamedListAsset<TResult>(
        IEnumerable<PropertyInfo> types, 
        TResult except, 
        Func<PropertyInfo, TResult> predicate, 
        string testName,
        string? objectName = null
    )
    {
        var oName = objectName?.ReplaceRegex(".*__",".") ?? string.Empty;
        ListAsset(types, except, predicate, (index, name, result) => $"{testName}[{index}]: Validation for {oName}{name} excepted {except} but was {result}.");
    }    
    /// Take a list of types to validate:
    public static void ListAsset<TResult>(
        IEnumerable<PropertyInfo> items, 
        TResult except, 
        Func<PropertyInfo, TResult> validatePredicate, 
        Func<int, string, TResult, string>? failureMsgPredicate = null
    )
    {
        var index = 0;
        foreach (var item in items)
        {
            var result = validatePredicate(item);
            var itemName = item.Name.ReplaceRegex(".*__","") ?? "NoName";
            var msg = failureMsgPredicate?.Invoke(index, itemName, result) ?? $"[{index}] Validation for {itemName} excepted {except} but was {result}.";
            Assert.That(result, Is.EqualTo(except), msg);
            index++;
        }
    }

    public static void NamedListAsset<T, TResult>(
        IEnumerable<T> types, 
        TResult except, 
        Func<T, TResult> predicate, 
        string testName,
        string? objectName = null
    )
    {
        var oName = objectName?.ReplaceRegex(".*__",".") ?? string.Empty;
        ListAsset(types, except, predicate, (index, name, result) => $"{testName}[{index}]: Validation for {oName}{name} excepted {except} but was {result}.");
    }    
    /// Take a list of types to validate:
    public static void ListAsset<T, TResult>(
        IEnumerable<T> items, 
        TResult except, 
        Func<T, TResult> validatePredicate, 
        Func<int, string, TResult, string>? failureMsgPredicate = null
    )
    {
        var index = 0;
        foreach (var item in items)
        {
            var result = validatePredicate(item);
            var itemName = item?.GetType().Name.ReplaceRegex(".*__","") ?? "NoName";
            var msg = failureMsgPredicate?.Invoke(index, itemName, result) ?? $"[{index}] Validation for {itemName} excepted {except} but was {result}.";
            Assert.That(result, Is.EqualTo(except), msg);
            index++;
        }
    }

    
}

