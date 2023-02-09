using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;
using static EpicAkS.Blazor.Canvas.Components.Helpers;

namespace EpicAkS.Blazor.Canvas.Components
{
    public class WindowManager
    {
        public CanvasComponentInfo CanvasComponentInfo = null!;
        public readonly List<Window> Windows = new List<Window>();
        public readonly Window RootWindow = new Window();

        public WindowManager(CanvasComponentInfo canvasComponentInfo)
        {
            Windows.Add(RootWindow);
            CanvasComponentInfo = canvasComponentInfo;
            RootWindow.Width = canvasComponentInfo?.Canvas?.CanvasWidthHeightProp?.Width ?? 100;
            RootWindow.Height = canvasComponentInfo?.Canvas?.CanvasWidthHeightProp?.Height ?? 100;
        }

        public void AddWindow(Window window)
        {
            if(window != RootWindow)
                Windows.Add(window);
        }

        public void RemoveWindow(Window window)
        {
            if (window != RootWindow)
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

        public Window? GetWindowAt(int x, int y)
        {
            return Windows.FirstOrDefault(w => w.IsPointInWindow(x, y));
        }

        public async Task DoMouseEvents(MouseCoords mouseCoords, MouseEventTypes mouseEventTypes)
        {
            var window = GetWindowAt((int)mouseCoords.MouseX, (int)mouseCoords.MouseY);
            if (window is not null)
            {
                BringToFront(window);
                await window.MouseEvents.DoMouseEvent(mouseCoords, mouseEventTypes);
            }
        }
    }
}
