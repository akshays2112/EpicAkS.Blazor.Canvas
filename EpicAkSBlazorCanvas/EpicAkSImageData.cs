namespace EpicAkSBlazorCanvas;

///<summary></summary>
public class EpicAkSImageData : EpicAkSReturnVar
{
    private EpicAkSBlazorJsInterops epicAkSBlazorJsInterops { get; init; }

    ///<summary></summary>
    public EpicAkSImageData(EpicAkSBlazorCanvasClass epicAkSBlazorCanvas)
    {
        this.epicAkSBlazorJsInterops = epicAkSBlazorCanvas.EpicAkSBlazorJsInterops;
    }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createImageData</summary>
    public async Task CreateImageData(int width, int height) =>
        await epicAkSBlazorJsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
            this, "createImageData", new object[] { width, height });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createImageData</summary>
    public async Task CreateImageData(EpicAkSImageData imageData) =>
        await epicAkSBlazorJsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
            this, "createImageData", new object[] { imageData });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getImageData</summary>
    public async Task GetImageData(int sx, int sy, int sw, int sh) =>
        await epicAkSBlazorJsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
            this, "getImageData", new object[] { sx, sy, sw, sh });
}
