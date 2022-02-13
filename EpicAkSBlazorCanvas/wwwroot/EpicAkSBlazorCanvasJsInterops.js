window.epicAkSHelperFunctions = {
    ctxByCanvasId: [],
    currentCtx: null,
    varsToHold: [],
    getElementProps: function (elem, props) {
        let obj = {};
        for (let i = 0; i < props.length; i++) {
            obj[props[i]] = elem[props[i]];
        }
        return JSON.stringify(obj);
    },
    createCanvasForDivElementReferenceWithId: function (elDiv, canvasId) {
        if (!elDiv || !elDiv.tagName || elDiv.tagName != 'DIV') {
            return;
        }

        let canvas = document.createElement('CANVAS');
        let width = document.documentElement.clientWidth;
        let height = document.documentElement.clientHeight;
        elDiv.setAttribute('width', width);
        elDiv.setAttribute('height', height);
        canvas.setAttribute('id', canvasId);
        canvas.setAttribute('width', width);
        canvas.setAttribute('height', height);
        elDiv.appendChild(canvas);
        let obj = {};
        obj[canvasId] = canvas.getContext('2d');
        this.ctxByCanvasId.push(obj);
        return '{ "canvasWidth" : ' + width + ', "canvasHeight" : ' + height + ' }';
    },
    createCanvasForDivElementReferenceWithIdWithContextAttributes: function (elDiv, canvasId, contextAttributes) {
        if (!elDiv || !elDiv.tagName || elDiv.tagName != 'DIV') {
            return;
        }

        let canvas = document.createElement('CANVAS');
        let width = document.documentElement.clientWidth;
        let height = document.documentElement.clientHeight;
        elDiv.setAttribute('width', width);
        elDiv.setAttribute('height', height);
        canvas.setAttribute('id', canvasId);
        canvas.setAttribute('width', width);
        canvas.setAttribute('height', height);
        elDiv.appendChild(canvas);
        let obj = {};
        obj[canvasId] = canvas.getContext('2d', contextAttributes);
        this.ctxByCanvasId.push(obj);
        return '{ "canvasWidth" : ' + width + ', "canvasHeight" : ' + height + ' }';
    },
    setCurrentCanvas2DContext: function (canvasId) {
        let ctx;
        for (let i = 0; i < this.ctxByCanvasId.length; i++) {
            ctx = this.ctxByCanvasId[i][canvasId];
            if (ctx) break;
        }
        if (!ctx) return;
        this.currentCtx = ctx;
    },
    setCanvas2DContextProperty: function (propertyName, value) {
        if (!this.currentCtx || !this.currentCtx[propertyName]) return;
        this.currentCtx[propertyName] = value;
    },
    setCanvas2DContextPropertyByExistingVarId: function (propertyName, varId) {
        let varById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            varById = this.varsToHold[i][varId];
            if (varById) break;
        }
        if (!varById) return;
        if (!this.currentCtx || !this.currentCtx[propertyName]) return;
        this.currentCtx[propertyName] = varById;
    },
    getCanvas2DContextProperty: function (propertyName) {
        if (!this.currentCtx || !this.currentCtx[propertyName]) return null;
        return this.currentCtx[propertyName];
    },
    getCanvas2DContextPropertyWithReturnObjectForProps: function (propertyName, props) {
        if (!this.currentCtx || !this.currentCtx[propertyName]) return null;
        let obj = this.currentCtx[propertyName];
        let retObj = {};
        for (let i = 0; i < props.length; i++) {
            retObj[props[i]] = obj[props[i]];
        }
        return JSON.stringify(retObj);
    },
    getCanvas2DContextPropertyByExistingVarId: function (propertyName, varId) {
        let varById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            varById = this.varsToHold[i][varId];
            if (varById) break;
        }
        if (!varById) return;
        return varById[propertyName];
    },
    callCanvas2DContextFunction: function (functionName) {
        if (!this.currentCtx || !this.currentCtx[functionName]) return;
        this.currentCtx[functionName].apply(this.currentCtx);
    },
    callCanvas2DContextFunctionWithParameters: function (functionName, functionParams) {
        if (!this.currentCtx || !this.currentCtx[functionName]) return;
        this.currentCtx[functionName].apply(this.currentCtx, functionParams);
    },
    callCanvas2DContextFunctionWithReturn: function (functionName) {
        if (!this.currentCtx || !this.currentCtx[functionName]) return;
        return this.currentCtx[functionName].apply(this.currentCtx);
    },
    callCanvas2DContextFunctionWithParametersWithReturn: function (functionName, functionParams) {
        if (!this.currentCtx || !this.currentCtx[functionName]) return;
        return this.currentCtx[functionName].apply(this.currentCtx, functionParams);
    },
    callCanvas2DContextFunctionWithExistingVarParameter: function (functionName, functionParamVarId) {
        if (!this.currentCtx || !this.currentCtx[functionName]) return;
        let functionParamVarById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            functionParamVarById = this.varsToHold[i][functionParamVarId];
            if (functionParamVarById)
                break;
        }
        if (!functionParamVarById) return;
        this.currentCtx[functionName].apply(this.currentCtx, [functionParamVarById]);
    },
    callCanvas2DContextFunctionWithExistingVarAndMoreParameters: function (functionName, functionParamVarId, moreFunctionParameters) {
        if (!this.currentCtx || !this.currentCtx[functionName]) return;
        let functionParamVarById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            functionParamVarById = this.varsToHold[i][functionParamVarId];
            if (functionParamVarById)
                break;
        }
        if (!functionParamVarById) return;
        this.currentCtx[functionName].apply(this.currentCtx, [functionParamVarById].concat(moreFunctionParameters));
    },
    callCanvas2DContextFunctionWithVarToHold: function (varId, functionName) {
        if (!this.currentCtx || !this.currentCtx[functionName] || !varId) return;
        let obj = {};
        obj[varId] = this.currentCtx[functionName].apply(this.currentCtx);
        this.varsToHold.push(obj);
    },
    callCanvas2DContextFunctionWithParametersWithVarToHold: function (varId, functionName, functionParams) {
        if (!this.currentCtx || !this.currentCtx[functionName] || !varId) return;
        let obj = {};
        obj[varId] = this.currentCtx[functionName].apply(this.currentCtx, functionParams);
        this.varsToHold.push(obj);
    },
    callCanvas2DContextFunctionWithVarToHoldWithReturn: function (varId, functionName, props) {
        if (!this.currentCtx || !this.currentCtx[functionName] || !varId) return;
        let obj = {};
        obj[varId] = this.currentCtx[functionName].apply(this.currentCtx);
        this.varsToHold.push(obj);
        let retObj = {};
        retObj['varId'] = retObj['varIdString'] = varId;
        for (let i = 0; i < props.length; i++) {
            retObj[props[i]] = varById[props[i]];
        }
        return JSON.stringify(retObj);
    },
    callCanvas2DContextFunctionWithParametersWithVarToHoldWithReturn: function (varId, functionName, functionParams, props) {
        if (!this.currentCtx || !this.currentCtx[functionName] || !varId) return;
        let obj = {};
        obj[varId] = this.currentCtx[functionName].apply(this.currentCtx, functionParams);
        this.varsToHold.push(obj);
        let retObj = {};
        retObj['varId'] = retObj['varIdString'] = varId;
        for (let i = 0; i < props.length; i++) {
            retObj[props[i]] = varById[props[i]];
        }
        return JSON.stringify(retObj);
    },
    getVarIdPropsFromVarsToHold: function (varId, props) {
        let varById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            varById = this.varsToHold[i][varId];
            if (varById) break;
        }
        if (!varById) return;
        let obj = {};
        for (let i = 0; i < props.length; i++) {
            obj[props[i]] = varById[props[i]];
        }
        return JSON.stringify(obj);
    },
    callFunctionOnExistingVarToHold: function (varId, functionName) {
        let varById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            varById = this.varsToHold[i][varId];
            if (varById) break;
        }
        if (!varById) return;
        varById[functionName].apply(varById);
    },
    callFunctionWithParametersOnExistingVarToHold: function (varId, functionName, functionParams) {
        let varById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            varById = this.varsToHold[i][varId];
            if (varById) break;
        }
        if (!varById) return;
        varById[functionName].apply(varById, functionParams);
    },
    callFunctionWithExistingVarParameterOnExistingVarToHold: function (varId, functionName, functionParamVarId) {
        let varById, functionParamVarById;
        for (let i = 0; i < this.varsToHold.length; i++) {
            if (!varById)
                varById = this.varsToHold[i][varId];
            if (!functionParamVarById)
                functionParamVarById = this.varsToHold[i][functionParamVarId];
        }
        if (!varById && !functionParamVarById) return;
        varById[functionName].apply(varById, [functionParamVarById]);
    },
    callFunctionWithNewVarToHold: function (varId, functionName) {
        let obj = {};
        obj[varId] = new window[functionName]();
        this.varsToHold.push(obj);
    },
    callFunctionWithStringParameterWithNewVarToHold: function (varId, functionName, stringParameter) {
        let obj = {};
        obj[varId] = new window[functionName](stringParameter);
        this.varsToHold.push(obj);
    },
    callFunctionWithArrayParameterWithNewVarToHold: function (varId, functionName, arrayParameter) {
        let obj = {};
        obj[varId] = new window[functionName](arrayParameter);
        this.varsToHold.push(obj);
    }
};
