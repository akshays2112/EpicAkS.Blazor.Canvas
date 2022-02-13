using EpicAkSBlazorCanvas.Enums;
using EpicAkSBlazorCanvas.Structs;

namespace EpicAkSBlazorCanvas.Components;

public class MouseEvents
{
    public delegate void mouseClick(MouseCoords mouseCoords);
    public event mouseClick? MouseClick;

    public delegate void mouseDown(MouseCoords mouseCoords);
    public event mouseDown? MouseDown;

    public delegate void mouseMove(MouseCoords mouseCoords);
    public event mouseMove? MouseMove;

    public delegate void mouseOut(MouseCoords mouseCoords);
    public event mouseOut? MouseOut;

    public delegate void mouseOver(MouseCoords mouseCoords);
    public event mouseOver? MouseOver;

    public delegate void mouseUp(MouseCoords mouseCoords);
    public event mouseUp? MouseUp;

    public delegate void mouseWheel(MouseCoords mouseCoords);
    public event mouseWheel? MouseWheel;

    public void DoMouseEvent(MouseCoords mouseCoords, MouseEventTypes mouseEventType)
    {
        switch (mouseEventType)
        {
            case MouseEventTypes.Click:
                if (MouseClick is not null) MouseClick(mouseCoords);
                break;
            case MouseEventTypes.Down:
                if (MouseDown is not null) MouseDown(mouseCoords);
                break;
            case MouseEventTypes.Move:
                if (MouseMove is not null) MouseMove(mouseCoords);
                break;
            case MouseEventTypes.Out:
                if (MouseOut is not null) MouseOut(mouseCoords);
                break;
            case MouseEventTypes.Over:
                if (MouseOver is not null) MouseOver(mouseCoords);
                break;
            case MouseEventTypes.Up:
                if (MouseUp is not null) MouseUp(mouseCoords);
                break;
            case MouseEventTypes.Wheel:
                if (MouseWheel is not null) MouseWheel(mouseCoords);
                break;
        }
    }
}
