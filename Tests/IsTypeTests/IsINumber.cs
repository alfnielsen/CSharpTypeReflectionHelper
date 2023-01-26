using Tests.common;

namespace Tests.IsTypeTests;

file record TestRecord(int A, int B, int C);

file class TestClass { }

file class Legal
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
}

file class Illegal
{
    public int? TestInt2 { get; set; }
    public required int? TestInt4 { get; set; }
    public long? TestLong2 { get; set; }
    public required long? TestLong4 { get; set; }
    public decimal? TestDecimal2 { get; set; }
    public required decimal? TestDecimal4 { get; set; }
    public float? TestFloat2 { get; set; }
    public required float? TestFloat4 { get; set; }
    public byte? TestByte2 { get; set; }
    public required byte? TestByte4 { get; set; }
    public Guid TestGuid1 { get; set; }
    public Guid? TestGuid2 { get; set; }
    public required Guid TestGuid3 { get; set; }
    public required Guid? TestGuid4 { get; set; }
    public TestClass TestClass { get; set; }
    public TestRecord TestRecord { get; set; }
    public DateTime DateTime1 { get; set; }
    public DateTime? DateTime2 { get; set; }
}


[TestFixture]
public class IsINumber: TestTypeBase
{
    [Test]
    public void IsINumberBaseTest()
    {
                
        PropertiesOf<Legal>().AllMatch<IsINumber>();
        PropertiesOf<Legal>().AllTypesMatch<IsINumber>();
        PropertiesOf<Illegal>().AllDoNotMatch<IsINumber>();
        PropertiesOf<Illegal>().AllTypesDoNotMatch<IsINumber>();

        Types("Type",
            typeof(int),
            typeof(decimal)
        ).AllMatch<IsINumber>();
        
        Types("TypeNot",
            typeof(DateTime),
            typeof(Guid),
            typeof(int?),
            typeof(decimal?),
            typeof(DateTime?),
            typeof(Guid?),
            typeof(TestClass)
        ).AllDoNotMatch<IsINumber>();
        
    }

}

