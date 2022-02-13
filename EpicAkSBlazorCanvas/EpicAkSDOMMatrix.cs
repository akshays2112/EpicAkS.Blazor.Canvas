namespace EpicAkSBlazorCanvas;

///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
public class EpicAkSDOMMatrix : EpicAkSReturnVar
{
    private EpicAkSBlazorJsInterops epicAkSBlazorJsInterops { get; init; }

    ///<summary></summary>
    public EpicAkSDOMMatrix(EpicAkSBlazorCanvasClass epicAkSBlazorCanvas)
    {
        this.epicAkSBlazorJsInterops = epicAkSBlazorCanvas.EpicAkSBlazorJsInterops;
    }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    public async Task CreateDOMMatrix() =>
        await epicAkSBlazorJsInterops.CallFunctionWithNewVarToHold(this, "DOMMatrix");

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    public async Task CreateDOMMatrix(string stringParameter) =>
        await epicAkSBlazorJsInterops.CallFunctionWithStringParameterWithNewVarToHold(this, "DOMMatrix", stringParameter);

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/DOMMatrix/DOMMatrix</summary>
    public async Task CreateDOMMatrix(double[] doubleArrayParameter) =>
        await epicAkSBlazorJsInterops.CallFunctionWithDoubleArrayParameterWithNewVarToHold(this, "DOMMatrix", doubleArrayParameter);
}
