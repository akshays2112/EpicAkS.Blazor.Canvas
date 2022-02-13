using System.Text.Json.Serialization;

namespace EpicAkSBlazorCanvas;

///<summary></summary>
public class EpicAkSReturnVar
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
    public EpicAkSReturnVar()
    {
        VarId = Guid.NewGuid();
        VarIdString = VarId.ToString();
    }
}
