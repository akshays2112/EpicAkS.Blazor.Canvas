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
        public delegate Task AsyncKeyDown(KeyboardEventTypes keyboardEventType, string key);
        public event AsyncKeyDown? KeyDown;

        public delegate Task AsyncKeyUp(KeyboardEventTypes keyboardEventType, string key);
        public event AsyncKeyUp? KeyUp;

        public delegate Task AsyncKeyPress(KeyboardEventTypes keyboardEventType, string key);
        public event AsyncKeyPress? KeyPress;

        public async Task OnKeyDown(KeyboardEventTypes keyboardEventType, string key)
        {
            if (KeyDown is not null)
                await KeyDown(keyboardEventType, key);
        }

        public async Task OnKeyUp(KeyboardEventTypes keyboardEventType, string key)
        {
            if (KeyUp is not null)
                await KeyUp(keyboardEventType, key);
        }

        public async Task OnKeyPress(KeyboardEventTypes keyboardEventType, string key)
        {
            if (KeyPress is not null)
                await KeyPress(keyboardEventType, key);
        }

        public async Task DoKeyboardEvent(KeyboardEventTypes keyboardEventType, string key)
        {
            switch (keyboardEventType)
            {
                case KeyboardEventTypes.KeyDown:
                    await OnKeyDown(keyboardEventType, key);
                    break;
                case KeyboardEventTypes.KeyUp:
                    await OnKeyUp(keyboardEventType, key);
                    break;
                case KeyboardEventTypes.KeyPress:
                    await OnKeyPress(keyboardEventType, key);
                    break;
                default:
                    break;
            }
        }
    }
}
