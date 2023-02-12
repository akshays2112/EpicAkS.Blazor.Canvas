using System.Text.Json.Serialization;

namespace EpicAkS.Blazor.Canvas;

/// <summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getImageData</summary>
public class ImageDataSettings
{
    /// <summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getImageData</summary>
    [JsonPropertyName("colorSpace")]
    public string ColorSpace { get; set; } = "srgb";
}
