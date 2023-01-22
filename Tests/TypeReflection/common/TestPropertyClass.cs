// CS8618: Non-nullable field is uninitialized
// ReSharper disable InconsistentNaming // "_" in name
// ReSharper disable ConvertNullableToShortForm // Convert Nullable<T> to T?
// ReSharper disable ClassNeverInstantiated.Global

#pragma warning disable CS8618 
namespace Tests.TypeReflection.common;

public enum TestEnum { A, B, C }

public class TestClassNoDefaultCtor
{
    public TestClassNoDefaultCtor(int i) { }
}
public class TestClassDefaultCtor
{
    public TestClassDefaultCtor() { }
}
public class TestClassNoCtor
{
}

/// <summary>
/// Base Info: (See microsoft docs)
///
/// C# Class Type:
///  - System.Object            The ultimate base class of all other types.
///  - System.String            The string type of the C# language.
///  - System.ValueType         The base class of all value types.
///  - System.Enum              The base class of all enum types.
///  - System.Array             The base class of all array types.
///  - System.Delegate          The base class of all delegate types.
///  - System.Exception         The base class of all exception types.
///
/// Value Type:
///  - All ValueType's have a default constructor
/// 
/// C# built-in value types (C# 'keywords' value types also called "simple types" - other value types exists!):
///    'sbyte', 'byte', 'short', 'ushort', 'int', 'uint', 'long', 'ulong', 'char', 'float', 'double', 'bool', 'decimal'
///
/// Nullable value types: (Not the same a nullable reference types)
///  - All nullable value types inherits from: System.Nullable<T>
///
/// Reference Type:
/// C# built-in reference types (C# 'keywords' value types - other reference types exists!):
///    'dynamic', 'object', 'string'
/// Noticeable other reference types:
///    'class_type', 'array_type'
///
/// Nullability of types: (There are some differences between Nullable value types and Nullable reference types)
/// There are 3 nullability types:
///    'oblivious', 'nonnullable', 'nullable'
/// Important notes: (EF core still uses oblivious nullability)
///  - "An unannotated reference type C in a disabled annotation context is oblivious"
///  - "An unannotated reference type C in an enabled annotation context is nonnullable"
/// 
/// 
/// <see cref="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-specification/types#83-value-types"/>
/// <see cref="https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/proposals/csharp-9.0/nullable-reference-types-specification"/>
/// </summary>
public class TestPropertyClass
{
    
    /**
     * Name parts: [0] is the name of the property
     *  - boxed
     *  - refType
     *  - valueType
     *  - defaultConstructor
     *  - required
     *  - nullableMark (uses "?")
     *  - systemNullable (uses "System.Nullable")
     */
    
    // simple value types
    public bool     bool_valueType_defaultConstructor     {set;get;}
    public decimal  decimal_valueType_defaultConstructor  {set;get;}
    public sbyte    sbyte_valueType_defaultConstructor    {set;get;}
    public byte     byte_valueType_defaultConstructor     {set;get;}
    public short    short_valueType_defaultConstructor    {set;get;}
    public ushort   ushort_valueType_defaultConstructor   {set;get;}
    public int      int_valueType_defaultConstructor      {set;get;}
    public uint     uint_valueType_defaultConstructor     {set;get;}
    public long     long_valueType_defaultConstructor     {set;get;}
    public ulong    ulong_valueType_defaultConstructor    {set;get;}
    public char     char_valueType_defaultConstructor     {set;get;}
    public float    float_valueType_defaultConstructor    {set;get;}
    public double   double_valueType_defaultConstructor   {set;get;}
   
    // boxed simple value types (Not all are listed - some of the boxed types are deprecated)
    public Boolean  Boolean_boxed_valueType_defaultConstructor  {set;get;} // Boxed types are value types!
    public Decimal  Decimal_boxed_valueType_defaultConstructor  {set;get;} // Boxed types are value types!
    public SByte    Sbyte_boxed_valueType_defaultConstructor    {set;get;} // Boxed types are value types!
    public Byte     Byte_boxed_valueType_defaultConstructor     {set;get;} // Boxed types are value types!
    public Char     Char_boxed_valueType_defaultConstructor     {set;get;} // Boxed types are value types!
    public Double   Double_boxed_valueType_defaultConstructor   {set;get;} // Boxed types are value types!
    public Guid     Guid_valueType_defaultConstructor           {set;get;} // Guid is internally structs 
    public DateTime DateTime_valueType_defaultConstructor       {set;get;} // DateTime is internally a struct
    
    // reference type (Not all are listed!)
    public string   string_refType_type                   {set;get;}

    // boxed reference type (Not all are listed!)
    public String   String_refType                        {set;get;}
    
    // Custom value type
    public TestEnum enum_valueType_customType_defaultConstructor     {set;get;}
    
    // Custom reference type
    public TestClassNoDefaultCtor TestClassNoDefaultCtor_refType_customType {set;get;}
    public TestClassDefaultCtor TestClassDefaultCtor_refType_customType_defaultConstructor {set;get;}
    public TestClassNoCtor TestClassNoCtor_refType_customType_defaultConstructor {set;get;}
    
    // ----------------- Nullable mark version -----------------
    
    // simple value types
    public bool?     bool_valueType_defaultConstructor_nullableMark     {set;get;}
    public decimal?  decimal_valueType_defaultConstructor_nullableMark  {set;get;}
    public sbyte?    sbyte_valueType_defaultConstructor_nullableMark    {set;get;}
    public byte?     byte_valueType_defaultConstructor_nullableMark     {set;get;}
    public short?    short_valueType_defaultConstructor_nullableMark    {set;get;}
    public ushort?   ushort_valueType_defaultConstructor_nullableMark   {set;get;}
    public int?      int_valueType_defaultConstructor_nullableMark      {set;get;}
    public uint?     uint_valueType_defaultConstructor_nullableMark     {set;get;}
    public long?     long_valueType_defaultConstructor_nullableMark     {set;get;}
    public ulong?    ulong_valueType_defaultConstructor_nullableMark    {set;get;}
    public char?     char_valueType_defaultConstructor_nullableMark     {set;get;}
    public float?    float_valueType_defaultConstructor_nullableMark    {set;get;}
    public double?   double_valueType_defaultConstructor_nullableMark   {set;get;}
   
    // boxed simple value types (Not all are listed - some of the boxed types are deprecated)
    public Boolean?  Boolean_boxed_valueType_defaultConstructor_nullableMark  {set;get;} // Boxed types are value types!
    public Decimal?  Decimal_boxed_valueType_defaultConstructor_nullableMark  {set;get;} // Boxed types are value types!
    public SByte?    Sbyte_boxed_valueType_defaultConstructor_nullableMark    {set;get;} // Boxed types are value types!
    public Byte?     Byte_boxed_valueType_defaultConstructor_nullableMark     {set;get;} // Boxed types are value types!
    public Char?     Char_boxed_valueType_defaultConstructor_nullableMark     {set;get;} // Boxed types are value types!
    public Double?   Double_boxed_valueType_defaultConstructor_nullableMark   {set;get;} // Boxed types are value types!
    public Guid?     Guid_valueType_defaultConstructor_nullableMark       {set;get;}
    public DateTime? DateTime_valueType_defaultConstructor_nullableMark   {set;get;}
    
    // reference type (Not all are listed!)
    public string?   string_refType_type_nullableMark                   {set;get;}

    // boxed reference type (Not all are listed!)
    public String?   String_refType_nullableMark     {set;get;}
    
    // Custom value type
    public TestEnum? enum_valueType_customType_defaultConstructor_nullableMark     {set;get;}
    
    // Custom reference type
    public TestClassNoDefaultCtor? TestClassNoDefaultCtor_refType_customType_nullableMark {set;get;}
    public TestClassDefaultCtor? TestClassDefaultCtor_refType_customType_defaultConstructor_nullableMark {set;get;}
    public TestClassNoCtor? TestClassNoCtor_refType_customType_defaultConstructor_nullableMark {set;get;}
    

    
    // ----------------- System.Nullable version -----------------
    // (Some are commented due to compiler: "Only non-nullable value type could be underlying of 'System.Nullable'")
    
    // simple value types
    public Nullable<bool>     bool_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<decimal>  decimal_valueType_defaultConstructor_systemNullable_nullableMark  {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<sbyte>    sbyte_valueType_defaultConstructor_systemNullable_nullableMark    {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<byte>     byte_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<short>    short_valueType_defaultConstructor_systemNullable_nullableMark    {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<ushort>   ushort_valueType_defaultConstructor_systemNullable_nullableMark   {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<int>      int_valueType_defaultConstructor_systemNullable_nullableMark      {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<uint>     uint_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<long>     long_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<ulong>    ulong_valueType_defaultConstructor_systemNullable_nullableMark    {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<char>     char_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<float>    float_valueType_defaultConstructor_systemNullable_nullableMark    {set;get;} // For simple types type? is Nullable<type> (See docs)
    public Nullable<double>   double_valueType_defaultConstructor_systemNullable_nullableMark   {set;get;} // For simple types type? is Nullable<type> (See docs)
   
    // boxed simple value types (Not all are listed - some of the boxed types are deprecated)
    public Nullable<Boolean>  Boolean_boxed_valueType_defaultConstructor_systemNullable_nullableMark  {set;get;} // Boxed types are value types! // For simple types type? is Nullable<type> (See docs) 
    public Nullable<Decimal>  Decimal_boxed_valueType_defaultConstructor_systemNullable_nullableMark  {set;get;} // Boxed types are value types! // For simple types type? is Nullable<type> (See docs)
    public Nullable<SByte>    Sbyte_boxed_valueType_defaultConstructor_systemNullable_nullableMark    {set;get;} // Boxed types are value types! // For simple types type? is Nullable<type> (See docs)
    public Nullable<Byte>     Byte_boxed_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // Boxed types are value types! // For simple types type? is Nullable<type> (See docs)
    public Nullable<Char>     Char_boxed_valueType_defaultConstructor_systemNullable_nullableMark     {set;get;} // Boxed types are value types! // For simple types type? is Nullable<type> (See docs)
    public Nullable<Double>   Double_boxed_valueType_defaultConstructor_systemNullable_nullableMark   {set;get;} // Boxed types are value types! // For simple types type? is Nullable<type> (See docs)
    
    // reference type (Not all are listed!)
    //public Nullable<string>   string_refType_type_systemNullable                   {set;get;}
    public Nullable<Guid>     Guid_valueType_defaultConstructor_systemNullable_nullableMark       {set;get;}
    public Nullable<DateTime> DateTime_valueType_defaultConstructor_systemNullable_nullableMark   {set;get;}

    // boxed reference type (Not all are listed!)
    //public Nullable<String>   String_refType_defaultConstructor_systemNullable     {set;get;}
    
    // Custom value type
    public Nullable<TestEnum> TestEnum_valueType_customType_defaultConstructor_systemNullable_nullableMark     {set;get;}
    
    // Custom reference type
    //public Nullable<TestClassNoDefaultCtor> TestClassNoDefaultCtor_refType_customType_systemNullable {set;get;}
    //public Nullable<TestClassDefaultCtor> TestClassDefaultCtor_refType_customType_systemNullable {set;get;}
    //public Nullable<TestClassNoCtor> TestClassNoCtor_refType_customType_systemNullable {set;get;}
    //public Nullable<TestPropertyClass> TestPropertyClass_refType_customType_systemNullable {set;get;}
    
    
    // ----------------- required version (Having the required accessibility modifier)  -----------
    
    // simple value types
    public required bool     bool_valueType_defaultConstructor_required     {set;get;}
    public required decimal  decimal_valueType_defaultConstructor_required  {set;get;}
    public required sbyte    sbyte_valueType_defaultConstructor_required    {set;get;}
    public required byte     byte_valueType_defaultConstructor_required     {set;get;}
    public required short    short_valueType_defaultConstructor_required    {set;get;}
    public required ushort   ushort_valueType_defaultConstructor_required   {set;get;}
    public required int      int_valueType_defaultConstructor_required      {set;get;}
    public required uint     uint_valueType_defaultConstructor_required     {set;get;}
    public required long     long_valueType_defaultConstructor_required     {set;get;}
    public required ulong    ulong_valueType_defaultConstructor_required    {set;get;}
    public required char     char_valueType_defaultConstructor_required     {set;get;}
    public required float    float_valueType_defaultConstructor_required    {set;get;}
    public required double   double_valueType_defaultConstructor_required   {set;get;}
   
    // boxed simple value types (Not all are listed - some of the boxed types are deprecated)
    public required Boolean  Boolean_boxed_valueType_defaultConstructor_required  {set;get;} // Boxed types are value types!
    public required Decimal  Decimal_boxed_valueType_defaultConstructor_required  {set;get;} // Boxed types are value types!
    public required SByte    Sbyte_boxed_valueType_defaultConstructor_required    {set;get;} // Boxed types are value types!
    public required Byte     Byte_boxed_valueType_defaultConstructor_required     {set;get;} // Boxed types are value types!
    public required Char     Char_boxed_valueType_defaultConstructor_required     {set;get;} // Boxed types are value types!
    public required Double   Double_boxed_valueType_defaultConstructor_required   {set;get;} // Boxed types are value types!
    public required Guid     Guid_valueType_defaultConstructor_required       {set;get;}
    public required DateTime DateTime_valueType_defaultConstructor_required   {set;get;}
    
    // reference type (Not all are listed!)
    public required string   string_refType_type_required                   {set;get;}

    // boxed reference type (Not all are listed!)
    public required String   String_refType_required     {set;get;}
    
    // Custom value type
    public required TestEnum TestEnum_valueType_customType_defaultConstructor_required     {set;get;}
    
    // Custom reference type
    public required TestClassNoDefaultCtor TestClassNoDefaultCtor_refType_customType_required {set;get;}
    public required TestClassDefaultCtor TestClassDefaultCtor_refType_customType_defaultConstructor_required {set;get;}
    public required TestClassNoCtor TestClassNoCtor_refType_customType_defaultConstructor_required {set;get;}
    

    // ----------------- Nullable mark version (required) -----------------
    
    // simple value types
    public required bool?     bool_valueType_defaultConstructor_nullableMark_required     {set;get;}
    public required decimal?  decimal_valueType_defaultConstructor_nullableMark_required  {set;get;}
    public required sbyte?    sbyte_valueType_defaultConstructor_nullableMark_required    {set;get;}
    public required byte?     byte_valueType_defaultConstructor_nullableMark_required     {set;get;}
    public required short?    short_valueType_defaultConstructor_nullableMark_required    {set;get;}
    public required ushort?   ushort_valueType_defaultConstructor_nullableMark_required   {set;get;}
    public required int?      int_valueType_defaultConstructor_nullableMark_required      {set;get;}
    public required uint?     uint_valueType_defaultConstructor_nullableMark_required     {set;get;}
    public required long?     long_valueType_defaultConstructor_nullableMark_required     {set;get;}
    public required ulong?    ulong_valueType_defaultConstructor_nullableMark_required    {set;get;}
    public required char?     char_valueType_defaultConstructor_nullableMark_required     {set;get;}
    public required float?    float_valueType_defaultConstructor_nullableMark_required    {set;get;}
    public required double?   double_valueType_defaultConstructor_nullableMark_required   {set;get;}
   
    // boxed simple value types (Not all are listed - some of the boxed types are deprecated)
    public required Boolean?  Boolean_boxed_valueType_defaultConstructor_nullableMark_required  {set;get;} // Boxed types are value types!
    public required Decimal?  Decimal_boxed_valueType_defaultConstructor_nullableMark_required  {set;get;} // Boxed types are value types!
    public required SByte?    Sbyte_boxed_valueType_defaultConstructor_nullableMark_required    {set;get;} // Boxed types are value types!
    public required Byte?     Byte_boxed_valueType_defaultConstructor_nullableMark_required     {set;get;} // Boxed types are value types!
    public required Char?     Char_boxed_valueType_defaultConstructor_nullableMark_required     {set;get;} // Boxed types are value types!
    public required Double?   Double_boxed_valueType_defaultConstructor_nullableMark_required   {set;get;} // Boxed types are value types!
    public required Guid?     Guid_valueType_defaultConstructor_nullableMark_required       {set;get;}
    public required DateTime? DateTime_valueType_defaultConstructor_nullableMark_required   {set;get;}
    
    // reference type (Not all are listed!)
    public required string?   string_refType_type_nullableMark_required                   {set;get;}

    // boxed reference type (Not all are listed!)
    public required String?   String_refType_nullableMark_required     {set;get;}
    
    // Custom value type
    public required TestEnum? TestEnum_valueType_customType_defaultConstructor_nullableMark_required     {set;get;}
    
    // Custom reference type
    public required TestClassNoDefaultCtor? TestClassNoDefaultCtor_refType_customType_nullableMark_required {set;get;}
    public required TestClassDefaultCtor? TestClassDefaultCtor_refType_customType_defaultConstructor_nullableMark_required {set;get;}
    public required TestClassNoCtor? TestClassNoCtor_refType_customType_defaultConstructor_nullableMark_required {set;get;}
    

}