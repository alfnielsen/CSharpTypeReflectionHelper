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
    public Guid TestGuid1 { get; set; }
    public Guid? TestGuid2 { get; set; }
    public required Guid TestGuid3 { get; set; }
    public required Guid? TestGuid4 { get; set; }
    public DateTime TestDateTime1 { get; set; }
    public DateTime? TestDateTime2 { get; set; }
    public required DateTime TestDateTime3 { get; set; }
    public required DateTime? TestDateTime4 { get; set; }
    
}

[TestFixture]
public class IsIParsableTest
{
    [Test]
    public void IsIParsableTestBase()
    {
        var props = typeof(TestClass).GetProperties();
        foreach (var prop in props)
        {
            if (prop.IsNullableReference())
            {
                // Nullable reference type does not implement IParsable!
                Assert.That(prop.PropertyType.IsIParsable, Is.False);
                var underlyingType = prop.PropertyType.GetGenericArguments()[0];
                Assert.That(underlyingType.IsIParsable, Is.True);
            }
            else
            {
                Assert.That(prop.PropertyType.IsIParsable, Is.True, $"{prop.Name} is not a IParsable type");
            }
        }

        Assert.That(typeof(int).IsIParsable, Is.True);
        Assert.That(typeof(decimal).IsIParsable, Is.True);
        Assert.That(typeof(Guid).IsIParsable, Is.True);
        Assert.That(typeof(DateTime).IsIParsable, Is.True);
        //
        Assert.That(typeof(int?).IsIParsable, Is.False);
        Assert.That(typeof(decimal?).IsIParsable, Is.False);
        Assert.That(typeof(Guid?).IsIParsable, Is.False);
        Assert.That(typeof(DateTime?).IsIParsable, Is.False);
        
    }

}

