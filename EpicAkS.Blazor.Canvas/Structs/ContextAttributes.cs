using System.Text.Json.Serialization;

namespace EpicAkS.Blazor.Canvas.Structs;

///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getContextAttributes</summary>
public struct ContextAttributes
{
    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getContextAttributes</summary>
    [JsonPropertyName("alpha")]
    public bool Alpha { get; set; }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getContextAttributes</summary>
    [JsonPropertyName("desynchronized")]
    public bool Desynchronized { get; set; }
}
