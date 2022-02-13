namespace EpicAkSBlazorCanvas.Structs;

///<summary>Custom</summary>
public struct EpicAkSBlazorCanvasHelpers
{
    ///<summary>Custom</summary>
    public static string[] FillPropertyNames(Type type)
    {
        List<string> pNames = new();
        type.GetProperties().ToList().ForEach(p => pNames.Add($"{p.Name[0].ToString().ToLower()}{p.Name[1..]}"));
        return pNames.ToArray<string>();
    }
}
