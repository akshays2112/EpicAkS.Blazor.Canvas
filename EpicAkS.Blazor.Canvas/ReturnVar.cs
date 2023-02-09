using System.Text.Json.Serialization;

namespace EpicAkS.Blazor.Canvas;

///<summary></summary>
public class ReturnVar
{
    ///<summary></summary>
    [JsonPropertyName("varId")]
    public Guid VarId { get; set; }

    ///<summary></summary>
    [JsonPropertyName("varIdString")]
    public string VarIdString { get; set; }

    ///<summary></summary>
    public string[]? PropertyNames { get; init; }

    ///<summary></summary>
    public ReturnVar()
    {
        VarId = Guid.NewGuid();
        VarIdString = VarId.ToString();
    }
}
