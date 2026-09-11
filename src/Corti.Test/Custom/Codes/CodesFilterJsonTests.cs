using Corti.Test.Utils;
using NUnit.Framework;

namespace Corti.Test.Custom.Codes;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class CodesFilterJsonTests
{
    [Test]
    public void CodesFilter_RoundtripsWithIncludeConditions()
    {
        JsonAssert.Roundtrips<CodesFilter>(
            """
            {
                "include": [ { "property": "code", "op": "is-a", "value": "E11" } ]
            }
            """
        );
    }

    [Test]
    public void CodesFilter_RoundtripsWithExcludeConditions()
    {
        JsonAssert.Roundtrips<CodesFilter>(
            """
            {
                "exclude": [ { "property": "code", "op": "=", "value": "Z00" } ]
            }
            """
        );
    }

    [TestCase("=")]
    [TestCase("is-a")]
    [TestCase("descendent-of")]
    [TestCase("exists")]
    [TestCase("in")]
    public void CodesFilterCondition_RoundtripsForEachOpEnumValue(string op)
    {
        JsonAssert.Roundtrips<CodesFilterCondition>(
            $$"""{ "property": "code", "op": "{{op}}", "value": "E11" }"""
        );
    }

    [Test]
    public void CodesFilterCondition_RoundtripsWithArrayValue()
    {
        JsonAssert.Roundtrips<CodesFilterCondition>(
            """{ "property": "code", "op": "in", "value": ["E11", "E11.9"] }"""
        );
    }

    [Test]
    public void CodesFilterCondition_RoundtripsWithBooleanValue()
    {
        JsonAssert.Roundtrips<CodesFilterCondition>(
            """{ "property": "code", "op": "exists", "value": true }"""
        );
    }

    [Test]
    public void CodesFilter_NoLongerHasExpandProperty()
    {
        Assert.That(typeof(CodesFilter).GetProperty("Expand"), Is.Null);
    }
}
