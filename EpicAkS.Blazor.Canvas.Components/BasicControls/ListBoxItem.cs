using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
namespace EpicAkS.Blazor.Canvas.Components.BasicControls;

public class ListBoxItem
{
    public int Width { get; set; } = 100;

    public int Height { get; set; } = 20;

    public string Text { get; set; } = "Button";

    public string TextColor { get; set; } = "#656565";

    public string TextFont { get; set; } = "12px serif";

    public int TextFontHeight { get; set; } = 12;

    public string? BackgroundColor { get; set; } = "white";

    public int LeftPadding { get; set; } = 5;

    public void InitProperties(int width, int height, string text, string textColor, string textFont, int textFontHeight, string? backgroundColor)
    {
        Width = width;
        Height = height;
        Text = text;
        TextColor = textColor;
        TextFont = textFont;
        TextFontHeight = textFontHeight;
        BackgroundColor = backgroundColor;
    }

    public async Task DrawListItem(int x, int y, CanvasClass canvas)
    {
        await canvas.SetFont(TextFont);
        await canvas.SetFillStyle(TextColor);
        await canvas.FillText(Text, x + LeftPadding, y + ((Height + TextFontHeight) / 2));
    }
}
