using System;
using System.Collections.Generic;
using CSharpTypeReflectionHelper;

namespace Tests.common;

public abstract class TestTypeBase
{
    protected TypeTest Types(string testName, params Type[] types)
    {
        return new TypeTest(testName, types);

    }
    protected MemberTest MembersOf(string testName, Type type)
    {
        return new MemberTest(testName, type);
    }
    
    protected MemberTest MembersOf(Type type)
    {
        var testName = type.Name.ReplaceRegex(".*__",""); 
        return new MemberTest(testName, type);
    }
    
    protected PropertyTest PropertiesOf(string testName, Type type)
    {
        return new PropertyTest(testName, type);
    }

    protected PropertyTest PropertiesOf(Type type)
    {
        var testName = type.Name.ReplaceRegex(".*__", "");
        return new PropertyTest(testName, type);
    }

    protected PropertyTest PropertiesOf<T>(string testName)
    {
        return new PropertyTest(testName, typeof(T));
    }
    protected PropertyTest PropertiesOf<T>()
    {
        var testName = typeof(T).Name.ReplaceRegex(".*__","");
        return new PropertyTest(testName, typeof(T));
    }
    
}

public class TypeTest
{
    private readonly IEnumerable<Type> _types;
    private readonly string _testName;
    public TypeTest(string testName, params Type[] types)
    {
        this._types = types;
        this._testName = testName;
    }
    
    public void AllMatch<TExtension>()
    {
        IsTestAssetMethods.AllTypesMatch<TExtension>(_types, true, _testName);
    }
   
    public void AllDoNotMatch<TExtension>()
    {
        IsTestAssetMethods.AllTypesMatch<TExtension>(_types, false, _testName);
    }

}

public class MemberTest
{
    private readonly Type _type;
    private readonly string _testName;

    public MemberTest(string testName, Type type)
    {
        this._type = type;
        _testName = testName;
    }
    
    public void AllTypesMatch<TExtension>()
    {
        IsTestAssetMethods.AllDeclaredPropertyMembersTypesMatch<TExtension>(_type, true, _testName);
    }
   
    public void AllTypesDoNotMatch<TExtension>()
    {
        IsTestAssetMethods.AllDeclaredPropertyMembersTypesMatch<TExtension>(_type, false, _testName);
    }
        
    public void AllMatch<TExtension>()
    {
        IsPropertyAssetMethods.AllDeclaredPropertyMembersMatch<TExtension>(_type, true, _testName);
    }
   
    public void AllDoNotMatch<TExtension>()
    {
        IsPropertyAssetMethods.AllDeclaredPropertyMembersMatch<TExtension>(_type, false, _testName);
    }

}


public class PropertyTest
{
    private readonly Type _type;
    private readonly string _testName;

    public PropertyTest(string testName, Type type)
    {
        this._type = type;
        _testName = testName;
    }
    
    public void AllTypesMatch<TExtension>()
    {
        IsTestAssetMethods.AllPropertiesTypeMatch<TExtension>(_type, true, _testName + ".AllTypesMatch." + typeof(TExtension).Name);
    }
   
    public void AllTypesDoNotMatch<TExtension>()
    {
        IsTestAssetMethods.AllPropertiesTypeMatch<TExtension>(_type, false, _testName+ ".AllTypesDoNotMatch." + typeof(TExtension).Name);
    }
        
    public void AllMatch<TExtension>()
    {
        IsPropertyAssetMethods.AllPropertiesTypeMatch<TExtension>(_type, true, _testName +".AllMatch." + typeof(TExtension).Name);
    }
   
    public void AllDoNotMatch<TExtension>()
    {
        IsPropertyAssetMethods.AllPropertiesTypeMatch<TExtension>(_type, false, _testName+".AllDoNotMatch." + typeof(TExtension).Name);
    }
    
}



