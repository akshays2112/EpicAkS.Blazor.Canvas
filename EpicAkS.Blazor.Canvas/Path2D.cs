﻿namespace EpicAkS.Blazor.Canvas;

///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D</summary>
public class Path2D : ReturnVar
{
    private JsInterops jsInterops { get; init; }

    ///<summary></summary>
    public Path2D(CanvasClass Canvas)
    {
        this.jsInterops = Canvas.JsInterops;
    }

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D</summary>
    public async Task CreatePath2D() =>
        await jsInterops.CallFunctionWithNewVarToHold(this, "Path2D");

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D/addPath</summary>
    public async Task AddPath(Path2D path) =>
        await jsInterops.CallFunctionWithExistingVarParameterOnExistingVarToHold(this, "addPath", path);

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task ClosePath() => await jsInterops.CallFunctionOnExistingVarToHold(this, "closePath");

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task MoveTo(int x, int y) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "moveTo", new object[] { x, y });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task LineTo(int x, int y) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "lineTo", 
            new object[] { x, y });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task BezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, int x, int y) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "bezierCurveTo",
            new object[] { cp1x, cp1y, cp2x, cp2y, x, y });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task QuadraticCurveTo(int cpx, int cpy, int x, int y) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "quadraticCurveTo",
            new object[] { cpx, cpy, x, y });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    internal async Task Arc(int x, int y, int radius, int startAngle, int endAngle, bool counterclockwise = false) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "arc",
            new object[] { x, y, radius, startAngle, endAngle, counterclockwise });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task ArcTo(int x1, int y1, int x2, int y2, int radius) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "arcTo", 
            new object[] { x1, y1, x2, y2, radius });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task Ellipse(int x, int y, int radiusX, int radiusY, int rotation, int startAngle,
        int endAngle, bool counterclockwise = false) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "ellipse",
            new object[] { x, y, radiusX, radiusY, rotation, startAngle, endAngle, counterclockwise });

    ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/Path2D#methods</summary>
    public async Task Rect(int x, int y, int width, int height) =>
        await jsInterops.CallFunctionWithParametersOnExistingVarToHold(this, "rect", 
            new object[] { x, y, width, height });
}
