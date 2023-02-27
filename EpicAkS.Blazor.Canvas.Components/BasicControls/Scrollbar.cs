using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;
using Microsoft.AspNetCore.Components.Web;
using static EpicAkS.Blazor.Canvas.Components.Helpers;

namespace EpicAkS.Blazor.Canvas.Components.BasicControls;

public class Scrollbar
{
    public Window? ScrollBarWindow { get; set; }
    public int CurrentScrollPos { get; set; }
    public int TopItemIndex { get; set; }
    public delegate Task AsyncScroll(int scrollPos, int topItemIndex);
    public event AsyncScroll? OnScroll;

    public string Id { get; set; } = string.Empty;

    public int X { get; set; }

    public int Y { get; set; }

    public int Width { get; set; } = 11;

    public int Height { get; set; } = 100;

    public int MaxItems { get; set; } = 0;

    public bool IsVertical { get; set; } = true;

    public CanvasComponent? CanvasComponent { get; set; }

    public Scrollbar(string id, int x, int y, int width, int height, int maxItems, bool isVertical, CanvasComponent canvasComponent)
    {
        Id = id;
        X = x;
        Y = y;
        Width = width;
        Height = height;
        MaxItems = maxItems;
        IsVertical = isVertical;
        CanvasComponent = canvasComponent;
        ScrollBarWindow = new Window { Id = id, X = x, Y = y, Width = width, Height = height };
        canvasComponent?.WindowManager.AddWindow(ScrollBarWindow);
        ScrollBarWindow.Draw += DrawScrollBar;
        ScrollBarWindow.KeyboardEvents.KeyPress += KeyPress;
        ScrollBarWindow.MouseEvents.MouseClick += MouseClick;
    }

    public async Task MouseClick(MouseCoords mouseCoords)
    {
        if (IsPointInRect((int)mouseCoords.OffsetLeft, (int)mouseCoords.OffsetTop, X, Y + Height - 11, 11, 11))
        {
            if (TopItemIndex < MaxItems - 1)
            {
                TopItemIndex++;
                CurrentScrollPos = ((Height - 22) * TopItemIndex) / MaxItems;
                if (CanvasComponent?.CanvasComponentInfo is not null)
                    await DrawScrollBar(CanvasComponent.CanvasComponentInfo);
                if (OnScroll is not null)
                    await OnScroll(CurrentScrollPos, TopItemIndex);
            }
        } 
        else if(IsPointInRect((int)mouseCoords.OffsetLeft, (int)mouseCoords.OffsetTop, X, Y, 11, 11))
        {
            if(TopItemIndex > 0)
            {
                TopItemIndex--;
                CurrentScrollPos = ((Height - 22) * TopItemIndex) / MaxItems;
                if (CanvasComponent?.CanvasComponentInfo is not null)
                    await DrawScrollBar(CanvasComponent.CanvasComponentInfo);
                if (OnScroll is not null)
                    await OnScroll(CurrentScrollPos, TopItemIndex);
            }
        }
    }

    public async Task KeyPress(KeyboardEventTypes keyboardEventType, KeyboardEventArgs keyboardEventArgs)
    {
    }

    public async Task DrawScrollBar(EpicAkS.Blazor.Canvas.Components.Helpers.CanvasComponentInfo canvasComponentInfo)
    {
        CanvasClass? canvas = canvasComponentInfo?.Canvas;
        if (canvas is not null)
        {
            await canvas.SetFillStyle("#F1F1F1");
            await canvas.FillRect(X, Y, Width, Height);
            if (IsVertical)
            {
                await canvas.SetFillStyle("#A3A3A3");
                await canvas.BeginPath();
                await canvas.MoveTo(X + 2, Y + 9);
                await canvas.LineTo(X + 9, Y + 9);
                await canvas.LineTo(X + 6, Y + 5);
                await canvas.ClosePath();
                await canvas.Fill();
                await canvas.BeginPath();
                await canvas.MoveTo(X + 2, Y + Height - 9);
                await canvas.LineTo(X + 9, Y + Height - 9);
                await canvas.LineTo(X + 6, Y + Height - 5);
                await canvas.ClosePath();
                await canvas.Fill();
                CurrentScrollPos = ((Height - 22) * TopItemIndex) / MaxItems;
                await canvas.SetFillStyle("#BCBCBC");
                await canvas.FillRect(X + 3, Y + 12 + CurrentScrollPos, 5, 18);
                await canvas.SetStrokeStyle("#A8A8A8");
                await canvas.StrokeRect(X + 2, Y + 11 + CurrentScrollPos, 7, 20);
            }
        }
    }
}
