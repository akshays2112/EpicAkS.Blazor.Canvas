namespace EpicAkS.Blazor.Canvas;

///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasGradient</summary>
public class Gradient : ReturnVar
{
    private JsInterops jsInterops { get; init; }

    ///<summary></summary>
    public Gradient(CanvasClass Canvas) => this.jsInterops = Canvas.JsInterops;

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createConicGradient</summary>
    public async Task CreateConicGradient(double startAngle, int x, int y) =>
        await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHold(
            this, "createConicGradient", new object[] { startAngle, x, y });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createLinearGradient</summary>
    public async Task CreateLinearGradient(int x0, int y0, int x1, int y1) =>
        await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHold(
            this, "createLinearGradient", new object[] { x0, y0, x1, y1 });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createRadialGradient</summary>
    public async Task CreateRadialGradient(int x0, int y0, double r0, int x1, int y1, double r1) =>
        await jsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHold(
            this, "createRadialGradient", new object[] { x0, y0, r0, x1, y1, r1 });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/createPattern</summary>
    public void CreatePattern() => throw new NotImplementedException();

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasGradient/addColorStop</summary>
    public async Task AddColorStop(double offset, string color) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "addColorStop",
            new object[] { offset, color });
}
