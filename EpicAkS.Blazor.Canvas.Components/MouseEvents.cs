using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;

namespace EpicAkS.Blazor.Canvas.Components;

public class MouseEvents
{
    public delegate Task AsyncMouseClick(MouseCoords mouseCoords);
    public event AsyncMouseClick? MouseClick;

    public delegate Task AsyncMouseDown(MouseCoords mouseCoords);
    public event AsyncMouseDown? MouseDown;

    public delegate Task AsyncMouseMove(MouseCoords mouseCoords);
    public event AsyncMouseMove? MouseMove;

    public delegate Task AsyncMouseOut(MouseCoords mouseCoords);
    public event AsyncMouseOut? MouseOut;

    public delegate Task AsyncMouseOver(MouseCoords mouseCoords);
    public event AsyncMouseOver? MouseOver;

    public delegate Task AsyncMouseUp(MouseCoords mouseCoords);
    public event AsyncMouseUp? MouseUp;

    public delegate Task AsyncMouseWheel(MouseCoords mouseCoords);
    public event AsyncMouseWheel? MouseWheel;

    public async Task DoMouseEvent(MouseCoords mouseCoords, MouseEventTypes mouseEventType)
    {
        switch (mouseEventType)
        {
            case MouseEventTypes.Click:
                if (MouseClick is not null) await MouseClick(mouseCoords);
                break;
            case MouseEventTypes.Down:
                if (MouseDown is not null) await MouseDown(mouseCoords);
                break;
            case MouseEventTypes.Move:
                if (MouseMove is not null) await MouseMove(mouseCoords);
                break;
            case MouseEventTypes.Out:
                if (MouseOut is not null) await MouseOut(mouseCoords);
                break;
            case MouseEventTypes.Over:
                if (MouseOver is not null) await MouseOver(mouseCoords);
                break;
            case MouseEventTypes.Up:
                if (MouseUp is not null) await MouseUp(mouseCoords);
                break;
            case MouseEventTypes.Wheel:
                if (MouseWheel is not null) await MouseWheel(mouseCoords);
                break;
        }
    }
}
