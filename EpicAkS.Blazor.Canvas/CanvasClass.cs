using System.Text.Json;
using Microsoft.JSInterop;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using EpicAkS.Blazor.Canvas.Enums;
using EpicAkS.Blazor.Canvas.Structs;

namespace EpicAkS.Blazor.Canvas
{
    ///<summary></summary>
    public partial class CanvasClass
    {
        internal JsInterops JsInterops { get; init; }

        ///<summary></summary>
        public ElementReference DivCanvas { get; set; }

        ///<summary></summary>
        public CanvasWidthHeight? CanvasWidthHeightProp { get; set; }

        ///<summary></summary>
        public string CanvasId { get; set; } = "EpicAkS.Blazor.Canvas1";

        ///<summary></summary>
        public CanvasClass(IJSRuntime jsRuntime)
        {
            this.JsInterops = new(jsRuntime);
        }

        #region Div parent wrapping Canvas for Mouse Events processing

        ///<summary></summary>
        public async Task CreateCanvas(ElementReference divCanvas, string canvasId)
        {
            DivCanvas = divCanvas;
            CanvasId = canvasId;
            CanvasWidthHeightProp = JsonSerializer.Deserialize<CanvasWidthHeight?>(
                await JsInterops.CreateCanvasForDivElementReferenceWithId(divCanvas, canvasId));
        }

        ///<summary></summary>
        public async Task CreateCanvas(ElementReference divCanvas, string canvasId, ContextAttributes contextAttributes)
        {
            DivCanvas = divCanvas;
            CanvasId = canvasId;
            CanvasWidthHeightProp = JsonSerializer.Deserialize<CanvasWidthHeight?>(
                await JsInterops.CreateCanvasForDivElementReferenceWithIdWithContextAttributes(divCanvas, canvasId, contextAttributes));
        }

        ///<summary></summary>
        public async Task SetCurrentCanvas2DContext() => await JsInterops.SetCurrentCanvas2DContext(CanvasId);

        ///<summary></summary>
        public async Task<MouseCoords> GetMouseCoords(MouseEventArgs eventArgs, MouseEventTypes mouseEventType)
        {
            string? data = await JsInterops.GetMouseXY((int)eventArgs.ClientX, (int)eventArgs.ClientY);
            if (data is not null)
            {
                MouseCoords coords = JsonSerializer.Deserialize<MouseCoords>(data);
                coords.ClientX = eventArgs.ClientX;
                coords.ClientY = eventArgs.ClientY;
                coords.MouseX = coords.MouseX;
                coords.MouseY = coords.MouseY;
                coords.OffsetLeft = eventArgs.OffsetX; 
                coords.OffsetTop = eventArgs.OffsetY;
                coords.MouseEventType = mouseEventType;
                return coords;
            }
            return new();
        }

        #endregion

        #region Drawing Rectangles

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/clearRect</summary>
        public async Task ClearRect(int x, int y, int width, int height) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("clearRect", new object[] { x, y, width, height });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillRect</summary>
        public async Task FillRect(int x, int y, int width, int height) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("fillRect", new object[] { x, y, width, height });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/strokeRect</summary>
        public async Task StrokeRect(int x, int y, int width, int height) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("strokeRect", new object[] { x, y, width, height });

        #endregion

        #region Drawing Text

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillText</summary>
        public async Task FillText(string text, int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("fillText", new object[] { text, x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillText</summary>
        public async Task FillText(string text, int x, int y, int maxWidth) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("fillText", new object[] { text, x, y, maxWidth });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/strokeText</summary>
        public async Task StrokeText(string text, int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("strokeText", new object[] { text, x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/strokeText</summary>
        public async Task StrokeText(string text, int x, int y, int maxWidth) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("strokeText", new object[] { text, x, y, maxWidth });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/measureText</summary>
        public async Task<TextMetrics> MeasureTextAndReturnNewTextMetrics(string text)
        {
            TextMetrics textMetrics = new();
            await JsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHold(
                textMetrics, "measureText", new object[] { text });
            return textMetrics;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/TextMetrics</summary>
        public async Task<TextMetrics?> GetTextMetric(TextMetrics textMetrics) =>
            await JsInterops.GetVarIdPropsFromVarsToHold(textMetrics);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/measureText</summary>
        public async Task<TextMetrics?> MeasureTextAndReturnNewFilledTextMetrics(string text) =>
            await JsInterops.CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn(
                new TextMetrics(), "measureText", new object[] { text });

        #endregion

        #region Line styles

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineWidth</summary>
        public async Task<double?> GetLineWidth() =>
            await JsInterops.GetCanvas2DContextProperty<double?>("lineWidth");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineWidth</summary>
        public async Task SetLineWidth(double? lineWidth) =>
            await JsInterops.SetCanvas2DContextProperty("lineWidth", lineWidth);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineCap</summary>
        public async Task<double?> GetLineCap() =>
            await JsInterops.GetCanvas2DContextProperty<double?>("lineCap");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineCap</summary>
        public async Task SetLineCap(double? lineCap) =>
            await JsInterops.SetCanvas2DContextProperty("lineCap", lineCap);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineJoin</summary>
        public async Task<LineJoinTypes?> GetLineJoin()
        {
            LineJoinTypes? lineJoinType = null;
            switch(await JsInterops.GetCanvas2DContextProperty<string?>("lineJoin"))
            {
                case "bevel":
                    lineJoinType = LineJoinTypes.bevel;
                    break;
                case "round":
                    lineJoinType = LineJoinTypes.round;
                    break;
                case "miter":
                    lineJoinType = LineJoinTypes.miter;
                    break;
            }
            return lineJoinType;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineJoin</summary>
        public async Task SetLineJoin(LineJoinTypes? lineJoin)
        {
            string strLineJoin = string.Empty;
            switch(lineJoin)
            {
                case LineJoinTypes.bevel:
                    strLineJoin = "bevel";
                    break;
                case LineJoinTypes.round:
                    strLineJoin = "round";
                    break;
                case LineJoinTypes.miter:
                    strLineJoin = "miter";
                    break;
            }
            await JsInterops.SetCanvas2DContextProperty("lineJoin", strLineJoin);
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/miterLimit</summary>
        public async Task<double?> GetMiterLimit() =>
            await JsInterops.GetCanvas2DContextProperty<double?>("miterLimit");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/miterLimit</summary>
        public async Task SetMiterLimit(double? miterLimit) => 
            await JsInterops.SetCanvas2DContextProperty("miterLimit", miterLimit);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getLineDash</summary>
        public async Task<int?[]?> GetLineDash() => 
            await JsInterops.CallCanvas2DContextFunctionWithReturn<int?[]?>("getLineDash");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/setLineDash</summary>
        public async Task SetLineDash(int[]? segments)
        {
            int[]? s = segments ?? Array.Empty<int>();
            await JsInterops.CallCanvas2DContextFunctionWithParameters("setLineDash", new object[] { s });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset</summary>
        public async Task<double?> GetLineDashOffset() =>
            await JsInterops.GetCanvas2DContextProperty<double?>("lineDashOffset");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset</summary>
        public async Task SetLineDashOffset(double? lineDashOffset) =>
            await JsInterops.SetCanvas2DContextProperty("lineDashOffset", lineDashOffset);

        #endregion

        #region Text styles

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/font</summary>
        public async Task<double?> GetFont() =>
            await JsInterops.GetCanvas2DContextProperty<double?>("font");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/font</summary>
        public async Task SetFont(string? font) =>
            await JsInterops.SetCanvas2DContextProperty("font", font);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/textAlign</summary>
        public async Task<TextAlignTypes?> GetTextAlign()
        {
            TextAlignTypes? textAlignType = null;
            switch (await JsInterops.GetCanvas2DContextProperty<string?>("textAlign"))
            {
                case "left":
                    textAlignType = TextAlignTypes.left;
                    break;
                case "right":
                    textAlignType = TextAlignTypes.right;
                    break;
                case "center":
                    textAlignType = TextAlignTypes.center;
                    break;
                case "start":
                    textAlignType = TextAlignTypes.start;
                    break;
                case "end":
                    textAlignType = TextAlignTypes.end;
                    break;
            }
            return textAlignType;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/textAlign</summary>
        public async Task SetTextAlign(TextAlignTypes? textAlign)
        {
            string strTextAlign = string.Empty;
            switch (textAlign)
            {
                case TextAlignTypes.left:
                    strTextAlign = "left";
                    break;
                case TextAlignTypes.right:
                    strTextAlign = "right";
                    break;
                case TextAlignTypes.center:
                    strTextAlign = "center";
                    break;
                case TextAlignTypes.start:
                    strTextAlign = "start";
                    break;
                case TextAlignTypes.end:
                    strTextAlign = "end";
                    break;
            }
            await JsInterops.SetCanvas2DContextProperty("textAlign", strTextAlign);
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/textBaseline</summary>
        public async Task<TextBaselineTypes?> GetTextBaseline()
        {
            TextBaselineTypes? textBaselineType = null;
            switch (await JsInterops.GetCanvas2DContextProperty<string?>("textBaseline"))
            {
                case "top":
                    textBaselineType = TextBaselineTypes.top;
                    break;
                case "hanging":
                    textBaselineType = TextBaselineTypes.hanging;
                    break;
                case "middle":
                    textBaselineType = TextBaselineTypes.middle;
                    break;
                case "alphabetic":
                    textBaselineType = TextBaselineTypes.alphabetic;
                    break;
                case "ideographic":
                    textBaselineType = TextBaselineTypes.ideographic;
                    break;
                case "bottom":
                    textBaselineType = TextBaselineTypes.bottom;
                    break;
            }
            return textBaselineType;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/textBaseline</summary>
        public async Task SetTextBaseline(TextBaselineTypes? textBaselineType)
        {
            string strTextBaseline = string.Empty;
            switch (textBaselineType)
            {
                case TextBaselineTypes.top:
                    strTextBaseline = "top";
                    break;
                case TextBaselineTypes.hanging:
                    strTextBaseline = "hanging";
                    break;
                case TextBaselineTypes.middle:
                    strTextBaseline = "middle";
                    break;
                case TextBaselineTypes.alphabetic:
                    strTextBaseline = "alphabetic";
                    break;
                case TextBaselineTypes.ideographic:
                    strTextBaseline = "ideographic";
                    break;
                case TextBaselineTypes.bottom:
                    strTextBaseline = "bottom";
                    break;
            }
            await JsInterops.SetCanvas2DContextProperty("textBaseline", strTextBaseline);
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/direction</summary>
        public async Task<DirectionTypes?> GetDirection()
        {
            DirectionTypes? directionType = null;
            switch (await JsInterops.GetCanvas2DContextProperty<string?>("direction"))
            {
                case "ltr":
                    directionType = DirectionTypes.ltr;
                    break;
                case "rtl":
                    directionType = DirectionTypes.rtl;
                    break;
                case "inherit":
                    directionType = DirectionTypes.inherit;
                    break;
            }
            return directionType;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/direction</summary>
        public async Task SetDirection(DirectionTypes? textBaselineType)
        {
            string strDirectionType = string.Empty;
            switch (textBaselineType)
            {
                case DirectionTypes.ltr:
                    strDirectionType = "ltr";
                    break;
                case DirectionTypes.rtl:
                    strDirectionType = "rtl";
                    break;
                case DirectionTypes.inherit:
                    strDirectionType = "inherit";
                    break;
            }
            await JsInterops.SetCanvas2DContextProperty("direction", strDirectionType);
        }

        #endregion

        #region Fill and stroke styles
        // TODO - Need to support Gradient and Pattern besides simple color strings

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillStyle</summary>
        public async Task<string?> GetFillStyle() =>
            await JsInterops.GetCanvas2DContextProperty<string?>("fillStyle");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillStyle</summary>
        public async Task SetFillStyle(string? fillStyle) =>
            await JsInterops.SetCanvas2DContextProperty("fillStyle", fillStyle);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fillStyle</summary>
        public async Task SetFillStyleWithCanvasGradient(Gradient canvasGradient) =>
            await JsInterops.SetCanvas2DContextPropertyByExistingVarId("fillStyle", canvasGradient);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/strokeStyle</summary>
        public async Task<string?> GetStrokeStyle() =>
            await JsInterops.GetCanvas2DContextProperty<string?>("strokeStyle");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/strokeStyle</summary>
        public async Task SetStrokeStyle(string? strokeStyle) =>
            await JsInterops.SetCanvas2DContextProperty("strokeStyle", strokeStyle);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/strokeStyle</summary>
        public async Task SetStrokeStyleWithCanvasGradient(Gradient canvasGradient) =>
            await JsInterops.SetCanvas2DContextPropertyByExistingVarId("strokeStyle", canvasGradient);

        #endregion

        #region Shadows

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowBlur</summary>
        public async Task<int?> GetShadowBlur() =>
            await JsInterops.GetCanvas2DContextProperty<int?>("shadowBlur");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowBlur</summary>
        public async Task SetShadowBlur(int? shadowBlur) =>
            await JsInterops.SetCanvas2DContextProperty("shadowBlur", shadowBlur);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowColor</summary>
        public async Task<string?> GetShadowColor() =>
            await JsInterops.GetCanvas2DContextProperty<string?>("shadowColor");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowColor</summary>
        public async Task SetShadowColor(string? shadowColor) =>
            await JsInterops.SetCanvas2DContextProperty("shadowColor", shadowColor);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowOffsetX</summary>
        public async Task<float?> GetShadowOffsetX() =>
            await JsInterops.GetCanvas2DContextProperty<float?>("shadowOffsetX");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowOffsetX</summary>
        public async Task SetShadowOffsetX(float? shadowOffsetX) =>
            await JsInterops.SetCanvas2DContextProperty("shadowOffsetX", shadowOffsetX);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowOffsetY</summary>
        public async Task<float?> GetShadowOffsetY() =>
            await JsInterops.GetCanvas2DContextProperty<float?>("shadowOffsetY");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/shadowOffsetY</summary>
        public async Task SetShadowOffsetY(float? shadowOffsetY) =>
            await JsInterops.SetCanvas2DContextProperty("shadowOffsetY", shadowOffsetY);

        #endregion

        #region Paths

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/beginPath</summary>
        public async Task BeginPath() =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("beginPath", Array.Empty<object>());

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/closePath</summary>
        public async Task ClosePath() =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("closePath", Array.Empty<object>());

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/moveTo</summary>
        public async Task MoveTo(int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("moveTo", new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineTo</summary>
        public async Task LineTo(int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("lineTo", new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/bezierCurveTo</summary>
        public async Task BezierCurveTo(int cp1x, int cp1y, int cp2x, int cp2y, int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("bezierCurveTo", 
                new object[] { cp1x, cp1y, cp2x, cp2y, x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/quadraticCurveTo</summary>
        public async Task QuadraticCurveTo(int cpx, int cpy, int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("quadraticCurveTo", new object[] { cpx, cpy, x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/arc</summary>
        public async Task Arc(int x, int y, int radius, int startAngle, int endAngle, bool counterclockwise = false) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("arc", 
                new object[] { x, y, radius, startAngle, endAngle, counterclockwise });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/arcTo</summary>
        public async Task ArcTo(int x1, int y1, int x2, int y2, int radius) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("arcTo", new object[] { x1, y1, x2, y2, radius });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/ellipse</summary>
        public async Task Ellipse(int x, int y, int radiusX, int radiusY, int rotation, int startAngle, 
            int endAngle, bool counterclockwise = false) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("ellipse", 
                new object[] { x, y, radiusX, radiusY, rotation, startAngle, endAngle, counterclockwise });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/rect</summary>
        public async Task Rect(int x, int y, int width, int height) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("rect", new object[] { x, y, width, height });

        #endregion

        #region Drawing paths

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fill</summary>
        public async Task Fill() => await JsInterops.CallCanvas2DContextFunction("fill");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fill</summary>
        public async Task Fill(FillRuleTypes fillRuleType)
        {
            string strFillRuleType = "nonzero";
            if (fillRuleType == FillRuleTypes.evenodd) strFillRuleType = "evenodd";
            await JsInterops.CallCanvas2DContextFunctionWithParameters("fill", new object[] { strFillRuleType });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fill</summary>
        public async Task Fill(Path2D path2D) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarParameter("fill", path2D);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/fill</summary>
        public async Task Fill(Path2D path2D, FillRuleTypes fillRuleType)
        {
            string strFillRuleType = "nonzero";
            if (fillRuleType == FillRuleTypes.evenodd) strFillRuleType = "evenodd";
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters("fill", path2D, new object[] { strFillRuleType });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/stroke</summary>
        public async Task Stroke() => await JsInterops.CallCanvas2DContextFunction("stroke");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/stroke</summary>
        public async Task Stroke(Path2D path2D) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarParameter("stroke", path2D);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/drawFocusIfNeeded</summary>
        public async Task DrawFocusIfNeeded(ElementReference elementReference) =>
            await JsInterops.CallCanvas2DContextFunctionWithElementReferenceParameter("drawFocusIfNeeded", elementReference);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/drawFocusIfNeeded</summary>
        public async Task DrawFocusIfNeeded(ElementReference elementReference, Path2D path2D) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters(
                "drawFocusIfNeeded", path2D, new object[] { elementReference });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/scrollPathIntoView</summary>
        public async Task ScrollPathIntoView() =>
            await JsInterops.CallCanvas2DContextFunction("scrollPathIntoView");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/scrollPathIntoView</summary>
        public async Task ScrollPathIntoView(Path2D path2D) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarParameter("scrollPathIntoView", path2D);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/clip</summary>
        public async Task Clip() => await JsInterops.CallCanvas2DContextFunction("clip");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/clip</summary>
        public async Task Clip(FillRuleTypes fillRuleType)
        {
            string strFillRuleType = "nonzero";
            if (fillRuleType == FillRuleTypes.evenodd) strFillRuleType = "evenodd";
            await JsInterops.CallCanvas2DContextFunctionWithParameters("clip", new object[] { strFillRuleType });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/clip</summary>
        public async Task Clip(Path2D path2D) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarParameter("clip", path2D);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/clip</summary>
        public async Task Clip(Path2D path2D, FillRuleTypes fillRuleType)
        {
            string strFillRuleType = "nonzero";
            if (fillRuleType == FillRuleTypes.evenodd) strFillRuleType = "evenodd";
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters("clip", path2D,
                new object[] { strFillRuleType });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/isPointInPath</summary>
        public async Task IsPointInPath(int x, int y) => 
            await JsInterops.CallCanvas2DContextFunctionWithParameters("isPointInPath", new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/isPointInPath</summary>
        public async Task IsPointInPath(int x, int y, FillRuleTypes fillRuleType)
        {
            string strFillRuleType = "nonzero";
            if (fillRuleType == FillRuleTypes.evenodd) strFillRuleType = "evenodd";
            await JsInterops.CallCanvas2DContextFunctionWithParameters("isPointInPath", new object[] { x, y, strFillRuleType });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/isPointInPath</summary>
        public async Task IsPointInPath(Path2D path2D, int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters("isPointInPath", 
                path2D, new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/isPointInPath</summary>
        public async Task IsPointInPath(Path2D path2D, int x, int y, FillRuleTypes fillRuleType)
        {
            string strFillRuleType = "nonzero";
            if (fillRuleType == FillRuleTypes.evenodd) strFillRuleType = "evenodd";
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters("isPointInPath", 
                path2D, new object[] { x, y, strFillRuleType });
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/isPointInStroke</summary>
        public async Task IsPointInStroke(int x, int y) => await JsInterops.CallCanvas2DContextFunctionWithParameters(
            "isPointInStroke", new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/isPointInStroke</summary>
        public async Task IsPointInStroke(Path2D path2D, int x, int y) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters("isPointInStroke",
                path2D, new object[] { x, y });

        #endregion

        #region Transformations

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/currentTransform</summary>
        public void GetCurrentTransform() => throw new NotSupportedException();

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/currentTransform</summary>
        public void SetCurrentTransform() => throw new NotSupportedException();

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getTransform</summary>
        public async Task<DOMMatrix> GetTransform()
        {
            DOMMatrix domMatrix = new(this);
            await JsInterops.CallCanvas2DContextFunctionWithVarToHold(domMatrix, "getTransform");
            return domMatrix;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/rotate</summary>
        public async Task Rotate(double angle) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("rotate", new object[] { angle });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/scale</summary>
        public async Task Scale(double x, double y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("scale", new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/translate</summary>
        public async Task Translate(double x, double y) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("translate", new object[] { x, y });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/transform</summary>
        public async Task Transform(double a, double b, double c, double d, double e, double f) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("transform", new object[] { a, b, c, d, e, f });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/setTransform</summary>
        public async Task SetTransform() => await JsInterops.CallCanvas2DContextFunction("setTransform");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/setTransform</summary>
        public async Task SetTransform(double a, double b, double c, double d, double e, double f) =>
            await JsInterops.CallCanvas2DContextFunctionWithParameters("setTransform", new object[] { a, b, c, d, e, f });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/setTransform</summary>
        public async Task SetTransform(DOMMatrix domMatrix) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarParameter("setTransform", domMatrix);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/resetTransform</summary>
        public void ResetTransform() => throw new NotSupportedException();

        #endregion

        #region Compositing

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalAlpha</summary>
        public async Task<double?> GetGlobalAlpha() => await JsInterops.GetCanvas2DContextProperty<double?>("globalAlpha");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalAlpha</summary>
        public async Task SetGlobalAlpha(double? globalAlpha) => await JsInterops.SetCanvas2DContextProperty("globalAlpha", globalAlpha);

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation</summary>
        public async Task<GlobalCompositeOperationTypes?> GetGlobalCompositeOperatio()
        {
            GlobalCompositeOperationTypes? globalCompositeOperationType = null;
            switch (await JsInterops.GetCanvas2DContextProperty<string?>("globalCompositeOperation"))
            {
                case "source-over":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.SourceOver;
                    break;
                case "source-in":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.SourceIn;
                    break;
                case "source-out":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.SourceOut;
                    break;
                case "source-atop":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.SourceAtop;
                    break;
                case "destination-over":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.DestinationOver;
                    break;
                case "destination-in":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.DestinationIn;
                    break;
                case "destination-out":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.DestinationOut;
                    break;
                case "destination-atop":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.DestinationAtop;
                    break;
                case "lighter":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Lighter;
                    break;
                case "copy":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Copy;
                    break;
                case "xor":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Xor;
                    break;
                case "multiply":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Multiply;
                    break;
                case "screen":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Screen;
                    break;
                case "overlay":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Overlay;
                    break;
                case "darken":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Darken;
                    break;
                case "lighten":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Lighten;
                    break;
                case "color-dodge":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.ColorDodge;
                    break;
                case "color-burn":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.ColorBurn;
                    break;
                case "hard-light":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.HardLight;
                    break;
                case "soft-light":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.SoftLight;
                    break;
                case "difference":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Difference;
                    break;
                case "exclusion":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Exclusion;
                    break;
                case "hue":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Hue;
                    break;
                case "saturation":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Saturation;
                    break;
                case "color":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Color;
                    break;
                case "luminosity":
                    globalCompositeOperationType = GlobalCompositeOperationTypes.Luminosity;
                    break;
            }
            return globalCompositeOperationType;
        }

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation</summary>
        public async Task SetGlobalCompositeOperation(GlobalCompositeOperationTypes? globalCompositeOperationType)
        {
            string strGlobalCompositeOperation = string.Empty;
            switch (globalCompositeOperationType)
            {
                case GlobalCompositeOperationTypes.SourceOver:
                    strGlobalCompositeOperation = "source-over";
                    break;
                case GlobalCompositeOperationTypes.SourceIn:
                    strGlobalCompositeOperation = "source-in";
                    break;
                case GlobalCompositeOperationTypes.SourceOut:
                    strGlobalCompositeOperation = "source-out";
                    break;
                case GlobalCompositeOperationTypes.SourceAtop:
                    strGlobalCompositeOperation = "source-atop";
                    break;
                case GlobalCompositeOperationTypes.DestinationOver:
                    strGlobalCompositeOperation = "destination-over";
                    break;
                case GlobalCompositeOperationTypes.DestinationIn:
                    strGlobalCompositeOperation = "destination-in";
                    break;
                case GlobalCompositeOperationTypes.DestinationOut:
                    strGlobalCompositeOperation = "destination-out";
                    break;
                case GlobalCompositeOperationTypes.DestinationAtop:
                    strGlobalCompositeOperation = "destination-atop";
                    break;
                case GlobalCompositeOperationTypes.Lighter:
                    strGlobalCompositeOperation = "lighter";
                    break;
                case GlobalCompositeOperationTypes.Copy:
                    strGlobalCompositeOperation = "copy";
                    break;
                case GlobalCompositeOperationTypes.Xor:
                    strGlobalCompositeOperation = "xor";
                    break;
                case GlobalCompositeOperationTypes.Multiply:
                    strGlobalCompositeOperation = "multiply";
                    break;
                case GlobalCompositeOperationTypes.Screen:
                    strGlobalCompositeOperation = "screen";
                    break;
                case GlobalCompositeOperationTypes.Overlay:
                    strGlobalCompositeOperation = "overlay";
                    break;
                case GlobalCompositeOperationTypes.Darken:
                    strGlobalCompositeOperation = "darken";
                    break;
                case GlobalCompositeOperationTypes.Lighten:
                    strGlobalCompositeOperation = "lighten";
                    break;
                case GlobalCompositeOperationTypes.ColorDodge:
                    strGlobalCompositeOperation = "color-dodge";
                    break;
                case GlobalCompositeOperationTypes.ColorBurn:
                    strGlobalCompositeOperation = "color-burn";
                    break;
                case GlobalCompositeOperationTypes.HardLight:
                    strGlobalCompositeOperation = "hard-light";
                    break;
                case GlobalCompositeOperationTypes.SoftLight:
                    strGlobalCompositeOperation = "soft-light";
                    break;
                case GlobalCompositeOperationTypes.Difference:
                    strGlobalCompositeOperation = "difference";
                    break;
                case GlobalCompositeOperationTypes.Exclusion:
                    strGlobalCompositeOperation = "exclusion";
                    break;
                case GlobalCompositeOperationTypes.Hue:
                    strGlobalCompositeOperation = "hue";
                    break;
                case GlobalCompositeOperationTypes.Saturation:
                    strGlobalCompositeOperation = "saturation";
                    break;
                case GlobalCompositeOperationTypes.Color:
                    strGlobalCompositeOperation = "color";
                    break;
                case GlobalCompositeOperationTypes.Luminosity:
                    strGlobalCompositeOperation = "luminosity";
                    break;
            }
            await JsInterops.SetCanvas2DContextProperty("globalCompositeOperation", strGlobalCompositeOperation);
        }

        #endregion

        #region Drawing images

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/drawImage</summary>
        public async Task DrawImage(ElementReference elementReference, int dx, int dy) =>
            await JsInterops.CallCanvas2DContextFunctionWithElementReferenceAndMoreParameters("drawImage", 
                elementReference, new object[] { dx, dy });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/drawImage</summary>
        public async Task DrawImage(ElementReference elementReference, int dx, int dy, int dWidth, int dHeight) =>
            await JsInterops.CallCanvas2DContextFunctionWithElementReferenceAndMoreParameters("drawImage",
                elementReference, new object[] { dx, dy, dWidth, dHeight });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/drawImage</summary>
        public async Task DrawImage(ElementReference elementReference, int sx, int sy, int sWidth, int sHeight, 
            int dx, int dy, int dWidth, int dHeight) =>
            await JsInterops.CallCanvas2DContextFunctionWithElementReferenceAndMoreParameters("drawImage",
                elementReference, new object[] { sx, sy, sWidth, sHeight, dx, dy, dWidth, dHeight });

        #endregion

        #region Pixel manipulation

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/putImageData</summary>
        public async Task PutImageData(ImageData imageData, int dx, int dy) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters(
                "putImageData", imageData, new object[] { dx, dy });

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/putImageData</summary>
        public async Task PutImageData(ImageData imageData, int dx, int dy, int dirtyX, int dirtyY, int dirtyWidth, int dirtyHeight) =>
            await JsInterops.CallCanvas2DContextFunctionWithExistingVarAndMoreParameters(
                "putImageData", imageData, new object[] { dx, dy, dirtyX, dirtyY, dirtyWidth, dirtyHeight });

        #endregion

        #region Image smoothing

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/imageSmoothingEnabled</summary>
        public void GetImageSmoothingEnabled() => throw new NotSupportedException();

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/imageSmoothingEnabled</summary>
        public void SetImageSmoothingEnabled() => throw new NotSupportedException();

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/imageSmoothingQuality</summary>
        public void GetImageSmoothingQuality() => throw new NotSupportedException();

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/imageSmoothingQuality</summary>
        public void SetImageSmoothingQuality() => throw new NotSupportedException();

        #endregion

        #region The canvas state

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/save</summary>
        public async Task Save() => await JsInterops.CallCanvas2DContextFunction("save");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/restore</summary>
        public async Task Restore() => await JsInterops.CallCanvas2DContextFunction("restore");

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/canvas</summary>
        public CanvasClass Canvas() => this;

        ///<summary>https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/getContextAttributes</summary>
        public async Task<ContextAttributes?> GetContextAttributes() =>
            await JsInterops.CallCanvas2DContextFunctionWithReturn<ContextAttributes?>("getContextAttributes");

        #endregion
    }
}
