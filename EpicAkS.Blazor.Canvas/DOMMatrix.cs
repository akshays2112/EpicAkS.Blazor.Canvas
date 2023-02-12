using System.Text.Json.Serialization;

namespace EpicAkS.Blazor.Canvas;

///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
public class DOMMatrix : ReturnVar
{
    private JsInterops jsInterops { get; init; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    [JsonPropertyName("a")]
    public double a { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    [JsonPropertyName("b")]
    public double b { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    [JsonPropertyName("c")]
    public double c { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    [JsonPropertyName("d")]
    public double d { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    [JsonPropertyName("e")]
    public double e { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    [JsonPropertyName("f")]
    public double f { get; set; }

    ///<summary></summary>
    public DOMMatrix(CanvasClass Canvas)
    {
        this.jsInterops = Canvas.JsInterops;
    }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    public async Task CreateDOMMatrix() =>
        await jsInterops.CallFunctionWithNewVarToHold(this, "DOMMatrix");

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    public async Task CreateDOMMatrix(string stringParameter) =>
        await jsInterops.CallFunctionWithStringParameterWithNewVarToHold(this, "DOMMatrix", stringParameter);

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    public async Task CreateDOMMatrix(double[] doubleArrayParameter) =>
        await jsInterops.CallFunctionWithDoubleArrayParameterWithNewVarToHold(this, "DOMMatrix", doubleArrayParameter);
}
