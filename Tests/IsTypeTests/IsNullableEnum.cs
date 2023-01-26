using System;
using Tests.common;

// ReSharper disable ConvertNullableToShortForm

namespace Tests.IsTypeTests;

file record TestRecord(int A, int B, int C);

file class TestClass { }

file enum TestEnum { A, B, C }

file class Legal
{
    public TestEnum? TestEnum { get; set; }
}

file class Illegal
{
    public TestEnum TestEnum { get; set; }
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
public class IsNullableEnum: TestTypeBase
{
    [Test]
    public void IsIsNullableEnumBaseTest()
    {
                
        PropertiesOf<Legal>().AllMatch<IsNullableEnum>();
        PropertiesOf<Legal>().AllTypesMatch<IsNullableEnum>();
        PropertiesOf<Illegal>().AllDoNotMatch<IsNullableEnum>();
        PropertiesOf<Illegal>().AllTypesDoNotMatch<IsNullableEnum>();

        Types("Type",
            typeof(TestEnum?)
        ).AllMatch<IsNullableEnum>();
        
        Types("TypeNot",
            typeof(TestEnum),
            typeof(DateTime),
            typeof(Guid),
            typeof(TestClass),
            typeof(TestRecord)
        ).AllDoNotMatch<IsNullableEnum>();
        
    }

}

