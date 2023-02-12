using EpicAkS.Blazor.Canvas.Enums;
using System.Text.Json.Serialization;

namespace EpicAkS.Blazor.Canvas;

///<summary></summary>
public class ImageData : ReturnVar
{
    private JsInterops jsInterops { get; init; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/ImageData</summary>
    [JsonPropertyName("data")]
    public byte[]? Data { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/ImageData</summary>
    [JsonPropertyName("colorSpace")]
    public string ColorSpace { get; init; } = string.Empty;

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/ImageData</summary>
    [JsonPropertyName("width")]
    public ulong Width { get; init; } = 0;

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/ImageData</summary>
    [JsonPropertyName("height")]
    public ulong Height { get; init; } = 0;

    ///<summary></summary>
    public ImageData(CanvasClass Canvas)
    {
        this.jsInterops = Canvas.JsInterops;
    }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createImageData</summary>
    public async Task<ImageData?> CreateImageData(int width, int height) => throw new NotImplementedException();
        //await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
        //    this, "createImageData", new object[] { width, height });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createImageData</summary>
    public async Task<ImageData?> CreateImageData(ImageData imageData) => throw new NotImplementedException();
        //await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
        //    this, "createImageData", new object[] { imageData });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getImageData</summary>
    public async Task<ImageData?> GetImageData(int sx, int sy, int sw, int sh) => throw new NotImplementedException();
        //await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
        //    this, "getImageData", new object[] { sx, sy, sw, sh });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getImageData</summary>
    public async Task<ImageData?> GetImageData(int sx, int sy, int sWidth, int sHeight, ColorSpaceTypes colorSpaceType)
         => throw new NotImplementedException();
    //{
    //    ImageDataSettings imageDataSettings = new();
    //    switch (colorSpaceType)
    //    {
    //        case ColorSpaceTypes.srgb:
    //            imageDataSettings.ColorSpace = "srgb";
    //            break;
    //        case ColorSpaceTypes.display_p3:
    //            imageDataSettings.ColorSpace = "display-p3";
    //            break;
    //    }
    //    return await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
    //        this, "getImageData", new object[] { sx, sy, sWidth, sHeight, imageDataSettings });
    //}
}
