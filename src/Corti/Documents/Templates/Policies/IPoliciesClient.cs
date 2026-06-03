using Corti;

namespace Corti.Documents.Templates;

public partial interface IPoliciesClient
{
    WithRawResponseTask<IEnumerable<GuidedTemplatePolicy>> ListAsync(
        string templateId,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<IEnumerable<GuidedTemplatePolicy>> CreateAsync(
        string templateId,
        IEnumerable<GuidedTemplatesCreatePolicyRequest> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
