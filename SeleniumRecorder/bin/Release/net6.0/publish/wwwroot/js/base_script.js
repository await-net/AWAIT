window.stop = false;
window.addEventListener('click', function (event) {
    if (!event.target || !(event.target instanceof Element)) {
        return;
    }
    if (event.target.hasAttribute('href')) {
        window.load = true;
    }    
    window.stop = true;
    event.preventDefault();

    if (event.target.tagName.toLowerCase() === 'a') {
        // Stop further propagation of the click event
        //event.stopPropagation();
        var hrefClassName = event.target.className;
        var hrefId = event.target.id;

        window.hrefTargetClass = hrefClassName;
        window.hrefTargetId = hrefId;
    }
    if (event.target.tagName.toLowerCase() === 'button') {
        // Stop further propagation of the click event
        //event.stopPropagation();
        var btnClassName = event.target.className;
        var btnId = event.target.id;

        window.btnTargetClass = btnClassName;
        window.btnTargetId = btnId;
    }
    var targetEventType = event.type;
    var targetId = event.target.id;
    var targetXPath = 'disabled';
    var targetTagName = event.target.tagName.toLowerCase();
    var targetClass = Array.from(event.target.classList).join('.');

    var targetCSSSelector = getPath(event.target) || 'non';

    window.targetEventType = targetEventType;
    window.targetId = targetId;
    window.targetXPath = targetXPath;
    window.targetTagName = targetTagName;
    window.targetClass = targetClass;
    window.targetCSSSelector = targetCSSSelector;  

    console.log(targetId + ' => ' + targetXPath);
    console.log('TagName: ' + targetTagName);
    console.log('Class: ' + targetClass);
    console.log('CSS Selector: ' + targetCSSSelector);
    console.log('Class Alt: ' + hrefClassName);
});

function xpath(el) {
    if (typeof el == 'string') {
        return document.evaluate(el, document, null, XPathResult.FIRST_ORDERED_NODE_TYPE, null).singleNodeValue;
    }
    if (!el || el.nodeType != 1) {
        return '';
    }
    if (el.id) {
        return '//*[@id="' + el.id + '"]';
    }
    var sames = [].filter.call(el.parentNode.children, function (x) {
        return x.tagName == el.tagName;
    });
    return xpath(el.parentNode) + '/' + el.tagName.toLowerCase() + (sames.length > 1 ? '[' + ([].indexOf.call(sames, el) + 1) + ']' : '');
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
