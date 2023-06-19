$(document).ready(function () {
    var delay = 500;
    $('.card').each(function (index) {
        var card = $(this);
        setTimeout(function () {
            card.removeClass('hidden').addClass('visible');
        }, index * delay);
    });
});


const consoleOutput = document.querySelector('.console-output');
const consoleCursor = document.querySelector('.console-cursor');
const texts = ['Hello World!', 'AWAIT - Your Automated QA Solution!'];
let index = 0;

// Animate typing effect
function typeText(text) {
    const characters = text.split('');
    let delay = 0;

    characters.forEach((char, i) => {
        delay += 100; // Interval for typing

        setTimeout(() => {
            consoleOutput.textContent += char;
            updateCursorPosition();
        }, delay);
    });

    setTimeout(() => {
        backspaceText(text);
    }, delay + 1000);
}

// Animate backspacing effect
function backspaceText(text) {
    const characters = text.split('');
    let delay = 0;

    characters.forEach((char, i) => {
        delay += 50;

        setTimeout(() => {
            consoleOutput.textContent = consoleOutput.textContent.slice(0, -1);
            updateCursorPosition();
        }, delay);
    });

    setTimeout(() => {
        index = (index + 1) % texts.length;
        typeText(texts[index]);
    }, delay + 500);
}

// Update console cursor position
function updateCursorPosition() {
    const consoleText = consoleOutput.textContent;
    const consoleTextLength = consoleText.length;

    if (consoleTextLength === 0) {
        consoleCursor.style.marginLeft = '0';
    } else {
        const lastCharacter = consoleOutput.lastChild;
        if (lastCharacter instanceof Element) { // Check if lastCharacter is an element
            const rect = lastCharacter.getBoundingClientRect();
            const marginLeft = rect.right + 'px';
            consoleCursor.style.marginLeft = marginLeft;
        }
    }
}



// Start printing text once loaded
window.addEventListener('DOMContentLoaded', () => {
    typeText(texts[index]);
});