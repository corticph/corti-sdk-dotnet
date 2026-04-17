namespace Corti;

public partial interface ICodesClient
{
    /// <summary>
    /// Predict medical codes from provided context.<br/>&lt;Note&gt;This is a stateless endpoint, designed to predict ICD-10-CM, ICD-10-PCS, ICD-10-UK, CIM-10-FR, ICD-10-GM, OPCS-4 and CPT codes based on input text string or documentId.<br/><br/>More than one code system may be defined in a single request.<br/><br/>Code prediction requests have two possible values for context:<br/>- `text`: One set of code prediction results will be returned based on all input text defined.<br/>- `documentId`: Code prediction will be based on that defined document only.<br/><br/>The response includes two sets of results:<br/>- `Codes`: Codes predicted by the model.<br/>- `Candidates`: Lower-confidence codes the model considered potentially relevant but excluded from the predicted set.<br/><br/>All predicted code results are based on input context defined in the request only (not other external data or assets associated with an interaction).&lt;/Note&gt;
    /// </summary>
    WithRawResponseTask<CodesGeneralResponse> PredictAsync(
        CodesGeneralPredictRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
