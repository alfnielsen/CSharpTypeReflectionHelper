// CS8618: Non-nullable field is uninitialized
// ReSharper disable InconsistentNaming // "_" in name
// ReSharper disable ConvertNullableToShortForm // Convert Nullable<T> to T?
// ReSharper disable ClassNeverInstantiated.Global

using CSharpTypeReflectionHelper;
using Tests.TypeReflection.common;

namespace Tests.TypeReflection;

[TestFixture]
public class IsNullableReferenceTest
{
    /// <summary>
    /// TODO: Create real Nuget library for this
    /// </summary>
    [TestCase]
    public void TypeReflectionTest()
    {
        // NOTE FROM RESULT:
        // - String does not have a default constructor !
        // - DateTime and Guid are ValueTypes (They are structs and all structs are ValueTypes)
        // - System.Nullable<T> are the same is "T?" (In project settings: <Nullable>enable</Nullable>) 
        // The compiler prevents System.Nullable<T> for non-nullable T types.

        
        // nullability types:
        Assert.That(typeof(Nullable<int>), Is.EqualTo(typeof(int?)));
        Assert.That(typeof(Nullable<Guid>), Is.EqualTo(typeof(Guid?)));
        Assert.That(typeof(Nullable<Guid>).IsValueType, Is.EqualTo(typeof(Guid?).IsValueType));
        Assert.That(typeof(Nullable<DateTime>).IsValueType, Is.EqualTo(typeof(DateTime?).IsValueType));
        
        foreach (var propertyInfo in typeof(TestPropertyClass).GetProperties())
        {
            // Name parts: [0] is the name of the property
            //  - boxed
            //  - refType
            //  - valueType
            //  - defaultConstructor
            //  - required
            //  - nullableMark (uses "?")
            //  - systemNullable (uses "System.Nullable")
            var name = propertyInfo.Name;
            var nameParts = name.Split('_');
            var typeName = nameParts[0];
            // var shouldHaveBoxed = nameParts.Any(x=>x=="boxed"); // boxed tests are for values not types..
            var shouldBeRefType = nameParts.Any(x=>x=="refType");
            var shouldBeValueType = nameParts.Any(x=>x=="valueType");
            var shouldHaveDefaultConstructor = nameParts.Any(x=>x=="defaultConstructor");
            var shouldHaveRequired = nameParts.Any(x=>x=="required");
            var shouldHaveNullableMark = nameParts.Any(x=>x=="nullableMark");
            //var shouldHaveSystemNullable = nameParts.Any(x=>x=="systemNullable"); // As the test demonstrates, Nullable<T> is not the same as T? (For project with )
            
            // Test Reflection Extension:
            var type = propertyInfo.PropertyType;

            //Assert.AreEqual(shouldHaveBoxed, propertyInfo.IsBoxedValueType());
            Assert.That(type.IsValueType, Is.Not.EqualTo(shouldBeRefType), $"Type {typeName} should {(shouldBeRefType ? "not " : "")}be a value type ({name})");
            Assert.That(type.IsValueType, Is.EqualTo(shouldBeValueType), $"Type {typeName} should {(shouldBeValueType ? "" : "not ")}be a value type ({name})");
            Assert.Multiple(() =>
            {
                Assert.That(propertyInfo.HasDefaultConstructor(), Is.EqualTo(shouldHaveDefaultConstructor), $"Type {typeName} should {(shouldHaveDefaultConstructor ? "" : "not ")}have a default constructor ({name})");
                Assert.That(propertyInfo.HasRequiredModifier(), Is.EqualTo(shouldHaveRequired), $"Type {typeName} should {(shouldHaveRequired ? "" : "not ")}have a required modifier ({name})");
                Assert.That(propertyInfo.IsNullableReference(), Is.EqualTo(shouldHaveNullableMark), $"Type {typeName} should {(shouldHaveNullableMark ? "" : "not ")}have a nullable mark ({name})");
            });
        }
    }
}

