﻿using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;
using Microsoft.AspNetCore.Components.Web;
using static EpicAkS.Blazor.Canvas.Components.Helpers;

namespace EpicAkS.Blazor.Canvas.Components
{
    public class WindowManager
    {
        public CanvasComponentInfo CanvasComponentInfo = null!;
        public readonly List<Window> Windows = new List<Window>();
        public readonly Window RootWindow = new Window();
        public Window WindowWithFocus = null!;

        public WindowManager(CanvasComponentInfo canvasComponentInfo)
        {
            Windows.Add(RootWindow);
            CanvasComponentInfo = canvasComponentInfo;
            RootWindow.Width = canvasComponentInfo?.Canvas?.CanvasWidthHeightProp?.Width ?? 100;
            RootWindow.Height = canvasComponentInfo?.Canvas?.CanvasWidthHeightProp?.Height ?? 100;
            WindowWithFocus = RootWindow;
        }

        public void AddWindow(Window window)
        {
            if(window != RootWindow && Windows.Find(w => w.Id == window.Id) is null)
                Windows.Add(window);
        }

        public void RemoveWindow(Window window)
        {
            if (window != RootWindow && Windows.Find(w => w.Id == window.Id) is not null)
                Windows.Remove(window);
        }

        public void BringToFront(Window window)
        {
            if (window != RootWindow)
            {
                Windows.Remove(window);
                Windows.Add(window);
            }
        }

        public void SendToBack(Window window)
        {
            if (window != RootWindow)
            {
                Windows.Remove(window);
                Windows.Insert(0, window);
            }
        }

        public async Task DrawWindows()
        {
            foreach (var window in Windows)
            {
                if(window is not null)
                    await window.DrawWindow(CanvasComponentInfo);
            }
        }

        public Window? GetWindowAt(int x, int y)
        {
            return Windows.LastOrDefault(w => w.IsPointInWindow(x, y));
        }

        public async Task DoMouseEvents(MouseCoords mouseCoords, MouseEventTypes mouseEventTypes)
        {
            var window = GetWindowAt((int)mouseCoords.OffsetLeft, (int)mouseCoords.OffsetTop);
            if (window is not null)
            {
                WindowWithFocus = window;
                await window.MouseEvents.DoMouseEvent(mouseCoords, mouseEventTypes);
            }
        }

        public async Task DoKeyboardEvents(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs)
        {
            await WindowWithFocus.KeyboardEvents.DoKeyboardEvent(keyboardEventType, eventArgs);
        }
    }
}
