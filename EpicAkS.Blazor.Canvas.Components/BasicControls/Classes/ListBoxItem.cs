namespace EpicAkS.Blazor.Canvas.Components.BasicControls.Classes;

public class ListBoxItem
{
    public int Width { get; set; } = 100;

    public int Height { get; set; } = 50;

    public string Text { get; set; } = "ListBoxItem";

    public string TextColor { get; set; } = "black";

    public string TextFont { get; set; } = "12px serif";

    public int TextFontHeight { get; set; } = 12;

    public string? BackgroundColor { get; set; } = "white";

    public async Task DrawListBoxItem(Helpers.CanvasComponentInfo canvasComponentInfo, int X, int Y)
    {
        if (canvasComponentInfo is null) return;
        CanvasClass? canvas = canvasComponentInfo.Canvas;
        if (canvas is null) return;
        await canvas.SetFillStyle(BackgroundColor ?? "white");
        await canvas.FillRect(X, Y, Width, Height);
        if (string.IsNullOrEmpty(Text)) return;
        await canvas.SetFillStyle(TextColor ?? "black");
        await canvas.SetFont(TextFont ?? "12px serif");
        TextMetrics? textMetrics = await canvas.MeasureTextAndReturnNewTextMetrics(Text);
        if (textMetrics is not null)
            await canvas.FillText(Text, X + ((Width - (int)textMetrics.Width) / 2), Y + Height - TextFontHeight);
    }
}
