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

    public static bool IsPointInRect(int x, int y, int X, int Y, int Width, int Height)
    {
        return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
    }
}
