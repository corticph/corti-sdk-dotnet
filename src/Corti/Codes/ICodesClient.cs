namespace Corti;

public partial interface ICodesClient
{
    /// <summary>
    /// Predict medical codes from provided context.<br/>&lt;Note&gt;This is a stateless endpoint, designed to predict ICD-10-CM, ICD-10-PCS, and CPT codes based on input text string or documentId.<br/><br/>More than one code system may be defined in a single request, and the maximum number of codes to return per system can also be defined.<br/><br/>Code prediction requests have two possible values for context:<br/>- `text`: One set of code prediction results will be returned based on all input text defined.<br/>- `documentId`: Code prediction will be based on that defined document only.<br/><br/>The response includes two sets of results:<br/>- `Codes`: Highest confidence bundle of codes, as selected by the code prediction model<br/>- `Candidates`: Full list of candidate codes as predicted by the model, rank sorted by model confidence with maximum possible value of 50.<br/><br/>All predicted code results are based on input context defined in the request only (not other external data or assets associated with an interaction).&lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<CodesGeneralResponse> PredictAsync(
        CodesGeneralPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
