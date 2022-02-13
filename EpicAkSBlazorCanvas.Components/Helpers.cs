namespace EpicAkSBlazorCanvas.Components;

public static class Helpers
{
    public class EpicAkSBlazorCanvasComponentInfo
    {
        public string? Id { get; set; }

        public EpicAkSBlazorCanvasClass? EpicAkSBlazorCanvas { get; set; }

        public MouseEvents EpicAkSBlazorCanvasComponentMouseEvents { get; set; } = new();

        public delegate Task CallOnRender();
    }

    public static List<EpicAkSBlazorCanvasComponentInfo> EpicAkSBlazorCanvasComponentInfos { get; set; } = new();

    public static EpicAkSBlazorCanvasComponentInfo? GetEpicAkSBlazorCanvasComponentInfoByIdGuid(string? id) => EpicAkSBlazorCanvasComponentInfos.Find(x => x.Id == id);
}
