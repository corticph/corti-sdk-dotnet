namespace Corti;

public partial interface INewSectionsClient
{
    WithRawResponseTask<Section> UpdateAsync(
        string sectionId,
        UpdateSectionRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
