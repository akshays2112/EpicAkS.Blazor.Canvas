using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Text.Json;
using EpicAkS.Blazor.Canvas.Structs;
using System.Security.Cryptography.X509Certificates;

namespace EpicAkS.Blazor.Canvas
{
    internal partial class JsInterops
    {
        private IJSRuntime JSRuntime { get; init; }

        internal JsInterops(IJSRuntime jsRuntime)
        {
            JSRuntime = jsRuntime;
        }

        internal async Task<string> GetMouseXY(int clientX, int clientY)
        {
            if (JSRuntime is null) return String.Empty;
            return await JSRuntime.InvokeAsync<string>("window.epicAkSHelperFunctions.getMouseXY",
                new object[] { clientX, clientY });
        }

        internal async Task<string> GetJSPropertyValuesByElementReference(ElementReference el, string[] props)
        {
            if (JSRuntime is null) return String.Empty;
            return await JSRuntime.InvokeAsync<string>("window.epicAkSHelperFunctions.getElementProps",
                new object[] { el, props });
        }

        internal async Task<string> CreateCanvasForDivElementReferenceWithId(ElementReference elDiv, string canvasId)
        {
            if (JSRuntime is null) return String.Empty;
            return await JSRuntime.InvokeAsync<string>("window.epicAkSHelperFunctions.createCanvasForDivElementReferenceWithId",
                new object[] { elDiv, canvasId });
        }

        internal async Task<string> CreateCanvasForDivElementReferenceWithIdWithContextAttributes(
            ElementReference elDiv, string canvasId, ContextAttributes contextAttributes)
        {
            if (JSRuntime is null) return String.Empty;
            return await JSRuntime.InvokeAsync<string>("window.epicAkSHelperFunctions.createCanvasForDivElementReferenceWithIdWithContextAttributes",
                new object[] { elDiv, canvasId, contextAttributes });
        }

        internal async Task SetCurrentCanvas2DContext(string canvasId)
        {
            if (JSRuntime is null) return;
            await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.setCurrentCanvas2DContext",
                new object[] { canvasId });
        }

        internal async Task SetCanvas2DContextProperty<T>(string propertyName, T? value)
        {
            if (JSRuntime is null) return;
            await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.setCanvas2DContextProperty",
                new object?[] { propertyName, value });
        }

        internal async Task SetCanvas2DContextPropertyByExistingVarId<T>(string propertyName, T? value) where T : ReturnVar
        {
            if (JSRuntime is null) return;
            await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.setCanvas2DContextPropertyByExistingVarId",
                new object?[] { propertyName, (value is not null ? ((ReturnVar)value).VarIdString : null) });
        }

        internal async Task<T?> GetCanvas2DContextProperty<T>(string propertyName)
        {
            if (JSRuntime is null) return default;
            return await JSRuntime.InvokeAsync<T?>("window.epicAkSHelperFunctions.getCanvas2DContextProperty",
                new object[] { propertyName });
        }

        internal async Task<T?> GetCanvas2DContextPropertyWithReturnObjectForProps<T>(string propertyName)
        {
            if (JSRuntime is null) return default;
            string? json = await JSRuntime.InvokeAsync<string?>("window.epicAkSHelperFunctions.getCanvas2DContextPropertyWithReturnObjectForProps",
                new object[] { propertyName, Helpers.FillPropertyNames(typeof(T)) });
            return json is not null ? JsonSerializer.Deserialize<T>(json) : default;
        }

        internal async Task CallCanvas2DContextFunction(string functionName)
        {
            if (JSRuntime is null) return;
            await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunction",
                new object[] { functionName });
        }

        internal async Task CallCanvas2DContextFunctionWithParameters(string functionName, object[] functionParameters)
        {
            if (JSRuntime is null) return;
            await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithParameters",
                new object[] { functionName, functionParameters });
        }

        internal async Task<T?> CallCanvas2DContextFunctionWithReturn<T>(string functionName)
        {
            if (JSRuntime is null) return default;
            return await JSRuntime.InvokeAsync<T?>("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithReturn",
                new object[] { functionName });
        }

        internal async Task<T?> CallCanvas2DContextFunctionWithParametersWithReturn<T>(string functionName,
           object[] functionParameters)
        {
            if (JSRuntime is null) return default;
            return await JSRuntime.InvokeAsync<T?>("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithParametersWithReturn",
                new object[] { functionName, functionParameters });
        }

        internal async Task CallCanvas2DContextFunctionWithExistingVarParameter<T>(string functionName, T tObj) where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (tObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)tObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithExistingVarParameter",
                    new object[] { functionName, ((ReturnVar)tObj).VarIdString });
            }
        }

        internal async Task CallCanvas2DContextFunctionWithExistingVarAndMoreParameters<T>(
           string functionName, T tObj, object[] moreFunctionParameters) where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (tObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)tObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithExistingVarAndMoreParameters",
                    new object[] { functionName, ((ReturnVar)tObj).VarIdString, moreFunctionParameters });
            }
        }

        internal async Task CallCanvas2DContextFunctionWithElementReferenceParameter(string functionName, ElementReference elementReference)
        {
            if (JSRuntime is null) return;
            if (!string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithParameters",
                    new object[] { functionName, elementReference });
            }
        }

        internal async Task CallCanvas2DContextFunctionWithElementReferenceAndMoreParameters(string functionName, 
            ElementReference elementReference, object[] moreFunctionParameters)
        {
            if (JSRuntime is null) return;
            if (!string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithParameters",
                    (new object[] { functionName, elementReference }).Append(moreFunctionParameters));
            }
        }

        internal async Task CallFunctionWithNewVarToHold<T>(T newTObj, string functionName)
           where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (newTObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)newTObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callFunctionWithNewVarToHold",
                    new object[] { ((ReturnVar)newTObj).VarIdString, functionName });
            }
        }

        internal async Task CallFunctionWithStringParameterWithNewVarToHold<T>(T newTObj,
           string functionName, string stringParameter)
           where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (newTObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)newTObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callFunctionWithStringParameterWithNewVarToHold",
                    new object[] { ((ReturnVar)newTObj).VarIdString, functionName, stringParameter });
            }
        }

        internal async Task CallFunctionWithDoubleArrayParameterWithNewVarToHold<T>(T newTObj,
           string functionName, double[] doubleArrayParameter)
           where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (newTObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)newTObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callFunctionWithArrayParameterWithNewVarToHold",
                    new object[] { ((ReturnVar)newTObj).VarIdString, functionName, doubleArrayParameter });
            }
        }

        internal async Task CallCanvas2DContextFunctionWithVarToHold<T>(T newTObj, string functionName)
           where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (newTObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)newTObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithVarToHold",
                    new object[] { ((ReturnVar)newTObj).VarIdString, functionName });
            }
        }

        internal async Task CallCanvas2DContextFunctionWithParametersWithVarToHold<T>(T newTObj, string functionName,
           object[] functionParameters) where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (newTObj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)newTObj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName) && functionParameters?.Length > 0)
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithParametersWithVarToHold",
                    new object[] { ((ReturnVar)newTObj).VarIdString, functionName, functionParameters });
            }
        }

        internal async Task<T?> CallCanvas2DContextFunctionWithVarToHoldWithReturn<T>(T obj,
           string functionName) where T : ReturnVar
        {
            if (JSRuntime is null) return obj;
            if (obj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)obj).VarIdString) &&
                    ((ReturnVar)obj).PropertyNames?.Length > 0 && !string.IsNullOrWhiteSpace(functionName))
            {
                string json = await JSRuntime.InvokeAsync<string>(
                    "window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithVarToHoldWithReturn",
                    new object[] { ((ReturnVar)obj).VarIdString, functionName, ((ReturnVar)obj).PropertyNames });
                obj = JsonSerializer.Deserialize<T>(json) ?? obj;
            }
            return obj;
        }

        internal async Task<T?> CallCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn<T>(T obj,
           string functionName, object[] functionParameters) where T : ReturnVar
        {
            if (JSRuntime is null) return obj;
            if (obj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)obj).VarIdString) &&
                    ((ReturnVar)obj).PropertyNames?.Length > 0 && !string.IsNullOrWhiteSpace(functionName) &&
                    functionParameters?.Length > 0)
            {
                string json = await JSRuntime.InvokeAsync<string>(
                    "window.epicAkSHelperFunctions.callCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn",
                    new object[] { ((ReturnVar)obj).VarIdString, functionName, functionParameters,
                        ((ReturnVar)obj).PropertyNames });
                obj = JsonSerializer.Deserialize<T>(json) ?? obj;
            }
            return obj;
        }

        internal async Task<T?> GetVarIdPropsFromVarsToHold<T>(T obj) where T : ReturnVar
        {
            if (JSRuntime is null) return obj;
            if (obj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)obj).VarIdString) &&
                    ((ReturnVar)obj).PropertyNames?.Length > 0)
            {
                string json = await JSRuntime.InvokeAsync<string>("window.epicAkSHelperFunctions.getVarIdPropsFromVarsToHold",
                    new object[] { ((ReturnVar)obj).VarIdString, ((ReturnVar)obj).PropertyNames });
                T tObj = JsonSerializer.Deserialize<T>(json) ?? obj;
                if (tObj is not null)
                {
                    ((ReturnVar)tObj).VarId = ((ReturnVar)obj).VarId;
                    ((ReturnVar)tObj).VarIdString = ((ReturnVar)obj).VarIdString;
                    return tObj;
                }
            }
            return obj;
        }

        internal async Task CallFunctionOnExistingVarToHold<T>(T obj, string functionName) where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (obj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)obj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callFunctionOnExistingVarToHold",
                    new object[] { ((ReturnVar)obj).VarIdString, functionName });
            }
        }

        internal async Task CallFunctionWithParametersOnExistingVarToHold<T>(T obj,
           string functionName, object[] functionParameters) where T : ReturnVar
        {
            if (JSRuntime is null) return;
            if (obj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)obj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName) && functionParameters?.Length > 0)
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callFunctionWithParametersOnExistingVarToHold",
                    new object[] { ((ReturnVar)obj).VarIdString, functionName, functionParameters });
            }
        }

        internal async Task CallFunctionWithExistingVarParameterOnExistingVarToHold<T1, T2>(T1 t1Obj, string functionName, T2 t2Obj)
           where T1 : ReturnVar where T2 : ReturnVar
        {
            if (JSRuntime is null) return;
            if (t1Obj is not null && !string.IsNullOrWhiteSpace(((ReturnVar)t1Obj).VarIdString) &&
                !string.IsNullOrWhiteSpace(functionName) && t2Obj is not null &&
                !string.IsNullOrWhiteSpace(((ReturnVar)t2Obj).VarIdString))
            {
                await JSRuntime.InvokeVoidAsync("window.epicAkSHelperFunctions.callFunctionWithExistingVarParameterOnExistingVarToHold",
                    new object[] { ((ReturnVar)t1Obj).VarIdString, functionName, ((ReturnVar)t2Obj).VarIdString });
            }
        }
    }
}
