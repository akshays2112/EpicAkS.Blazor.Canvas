namespace EpicAkS.Blazor.Canvas.Components.BasicControls;

public class Button
{
    public Window? ButtonWindow { get; set; }

    public string Id { get; set; } = string.Empty;

    public int X { get; set; }

    public int Y { get; set; }

    public int Width { get; set; } = 100;

    public int Height { get; set; } = 50;

    public string Text { get; set; } = "Button";

    public string TextColor { get; set; } = "white";

    public string TextFont { get; set; } = "20px serif";

    public int TextFontHeight { get; set; } = 20;

    public string? ButtonColor { get; set; } = "red";

    public CanvasComponent? CanvasComponent { get; set; }

    public MouseEvents.AsyncMouseClick? MouseClick { get; set; }

    public KeyboardEvents.AsyncKeyPress? KeyPress { get; set; }

    public void InitButton()
    {
        ButtonWindow = new Window { Id = this.Id, X = this.X, Y = this.Y, Width = this.Width, Height = this.Height };
        CanvasComponent?.WindowManager.AddWindow(ButtonWindow);
        ButtonWindow.Draw += DrawButton;
        if (KeyPress is not null)
            ButtonWindow.KeyboardEvents.KeyPress += KeyPress;
        if (MouseClick is not null)
            ButtonWindow.MouseEvents.MouseClick += MouseClick;
    }

    public async Task DrawButton(Helpers.CanvasComponentInfo canvasComponentInfo)
    {
        CanvasClass? canvas = canvasComponentInfo?.Canvas;
        if (canvas is not null)
        {
            await canvas.ClearRect(X, Y, Width, Height);
            await canvas.SetFillStyle(ButtonColor);
            await canvas.FillRect(X, Y, Width, Height);
            await canvas.SetFillStyle(TextColor);
            await canvas.SetFont(TextFont);
            TextMetrics? textMetrics = await canvas.MeasureTextAndReturnNewTextMetrics(Text);
            if (textMetrics is not null)
                await canvas.FillText(Text, X + ((Width - (int)textMetrics.Width) / 2), Y + Height - TextFontHeight);
        }
    }
}
