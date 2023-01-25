using CSharpTypeReflectionHelper;

namespace Tests.TypeReflection;

file class TestClass
{
    public int TestInt1 { get; set; }
    public int? TestInt2 { get; set; }
    public required int TestInt3 { get; set; }
    public required int? TestInt4 { get; set; }
    public long TestLong1 { get; set; }
    public long? TestLong2 { get; set; }
    public required long TestLong3 { get; set; }
    public required long? TestLong4 { get; set; }
    public decimal TestDecimal1 { get; set; }
    public decimal? TestDecimal2 { get; set; }
    public required decimal TestDecimal3 { get; set; }
    public required decimal? TestDecimal4 { get; set; }
    public float TestFloat1 { get; set; }
    public float? TestFloat2 { get; set; }
    public required float TestFloat3 { get; set; }
    public required float? TestFloat4 { get; set; }
    public byte TestByte1 { get; set; }
    public byte? TestByte2 { get; set; }
    public required byte TestByte3 { get; set; }
    public required byte? TestByte4 { get; set; }

}

[TestFixture]
public class IsINumberTest
{
    [Test]
    public void IsINumberTestBase()
    {
        var props = typeof(TestClass).GetProperties();
        foreach (var prop in props)
        {
            if (prop.IsNullableReference())
            {
                // Nullable reference type does not implement IParsable!
                Assert.That(prop.PropertyType.IsINumber, Is.False);
                var underlyingType = prop.PropertyType.GetGenericArguments()[0];
                Assert.That(underlyingType.IsINumber, Is.True);
            }
            else
            {
                Assert.That(prop.PropertyType.IsINumber, Is.True, $"{prop.Name} is not a IParsable type");
            }
        }

        Assert.That(typeof(int).IsINumber, Is.True);
        Assert.That(typeof(decimal).IsINumber, Is.True);
        Assert.That(typeof(Guid).IsINumber, Is.False); // IParsable but not INumber
        Assert.That(typeof(DateTime).IsINumber, Is.False); // IParsable but not INumber
        //
        Assert.That(typeof(int?).IsINumber, Is.False);
        Assert.That(typeof(decimal?).IsINumber, Is.False);
        Assert.That(typeof(Guid?).IsINumber, Is.False); // IParsable but not INumber
        Assert.That(typeof(DateTime?).IsINumber, Is.False); // IParsable but not INumber
        
    }

}

