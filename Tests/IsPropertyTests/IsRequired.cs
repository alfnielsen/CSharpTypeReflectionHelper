

// ReSharper disable ConvertNullableToShortForm

using Tests.common;

namespace Tests.IsPropertyTests;

file record TestRecord(int A, int B, int C);

file class TestClass { }

file enum TestEnum { A, B, C }

file class Legal
{
    public required int TestInt1 { get; set; }
    public required Int32 TestInt2 { get; set; }
    public required long TestLong1 { get; set; }
    public required decimal TestDecimal1 { get; set; }
    public required Decimal TestDecimal2 { get; set; }
    public required float TestFloat1 { get; set; }
    public required byte TestByte1 { get; set; }
    public required Byte TestByte2 { get; set; }
    public required Guid TestGuid1 { get; set; }
    public required TestClass TestClass { get; set; }
    public required TestRecord TestRecord { get; set; }
    public required int? TestInt1Nullable { get; set; }
    public required Int32? TestInt2Nullable { get; set; }
    public required long? TestLong1Nullable { get; set; }
    public required decimal? TestDecimal1Nullable { get; set; }
    public required Decimal? TestDecimal2Nullable { get; set; }
    public required float? TestFloat1Nullable { get; set; }
    public required byte? TestByte1Nullable { get; set; }
    public required Byte? TestByte2Nullable { get; set; }
    public required Guid? TestGuid1Nullable { get; set; }
    public required TestClass? TestClassNullable { get; set; }
    public required TestRecord? TestRecordNullable { get; set; }
    public required TestEnum? TestEnumNullable { get; set; }
    public virtual required Int32 TestInt2Virtuial { get; set; }
    public virtual required long TestLong1Virtuial { get; set; }
    public virtual required decimal TestDecimal1Virtuial { get; set; }
    public virtual required Decimal TestDecimal2Virtuial { get; set; }
    public virtual required float TestFloat1Virtuial { get; set; }
    public virtual required byte TestByte1Virtuial { get; set; }
    public virtual required Byte TestByte2Virtuial { get; set; }
    public virtual required Guid TestGuid1Virtuial { get; set; }
    public virtual required TestClass TestClassVirtuial { get; set; }
    public virtual required TestRecord TestRecordVirtuial { get; set; }
    public virtual required int? TestInt1NullableVirtuial { get; set; }
    public virtual required Int32? TestInt2NullableVirtuial { get; set; }
    public virtual required long? TestLong1NullableVirtuial { get; set; }
    public virtual required decimal? TestDecimal1NullableVirtuial { get; set; }
    public virtual required Decimal? TestDecimal2NullableVirtuial { get; set; }
    public virtual required float? TestFloat1NullableVirtuial { get; set; }
    public virtual required byte? TestByte1NullableVirtuial { get; set; }
    public virtual required Byte? TestByte2NullableVirtuial { get; set; }
    public virtual required Guid? TestGuid1NullableVirtuial { get; set; }
    public virtual required TestClass? TestClassNullableVirtuial { get; set; }
    public virtual required TestRecord? TestRecordNullableVirtuial { get; set; }
    public virtual required TestEnum? TestEnumNullableVirtuial { get; set; }
    public virtual required TestEnum TestEnumVirtuial { get; set; }

}

file class Illegal
{
    public int? TestInt1Nullable { get; set; }
    public Int32? TestInt2Nullable { get; set; }
    public long? TestLong1Nullable { get; set; }
    public decimal? TestDecimal1Nullable { get; set; }
    public Decimal? TestDecimal2Nullable { get; set; }
    public float? TestFloat1Nullable { get; set; }
    public byte? TestByte1Nullable { get; set; }
    public Byte? TestByte2Nullable { get; set; }
    public Guid? TestGuid1Nullable { get; set; }
    public TestClass? TestClassNullable { get; set; }
    public TestRecord? TestRecordNullable { get; set; }
    public TestEnum? TestEnumNullable { get; set; }
    public TestEnum TestEnum { get; set; }
    public int TestInt1 { get; set; }
    public Int32 TestInt2 { get; set; }
    public long TestLong1 { get; set; }
    public decimal TestDecimal1 { get; set; }
    public Decimal TestDecimal2 { get; set; }
    public float TestFloat1 { get; set; }
    public byte TestByte1 { get; set; }
    public Byte TestByte2 { get; set; }
    public Guid TestGuid1 { get; set; }
    public TestClass TestClass { get; set; }
    public TestRecord TestRecord { get; set; }

}


[TestFixture]
public class IsRequired: TestTypeBase
{
    [Test]
    public void IsRequiredBaseTest()
    {
                
        PropertiesOf<Legal>().AllMatch<IsRequired>();
        PropertiesOf<Illegal>().AllDoNotMatch<IsRequired>();
        
    }

}

