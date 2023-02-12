using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EpicAkS.Blazor.Canvas;

namespace EpicAkS.Blazor.Canvas.Components.BasicControls.Classes;

public class ListBoxItem
{
    public string Text { get; set; } = "ListBoxItem";

    public string TextColor { get; set; } = "black";

    public string TextFont { get; set; } = "12px serif";

    public int TextFontHeight { get; set; } = 12;

    public string? BackgroundColor { get; set; } = "white";

    public async Task DrawListBoxItem(Helpers.CanvasComponentInfo canvasComponentInfo, int clipX, int clipY, int clipWidth, int clipHeight)
    {
        if (canvasComponentInfo is null) return;
        CanvasClass? canvas = canvasComponentInfo.Canvas;
        if (canvas is null) return;
    }
}
