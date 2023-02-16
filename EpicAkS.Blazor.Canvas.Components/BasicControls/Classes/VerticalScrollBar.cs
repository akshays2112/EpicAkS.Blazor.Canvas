namespace EpicAkS.Blazor.Canvas.Components.BasicControls.Classes;

public class VerticalScrollBar
{
    public int Width { get; set; } = 11;

    public int Height { get; set; } = 100;

    public int MaxItems { get; set; } = 0;

    public int CurrentItem { get; set; } = 0;

    public string ThemeColor { get; set; } = "gray";

    public async Task DrawVerticalScrollBar(Helpers.CanvasComponentInfo canvasComponentInfo, int X, int Y)
    {
        if (canvasComponentInfo is null) return;
        CanvasClass? canvas = canvasComponentInfo.Canvas;
        if (canvas is null) return;
        await canvas.SetFillStyle(ThemeColor);
        await canvas.FillRect(X, Y, Width, Height);
        await canvas.SetFillStyle("darkgray");
        await canvas.FillRect(X, Y + ((CurrentItem * Height) / MaxItems), Width, 10);
    }
}
