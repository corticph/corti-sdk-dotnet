using Corti.Agentic;
using Corti.Test.Utils;
using NUnit.Framework;

namespace Corti.Test.Custom.Agentic;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AgenticAgentsJsonTests
{
    [Test]
    public void AgenticAgentsResponse_RoundtripsWithMaxLoopsAndNullExpiresAt()
    {
        JsonAssert.Roundtrips<AgenticAgentsResponse>(
            """
            {
                "id": "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
                "name": "coder",
                "maxLoops": 10,
                "visibility": "private",
                "lifecycle": "persistent",
                "connectors": [],
                "expiresAt": null
            }
            """
        );
    }

    [Test]
    public void AgenticAgentsResponse_RoundtripsWithExpiresAtSet()
    {
        JsonAssert.Roundtrips<AgenticAgentsResponse>(
            """
            {
                "id": "agt.0192f4c8-2c5a-7b3e-9f1a-3c8d6e2b7a40",
                "name": "coder",
                "maxLoops": 25,
                "visibility": "private",
                "lifecycle": "ephemeral",
                "connectors": [],
                "expiresAt": "2026-09-12T00:00:00Z"
            }
            """
        );
    }

    [Test]
    public void AgenticAgentsCreateRequest_SerializesWithoutMaxLoopsWhenOmitted()
    {
        var request = new AgenticAgentsCreateRequest { Name = "coder" };

        JsonAssert.AreEqual(request, """{ "name": "coder" }""");
    }

    [Test]
    public void AgenticAgentsCreateRequest_SerializesWithMaxLoops()
    {
        var request = new AgenticAgentsCreateRequest { Name = "coder", MaxLoops = 42 };

        JsonAssert.AreEqual(request, """{ "name": "coder", "maxLoops": 42 }""");
    }

    [Test]
    public void AgenticAgentsPatchRequest_SerializesWithMaxLoops()
    {
        var request = new AgenticAgentsPatchRequest { MaxLoops = 50 };

        JsonAssert.AreEqual(request, """{ "maxLoops": 50 }""");
    }

    [Test]
    public void AgenticAgentsPatchRequest_OmitsMaxLoopsWhenNotSet()
    {
        var request = new AgenticAgentsPatchRequest { Name = "coder-v2" };

        JsonAssert.AreEqual(request, """{ "name": "coder-v2" }""");
    }
}
