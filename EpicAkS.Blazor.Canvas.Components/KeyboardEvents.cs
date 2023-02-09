using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;
using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicAkS.Blazor.Canvas.Components
{
    public class KeyboardEvents
    {
        public delegate Task AsyncKeyDown(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs);
        public event AsyncKeyDown? KeyDown;

        public delegate Task AsyncKeyUp(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs);
        public event AsyncKeyUp? KeyUp;

        public delegate Task AsyncKeyPress(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs);
        public event AsyncKeyPress? KeyPress;

        public async Task OnKeyDown(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs)
        {
            if (KeyDown is not null)
                await KeyDown(keyboardEventType, eventArgs);
        }

        public async Task OnKeyUp(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs)
        {
            if (KeyUp is not null)
                await KeyUp(keyboardEventType, eventArgs);
        }

        public async Task OnKeyPress(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs)
        {
            if (KeyPress is not null)
                await KeyPress(keyboardEventType, eventArgs);
        }

        public async Task DoKeyboardEvent(KeyboardEventTypes keyboardEventType, KeyboardEventArgs eventArgs)
        {
            switch (keyboardEventType)
            {
                case KeyboardEventTypes.KeyDown:
                    await OnKeyDown(keyboardEventType, eventArgs);
                    break;
                case KeyboardEventTypes.KeyUp:
                    await OnKeyUp(keyboardEventType, eventArgs);
                    break;
                case KeyboardEventTypes.KeyPress:
                    await OnKeyPress(keyboardEventType, eventArgs);
                    break;
                default:
                    break;
            }
        }
    }
}
