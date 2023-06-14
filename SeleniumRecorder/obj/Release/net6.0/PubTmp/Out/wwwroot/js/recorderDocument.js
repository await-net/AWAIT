//----------------------------------------------------
//===ALL JAVASCRIPT PRODUCED BY: BRANDEN VAN STADEN===
//----------------------------------------------------
var tests = {};
window.stop = false;
window.load = false;
var count = 0;
// Click
document.addEventListener('click', function (event) {
    event.preventDefault();
    window.stop = true;
    count = count + 1;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};    
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';    
    dictCaptured['type'] = event.type || 'non';
    dictTargets['href'] = event.target.href || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    tests[String(count)] = dictCaptured;
});

// Double-click
document.addEventListener('dblclick', function (event) {
    window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    tests['dblclick'] = dictCaptured;
    //
    if (event.target.hasAttribute('href')) {
        window.load = true;
    }
});

// Right-click (context menu)
document.addEventListener('contextmenu', function (event) {
    window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    tests['contextmenu'] = dictCaptured;
    //
    if (event.target.hasAttribute('href')) {
        window.load = true;
    }
});

// Mouseover (hover)
document.addEventListener('mouseover', function (event) {
    //window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
   // tests['mouseover'] = dictCaptured;
});

// Mouseout
document.addEventListener('mouseout', function (event) {
    //window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    //tests['mouseout'] = dictCaptured;
});

// Mousemove
document.addEventListener('mousemove', function (event) {
    //window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    //tests['mousemove'] = dictCaptured;

});

// Keydown
document.addEventListener('keydown', function (event) {
    window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    tests['keydown'] = dictCaptured;
    //
    if (event.target.hasAttribute('href')) {
        window.load = true;
    }
});

// Keypress
document.addEventListener('keypress', function (event) {
    window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    tests['keypress'] = dictCaptured;
    //
    if (event.target.hasAttribute('href')) {
        window.load = true;
    }
});

// Keyup
document.addEventListener('keyup', function (event) {
    window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    tests['keyup'] = dictCaptured;
    //
    if (event.target.hasAttribute('href')) {
        window.load = true;
    }
});

// Scroll
document.addEventListener('scroll', function (event) {
    //window.stop = true;
    // Dictionary Captured => Command : Targets
    var dictCaptured = {};
    // Dictionary Targets => Attribute : Value
    var dictTargets = {};
    // Append Values to Dictionary => [dictTargets]
    dictTargets['id'] = event.target.id || 'non';
    dictTargets['targetXPath'] = 'disabled';
    dictTargets['tag'] = event.target.tagName.toLowerCase() || 'non';
    dictTargets['class'] = Array.from(event.target.classList).join('.') || 'non';;
    dictTargets['cssPath'] = getPath(event.target) || 'non';
    dictCaptured['type'] = event.type || 'non';
    // Append Dictionary => [dictCaptured] with Key: 'targets' and Value: Dictionary Object[dictTargets]
    dictCaptured['targets'] = dictTargets;
    // Finally Append dictCaptured to tests with the key: Event Type
    //tests['scroll'] = dictCaptured;    
});

// SOMEWHAT DEPRECATED... NOT IN USE THOUGH!
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
// COMPILES THE TARGETS CSS PATH
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
// RETURN [tests] AS A WINDOW OBJECT - LOGIC, I AM TREATING IT AS IF WERE A VIEWBAG OBJECT...
window.tests = tests;