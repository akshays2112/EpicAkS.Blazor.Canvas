using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;
using Microsoft.AspNetCore.Components.Web;
using static EpicAkS.Blazor.Canvas.Components.Helpers;

namespace EpicAkS.Blazor.Canvas.Components.BasicControls;

public class ListBox
{
    public Window? ListBoxWindow { get; set; }
    private List<ListBoxItem> visibleItems = new List<ListBoxItem>();
    private int topListBoxItemIndex = 0;
    public delegate Task AsyncMouseClick(MouseCoords mouseCoords, ListBox listBox, ListBoxItem listBoxItem);
    public Scrollbar? ScrollBar1;
    public string ScrollBar1Id = new Guid().ToString();

    public string Id { get; set; } = string.Empty;

    public int X { get; set; }

    public int Y { get; set; }

    public int Width { get; set; } = 100;

    public int Height { get; set; } = 50;

    public List<ListBoxItem> Items { get; set; } = new List<ListBoxItem>();

    public CanvasComponent? CanvasComponent { get; set; }

    public AsyncMouseClick? OnMouseClick { get; set; }

    public KeyboardEvents.AsyncKeyPress? OnKeyPress { get; set; }

    public void InitListBox()
    {
        ListBoxWindow = new Window { Id = this.Id, X = this.X, Y = this.Y, Width = this.Width, Height = this.Height };
        CanvasComponent?.WindowManager.AddWindow(ListBoxWindow);
        ListBoxWindow.Draw += DrawListBox;
        ListBoxWindow.KeyboardEvents.KeyPress += KeyPress;
        ListBoxWindow.MouseEvents.MouseClick += MouseClick;
        if (CanvasComponent is not null)
        {
            ScrollBar1 = new Scrollbar(ScrollBar1Id, X + Width, Y, 11, Height, Items.Count, true, CanvasComponent);
            ScrollBar1.OnScroll += Scrollbar_OnScroll;
        }
    }

    public async Task MouseClick(MouseCoords mouseCoords)
    {
        int currentOffsetY = 0;
        for (int i = 0; i < visibleItems.Count; i++)
        {
            if (IsPointInRect((int)mouseCoords.OffsetLeft, (int)mouseCoords.OffsetTop, X, Y + currentOffsetY, visibleItems[i].Width, visibleItems[i].Height))
            {
                if (OnMouseClick is not null)
                {
                    await OnMouseClick(mouseCoords, this, visibleItems[i]);
                }
                break;
            }
            currentOffsetY += visibleItems[i].Height;
        }
    }

    public async Task KeyPress(KeyboardEventTypes keyboardEventType, KeyboardEventArgs keyboardEventArgs)
    {
        if (OnKeyPress is not null)
        {
            await OnKeyPress(keyboardEventType, keyboardEventArgs);
        }
    }

    public async Task Scrollbar_OnScroll(int scrollPos, int topItemIndex)
    {
        topListBoxItemIndex = topItemIndex;
        if (CanvasComponent?.CanvasComponentInfo is not null)
            await DrawListBox(CanvasComponent.CanvasComponentInfo);
    }

    public async Task DrawListBox(EpicAkS.Blazor.Canvas.Components.Helpers.CanvasComponentInfo canvasComponentInfo)
    {
        CanvasClass? canvas = canvasComponentInfo?.Canvas;
        if (canvas is not null)
        {
            await canvas.ClearRect(X, Y, Width, Height);
            await canvas.SetStrokeStyle("#ebebeb");
            await canvas.SetLineWidth(1);
            await canvas.StrokeRect(X, Y, Width, Height);
            visibleItems.Clear();
            int currentYOffset = 1;
            for (int i = topListBoxItemIndex; i < Items.Count && currentYOffset < Height; i++)
            {
                await canvas.Save();
                await canvas.BeginPath();
                await canvas.MoveTo(X + 1, Y + currentYOffset);
                await canvas.LineTo(X + Width - 1, Y + currentYOffset);
                await canvas.LineTo(X + Width - 1, Y + currentYOffset + Items[i].Height);
                await canvas.LineTo(X + 1, Y + currentYOffset + Items[i].Height);
                await canvas.ClosePath();
                await canvas.Clip();
                await Items[i].DrawListItem(X + 1, Y + currentYOffset, canvas);
                await canvas.Restore();
                visibleItems.Add(Items[i]);
                currentYOffset += Items[i].Height;
            }
            if (ScrollBar1 is not null && canvasComponentInfo is not null)
            {
                await ScrollBar1.DrawScrollBar(canvasComponentInfo);
            }
        }
    }
}
