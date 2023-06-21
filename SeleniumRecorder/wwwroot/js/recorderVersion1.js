//-----------------------------------------------------------------------
//============ ALL JAVASCRIPT PRODUCED EXCLUSIVELY FOR AWAIT ============
//-----------------------------------------------------------------------
var isCapturingEvent = false;

function eventHandler(event) {
    if (isCapturingEvent) {
        return;
    }

    isCapturingEvent = true;

    var target = event.target;

    var eventResult = {
        eventType: event.type,
        target: {
            id: target ? target.id || 'non' : 'non',
            name: target ? target.name || 'non' : 'non',
            css: getCSSSelector(target) || 'non',
            xpath: getXPath(target) || 'non',
            targets: getTargets(target)
        },
        value: ""
    };

    // Allow the captured event to continue its normal execution
    setTimeout(function() {
        var dispatchedEvent = new Event(event.type, { bubbles: true, cancelable: true });
        target.dispatchEvent(dispatchedEvent);
        isCapturingEvent = false;
    }, 0);

    var xhr = new XMLHttpRequest();
    xhr.open('POST', 'https://localhost:7139/Dashboard/Recorder', true);
    xhr.setRequestHeader('Content-Type', 'application/json');

    xhr.onreadystatechange = function () {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            console.log("Success! Connect to Server!", xhr.status);
        }
    };
    xhr.send(JSON.stringify(eventResult));
}

document.addEventListener('click', eventHandler);

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

function getCSSSelector(element) {
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

function getTargets(element) {
    if (!(element instanceof Element)) {
        return [];
    }
    var targets = [];
    var xpath = getXPath(element);
    var css = getCSSSelector(element);
    
    targets.push([xpath, 'xpath']);
    targets.push([css, 'css']);
    targets.push([element.id ? '#' + element.id : 'non', 'id']);
    targets.push([element.name ? '[name="' + element.name + '"]' : 'non', 'name']);
    targets.push([element.tagName ? element.tagName.toLowerCase() : 'non', 'tag']);

    return targets;
}