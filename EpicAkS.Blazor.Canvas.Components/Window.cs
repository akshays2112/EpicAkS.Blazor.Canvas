namespace EpicAkS.Blazor.Canvas.Components
{
    public class Window
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MouseEvents MouseEvents { get; } = new MouseEvents();

        public KeyboardEvents KeyboardEvents { get; } = new KeyboardEvents();

        public delegate Task AsyncWindowDraw(Helpers.CanvasComponentInfo canvasComponentInfo);
        public event AsyncWindowDraw? Draw;

        public async Task DrawWindow(Helpers.CanvasComponentInfo canvasComponentInfo)
        {
            if (Draw is not null) await Draw(canvasComponentInfo);
        }

        public bool IsPointInWindow(int x, int y)
        {
            return x >= X && x <= X + Width && y >= Y && y <= Y + Height;
        }
    }
}
