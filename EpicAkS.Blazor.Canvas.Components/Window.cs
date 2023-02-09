using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpicAkS.Blazor.Canvas.Components
{
    public class Window
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int ZOrder { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MouseEvents MouseEvents { get; } = new MouseEvents();

        public bool IsPointInWindow(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}
