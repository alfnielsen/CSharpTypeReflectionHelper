using System;
using Tests.common;

// ReSharper disable ConvertNullableToShortForm

namespace Tests.IsTypeTests;

file record TestRecord(int A, int B, int C);

file class TestClass { }

file class Legal
{
    public int? TestInt1 { get; set; }
    public Int32? TestInt2 { get; set; }
    public required int? TestInt3 { get; set; }
    public required Int32? TestInt4 { get; set; }
    public long? TestLong1 { get; set; }
    public required long? TestLong3 { get; set; }
    public decimal? TestDecimal1 { get; set; }
    public Decimal? TestDecimal2 { get; set; }
    public required decimal? TestDecimal3 { get; set; }
    public required Decimal? TestDecimal4 { get; set; }
    public float? TestFloat1 { get; set; }
    public required float? TestFloat3 { get; set; }
    public byte? TestByte1 { get; set; }
    public Byte? TestByte2 { get; set; }
    public required byte? TestByte3 { get; set; }
    public required Byte? TestByte4 { get; set; }
    public Guid? TestGuid1 { get; set; }
    public required Guid? TestGuid2 { get; set; }
    public DateTime? TestDateTime1 { get; set; }
    public required DateTime? TestDateTime2 { get; set; }
    
    public Nullable<int> TestInt1Nullable { get; set; }
    public Nullable<Int32> TestInt2Nullable { get; set; }
    public required Nullable<int> TestInt3Nullable { get; set; }
    public required Nullable<Int32> TestInt4Nullable { get; set; }
    public Nullable<long> TestLong1Nullable { get; set; }
    public required Nullable<long> TestLong3Nullable { get; set; }
    public Nullable<decimal> TestDecimal1Nullable { get; set; }
    public Nullable<Decimal> TestDecimal2Nullable { get; set; }
    public required Nullable<decimal> TestDecimal3Nullable { get; set; }
    public required Nullable<Decimal> TestDecimal4Nullable { get; set; }
    public Nullable<float> TestFloat1Nullable { get; set; }
    public required Nullable<float> TestFloat3Nullable { get; set; }
    public Nullable<byte> TestByte1Nullable { get; set; }
    public Nullable<Byte> TestByte2Nullable { get; set; }
    public required Nullable<byte> TestByte3Nullable { get; set; }
    public required Nullable<Byte> TestByte4Nullable { get; set; }
    public Nullable<Guid> TestGuid1Nullable { get; set; }
    public required Nullable<Guid> TestGuid2Nullable { get; set; }
    public Nullable<DateTime> TestDateTime1Nullable { get; set; }
    public required Nullable<DateTime> TestDateTime2Nullable { get; set; }
    
}

file class Illegal
{
    public int TestInt1 { get; set; }
    public Int32 TestInt2 { get; set; }
    public required int TestInt3 { get; set; }
    public required Int32 TestInt4 { get; set; }
    public long TestLong1 { get; set; }
    public required long TestLong3 { get; set; }
    public decimal TestDecimal1 { get; set; }
    public Decimal TestDecimal2 { get; set; }
    public required decimal TestDecimal3 { get; set; }
    public required Decimal TestDecimal4 { get; set; }
    public float TestFloat1 { get; set; }
    public required float TestFloat3 { get; set; }
    public byte TestByte1 { get; set; }
    public Byte TestByte2 { get; set; }
    public required byte TestByte3 { get; set; }
    public required Byte TestByte4 { get; set; }
    public Guid TestGuid1 { get; set; }
    public required Guid TestGuid2 { get; set; }
    public TestClass TestClass { get; set; }
    public TestRecord TestRecord { get; set; }
    public TestClass? TestClass2 { get; set; }
    public TestRecord? TestRecord2 { get; set; }

}


[TestFixture]
public class IsNullableValueType: TestTypeBase
{
    [Test]
    public void IsNullableValueTypeBaseTest()
    {
                
        PropertiesOf<Legal>().AllMatch<IsNullableValueType>();
        PropertiesOf<Legal>().AllTypesMatch<IsNullableValueType>();
        PropertiesOf<Illegal>().AllDoNotMatch<IsNullableValueType>();
        PropertiesOf<Illegal>().AllTypesDoNotMatch<IsNullableValueType>();

        Types("Type",
            typeof(int?),
            typeof(decimal?),
            typeof(DateTime?),
            typeof(Guid?)
        ).AllMatch<IsNullableValueType>();
        
        Types("TypeNot",
            typeof(DateTime),
            typeof(Guid),
            typeof(TestClass),
            typeof(TestRecord)
        ).AllDoNotMatch<IsNullableValueType>();
        
    }

}

