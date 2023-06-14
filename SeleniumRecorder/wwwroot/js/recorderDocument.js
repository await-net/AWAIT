//-----------------------------------------------------------------------
//============ ALL JAVASCRIPT PRODUCED EXCLUSIVELY FOR AWAIT ============
//-----------------------------------------------------------------------
var isCapturingEvent = false;

function eventHandler(event) {
    if (isCapturingEvent) {
        return;
    }

    isCapturingEvent = true;

    var eventResult = {
        eventType: 'click',
        elementId: event.target ? event.target.id || 'non' : 'non',
        elementXPath: getXPath(event.target) || 'non',
        elementTag: event.target && event.target.tagName ? event.target.tagName.toLowerCase() : 'non',
        elementClassName: event.target ? Array.from(event.target.classList).join('.') || 'non' : 'non',
        elementCSSPath: getPath(event.target) || 'non',
        elementWindowLocation: window.location.href
    };

    console.log('targetEventType:', eventResult.eventType);
    console.log('targetId:', eventResult.elementId);
    console.log('targetXPath:', eventResult.elementXPath);
    console.log('targetTag:', eventResult.elementTag);
    console.log('targetClassName:', eventResult.elementClassName);
    console.log('CSSPath:', eventResult.elementCSSPath);
    console.log('targetWindowLocation:', eventResult.elementWindowLocation);

    // Allow the captured event to continue its normal execution
    setTimeout(function() {
        var dispatchedEvent = new Event(event.type, { bubbles: true, cancelable: true });
        event.target.dispatchEvent(dispatchedEvent);
        isCapturingEvent = false;
    }, 0);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'https://localhost:7139/Dashboard/Recorder', true);
    xhr.setRequestHeader('Content-Type', 'application/json');

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            console.log("Successfully Connected to Server! :D");
            // Handle the response if needed
        } else {
            console.log("Unable to Connect to Server! :(");
        }
    };
    xhr.send(JSON.stringify(eventResult));
}

document.addEventListener('click', eventHandler);

//document.addEventListener('click', eventHandler, true);

function getXPath(element) {
    if (!element || element === document.body) return 'body';
    var xpath = '';
    while (element && element !== document.body) {
        if (element.nodeType === Node.ELEMENT_NODE) {
            xpath = '/' + element.tagName.toLowerCase() + xpath;
        }
        element = element.parentNode;
    }
    return xpath;
}

function getPath(element) {
    if (!(element instanceof Element)) {
        return;
    }
    var path = [];
    while (element) {
        var selector = element.nodeName.toLowerCase();
        if (element.id) {
            path.unshift('#' + element.id);
            break;
        } else if (element.className) {
            path.unshift(selector + '.' + element.className.replace(/ /g, '.'));
            break;
        } else {
            var index = Array.from(element.parentNode.children).indexOf(element) + 1;
            path.unshift(selector + ':nth-child(' + index + ')');
        }
        element = element.parentNode;
    }
    return path.join(' > ');
}
//------------------------------------------------------
//============ BUILT BY: Branden van Staden ============
//------------------------------------------------------