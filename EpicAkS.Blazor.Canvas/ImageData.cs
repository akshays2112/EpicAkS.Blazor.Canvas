namespace EpicAkS.Blazor.Canvas;

///<summary></summary>
public class ImageData : ReturnVar
{
    private JsInterops jsInterops { get; init; }

    ///<summary></summary>
    public ImageData(CanvasClass Canvas)
    {
        this.jsInterops = Canvas.JsInterops;
    }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createImageData</summary>
    public async Task CreateImageData(int width, int height) =>
        await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
            this, "createImageData", new object[] { width, height });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createImageData</summary>
    public async Task CreateImageData(ImageData imageData) =>
        await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
            this, "createImageData", new object[] { imageData });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getImageData</summary>
    public async Task GetImageData(int sx, int sy, int sw, int sh) =>
        await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
            this, "getImageData", new object[] { sx, sy, sw, sh });
}
