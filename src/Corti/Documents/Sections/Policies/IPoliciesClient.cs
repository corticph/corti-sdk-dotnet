using Corti;

namespace Corti.Documents.Sections;

public partial interface IPoliciesClient
{
    WithRawResponseTask<IEnumerable<GuidedSectionPolicy>> ListAsync(
        string sectionId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<GuidedSectionPolicy>> CreateAsync(
        string sectionId,
        IEnumerable<GuidedSectionsCreatePolicyRequest> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
