using Corti.Test.Utils;
using NUnit.Framework;

namespace Corti.Test.Custom.Transcripts;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class ParticipantRoleJsonTests
{
    [Test]
    public void TranscriptsParticipant_RoundtripsWithFreeFormRole()
    {
        JsonAssert.Roundtrips<TranscriptsParticipant>(
            """{ "channel": 0, "role": "Attending Physician" }"""
        );
    }

    [TestCase("doctor")]
    [TestCase("patient")]
    [TestCase("multiple")]
    public void TranscriptsParticipant_RoundtripsWithLegacyRoleValues(string role)
    {
        JsonAssert.Roundtrips<TranscriptsParticipant>(
            $$"""{ "channel": 0, "role": "{{role}}" }"""
        );
    }

    [Test]
    public void TranscriptsParticipant_RoleIsPlainStringNotEnum()
    {
        var property = typeof(TranscriptsParticipant).GetProperty("Role");
        Assert.That(property?.PropertyType, Is.EqualTo(typeof(string)));
    }

    [Test]
    public void StreamConfigParticipant_RoundtripsWithFreeFormRole()
    {
        JsonAssert.Roundtrips<StreamConfigParticipant>(
            """{ "channel": 0, "role": "Attending Physician" }"""
        );
    }

    [Test]
    public void StreamConfigParticipant_RoleIsPlainStringNotEnum()
    {
        var property = typeof(StreamConfigParticipant).GetProperty("Role");
        Assert.That(property?.PropertyType, Is.EqualTo(typeof(string)));
    }
}
