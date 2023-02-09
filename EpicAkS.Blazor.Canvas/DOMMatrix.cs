namespace EpicAkS.Blazor.Canvas;

///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
public class DOMMatrix : ReturnVar
{
    private JsInterops jsInterops { get; init; }

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
