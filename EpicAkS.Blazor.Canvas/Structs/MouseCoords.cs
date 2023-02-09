using System.Text.Json.Serialization;
using EpicAkS.Blazor.Canvas.Enums;

namespace EpicAkS.Blazor.Canvas.Structs;

///<summary>Custom</summary>
public struct MouseCoords
{
    ///<summary>Custom</summary>
    public double MouseX { get; set; }

    ///<summary>Custom</summary>
    public double MouseY { get; set; }

    ///<summary>Custom</summary>
    [JsonPropertyName("ClientX")]
    public double ClientX { get; set; }

    ///<summary>Custom</summary>
    [JsonPropertyName("ClientY")]
    public double ClientY { get; set; }

    ///<summary>Custom</summary>
    public double OffsetLeft { get; set; }

    ///<summary>Custom</summary>
    public double OffsetTop { get; set; }

    ///<summary>Custom</summary>
    public MouseEventTypes MouseEventType { get; set; }
}
