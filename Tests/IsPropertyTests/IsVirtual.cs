

// ReSharper disable ConvertNullableToShortForm

using Tests.common;

namespace Tests.IsPropertyTests;

file record TestRecord(int A, int B, int C);

file class TestClass { }

file enum TestEnum { A, B, C }

file class Legal
{
    public virtual int? TestInt1Nullable { get; set; }
    public virtual Int32? TestInt2Nullable { get; set; }
    public virtual required int? TestInt3Nullable { get; set; }
    public virtual required Int32? TestInt4Nullable { get; set; }
    public virtual long? TestLong1Nullable { get; set; }
    public virtual required long? TestLong3Nullable { get; set; }
    public virtual decimal? TestDecimal1Nullable { get; set; }
    public virtual Decimal? TestDecimal2Nullable { get; set; }
    public virtual required decimal? TestDecimal3Nullable { get; set; }
    public virtual required Decimal? TestDecimal4Nullable { get; set; }
    public virtual float? TestFloat1Nullable { get; set; }
    public virtual required float? TestFloat3Nullable { get; set; }
    public virtual byte? TestByte1Nullable { get; set; }
    public virtual Byte? TestByte2Nullable { get; set; }
    public virtual required byte? TestByte3Nullable { get; set; }
    public virtual required Byte? TestByte4Nullable { get; set; }
    public virtual Guid? TestGuid1Nullable { get; set; }
    public virtual required Guid? TestGuid2Nullable { get; set; }
    public virtual TestClass? TestClassNullable { get; set; }
    public virtual TestRecord? TestRecordNullable { get; set; }
    public virtual TestEnum? TestEnumNullable { get; set; }
    public virtual required TestClass? TestClass2Nullable { get; set; }
    public virtual required TestRecord? TestRecord2Nullable { get; set; }
    public virtual TestEnum TestEnum { get; set; }
    public virtual int TestInt1 { get; set; }
    public virtual Int32 TestInt2 { get; set; }
    public virtual required int TestInt3 { get; set; }
    public virtual required Int32 TestInt4 { get; set; }
    public virtual long TestLong1 { get; set; }
    public virtual required long TestLong3 { get; set; }
    public virtual decimal TestDecimal1 { get; set; }
    public virtual Decimal TestDecimal2 { get; set; }
    public virtual required decimal TestDecimal3 { get; set; }
    public virtual required Decimal TestDecimal4 { get; set; }
    public virtual float TestFloat1 { get; set; }
    public virtual required float TestFloat3 { get; set; }
    public virtual byte TestByte1 { get; set; }
    public virtual Byte TestByte2 { get; set; }
    public virtual required byte TestByte3 { get; set; }
    public virtual required Byte TestByte4 { get; set; }
    public virtual Guid TestGuid1 { get; set; }
    public virtual required Guid TestGuid2 { get; set; }
    public virtual TestClass TestClass { get; set; }
    public virtual TestRecord TestRecord { get; set; }
    public virtual required TestClass TestClass2 { get; set; }
    public virtual required TestRecord TestRecord2 { get; set; }

}

file class Illegal
{
    public int? TestInt1Nullable { get; set; }
    public Int32? TestInt2Nullable { get; set; }
    public required int? TestInt3Nullable { get; set; }
    public required Int32? TestInt4Nullable { get; set; }
    public long? TestLong1Nullable { get; set; }
    public required long? TestLong3Nullable { get; set; }
    public decimal? TestDecimal1Nullable { get; set; }
    public Decimal? TestDecimal2Nullable { get; set; }
    public required decimal? TestDecimal3Nullable { get; set; }
    public required Decimal? TestDecimal4Nullable { get; set; }
    public float? TestFloat1Nullable { get; set; }
    public required float? TestFloat3Nullable { get; set; }
    public byte? TestByte1Nullable { get; set; }
    public Byte? TestByte2Nullable { get; set; }
    public required byte? TestByte3Nullable { get; set; }
    public required Byte? TestByte4Nullable { get; set; }
    public Guid? TestGuid1Nullable { get; set; }
    public required Guid? TestGuid2Nullable { get; set; }
    public TestClass? TestClassNullable { get; set; }
    public TestRecord? TestRecordNullable { get; set; }
    public TestEnum? TestEnumNullable { get; set; }
    public required TestClass? TestClass2Nullable { get; set; }
    public required TestRecord? TestRecord2Nullable { get; set; }
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
    public required TestClass TestClass2 { get; set; }
    public required TestRecord TestRecord2 { get; set; }

}


[TestFixture]
public class IsVirtual: TestTypeBase
{
    [Test]
    public void IsVirtualBaseTest()
    {
                
        PropertiesOf<Legal>().AllMatch<IsVirtual>();
        PropertiesOf<Illegal>().AllDoNotMatch<IsVirtual>();
        
    }

}

