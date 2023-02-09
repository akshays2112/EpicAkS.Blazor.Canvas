namespace EpicAkS.Blazor.Canvas.Components;

public static class Helpers
{
    public class CanvasComponentInfo
    {
        public string? Id { get; set; }

        public CanvasClass? Canvas { get; set; }

        public delegate Task CallOnRender();
    }

    public static List<CanvasComponentInfo> CanvasComponentInfos { get; set; } = new();

    public static CanvasComponentInfo? GetCanvasComponentInfoByIdGuid(string? id) => CanvasComponentInfos.Find(x => x.Id == id);
}
