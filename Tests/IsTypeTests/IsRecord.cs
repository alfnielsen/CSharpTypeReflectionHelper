using Tests.common;

namespace Tests.IsTypeTests;

file record TestRecord(int A, int B, int C);

file class TestClass { }

file static class RecordMembers
{
    public record Record { }
    public record struct RecordStruct { }
}

file static class NotRecordMembers
{
    public class Class { }
}

file class Legal
{
    TestRecord Record { get; set; }
}

file class Illegal
{
    TestClass Class { get; set; }
    public int Int { get; set; }
    public Guid Guid { get; set; }
    public DateTime DateTime { get; set; }
    
}

[TestFixture]
public class IsRecord: TestTypeBase
{
    [Test]
    public void IsRecordBaseTest()
    {
        MembersOf(typeof(RecordMembers)).AllTypesMatch<IsRecord>();
        MembersOf(typeof(NotRecordMembers)).AllTypesDoNotMatch<IsRecord>();
        
        PropertiesOf<Legal>().AllMatch<IsRecord>();
        PropertiesOf<Legal>().AllTypesMatch<IsRecord>();
        
        PropertiesOf<Illegal>().AllDoNotMatch<IsRecord>();
        PropertiesOf<Illegal>().AllTypesDoNotMatch<IsRecord>();

        Types("Type:",
            typeof(TestRecord)
        ).AllMatch<IsRecord>();
        
        Types("TypeNot",
            typeof(int),
            typeof(Guid),
            typeof(TestClass)
        ).AllDoNotMatch<IsRecord>();

    }

}

