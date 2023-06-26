//-----------------------------------------------------------------------
//============ ALL JAVASCRIPT PRODUCED EXCLUSIVELY FOR AWAIT ============
//-----------------------------------------------------------------------
const tools = document.querySelectorAll('.btn.btn-outline-success');
const prompt = document.querySelector('#promptLoadTool');
const recorder = document.querySelector('#recorderTool');
var count = 0;
tools.forEach((tool) => {
    console.log(recorder.id);
    tool.addEventListener('click', (e) => {
        console.log(recorder.id);
        e.preventDefault();
        if (tool.classList.contains('active')) {
            tool.classList.remove('btn', 'btn-outline-warning', 'active');
            tool.classList.add('btn', 'btn-outline-success');

        } else {
            tool.classList.add('btn', 'btn-outline-warning', 'active');

        }
        // Change the button text based on the current condition
        console.log(recorder.id);
        const icon = tool.querySelector('.bi');
        if (icon != null) {
            if (icon.classList.contains('bi-box-arrow-in-down')) {
                icon.classList.remove('bi-box-arrow-in-down');
                icon.classList.add('bi-box-arrow-up');
                tool.innerHTML = '<i class="bi bi-box-arrow-right"></i> Unload Tool';
                prompt.classList.add('hidden');
                prompt.classList.remove('visible');
                console.log(recorder.id);
                if (tool.id == 'recorderTool') {
                    recorder.classList.remove('show');
                }
            } else {
                console.log(recorder.id);
                icon.classList.remove('bi-box-arrow-right');
                icon.classList.add('bi-box-arrow-in-down');
                tool.innerHTML = '<i class="bi bi-box-arrow-in-down"></i> Load Tool';
                if (tool.id == 'recorderTool') {
                    recorder.classList.add('show');

                }
            }
        }
    });
});
const tabLinks = document.querySelectorAll('.nav.nav-tabs .nav-link');
// HIDE/SHOW Tabs
tabLinks.forEach((tabLink) => {
    tabLink.addEventListener('click', (e) => {
        e.preventDefault();
        // Remove 'show' class from all tab content
        document.querySelectorAll('.tab-pane').forEach((tabContent) => {
            tabContent.classList.remove('show');
        });
        // Add 'show' class to the selected tab content
        const target = tabLink.getAttribute('data-bs-target');
        const selectedTabContent = document.querySelector(target);
        selectedTabContent.classList.add('show');
    });
});
// DOM LOAD: PLACEHOLDERS
window.addEventListener('load', () => {
    console.log = () => { };
    var placeholders = document.querySelectorAll('#placeholder');
    var toolBox = document.getElementById("toolBox");

    placeholders.forEach((placeholder) => {
        if (placeholder.classList.contains('hidden') != true) {
            placeholder.classList.add('hidden');
        }
    });
});
// DELETE RECORDER
function deleteRecorder(recorderId) {
    // Send an AJAX request to the RecorderDelete action
    $.ajax({
        url: "/Dashboard/RecorderDelete",
        type: "GET",
        data: { recorderId: recorderId },
        success: function () {
            // Remove the recorder from the view
            $("#recorder-" + recorderId).remove();

            // Show the toast notification
            var toastElement = document.getElementById("notification");
            var toast = new bootstrap.Toast(toastElement);
            toast.show();
        },
        error: function (xhr, status, error) {
            console.log("Error: " + error);
        }
    });
}
// RECORDER - START, STOP & SAVE
$(document).ready(function () {
    const toastBody = document.querySelector('.toast-body');
    // ENABLE START
    $("#selectRecorder select").change(function () {
        var selectedRecorder = $(this).val();
        if (selectedRecorder) {
            $("#startWebDriver").prop("disabled", false);
        } else {
            $("#startWebDriver").prop("disabled", true);
        }
    });
    // START
    $("#startWebDriver").click(function (e) {
        e.preventDefault();
        // Get the selected value from the dropdown
        var targetUrl = $("#selectRecorder select").val();
        $.ajax({
            url: "/Dashboard/Recorder",
            type: "GET",
            data: {url: targetUrl},
            success: function (response) {
                if (toastBody) {
                    toastBody.textContent = 'Recorder STARTED successfully!';
                }
                var toastElement = document.getElementById("notification");
                var toast = new bootstrap.Toast(toastElement);
                toast.show();
            },
            error: function (xhr, status, error) {
                // Handle the error response here
                console.log("Error: " + error);
            }
        });
        // Update Save Button so that it is no longer disabled
        stopWebDriver.disabled = false;
        // Disable Stop Button
        this.disabled = true;
    });
    // STOP
    $("#stopWebDriver").click(function (e) {
        e.preventDefault();
        // Get Save Button
        const saveWebDriver = document.querySelector('#saveWebDriver');
        $.ajax({
            url: "/Dashboard/StopRecorder",
            method: "POST",
            success: function (response) {
                if (toastBody) {
                    toastBody.textContent = 'Recorder STOPPED successfully! Click SAVE to keep recording...';
                }
                var toastElement = document.getElementById("notification");
                var toast = new bootstrap.Toast(toastElement);
                toast.show();
            },
            error: function (xhr, status, error) {
                console.error(error, status, xhr);
            }
        });
        // Update Save Button so that it is no longer disabled
        saveWebDriver.disabled = false;
        // Disable Stop Button
        this.disabled = true;
    });
    // SAVE
    $("#saveWebDriver").click(function (e) {
        e.preventDefault();
        // Get Start Button
        const startWebDriver = document.querySelector('#startWebDriver');
        $.ajax({
            url: "/Dashboard/SaveRecording",
            method: "POST",
            success: function (response) {
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.error(error, status, xhr);
            }
        });
        // Update Start Button so that it is no longer disabled
        startWebDriver.disabled = false;
        // Disable Save Button
        this.disabled = true;
    });
});
// PLAYBACK - START
$(document).ready(function () {
    $("#idrLoginPlay").click(function (e) {
        e.preventDefault();
        $.ajax({
            url: "/Dashboard/Playback",
            method: "GET",
            success: function (response) {
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
    });
});
// SUIT REGISTRATION
$(document).ready(function () {
    $("#registerSuit").submit(function (e) {
        e.preventDefault(); // Prevent form submission

        // Serialize the form data
        var formData = $(this).serialize();

        // Send an AJAX request to the RegisterSuit action
        $.ajax({
            url: "/Dashboard/RegisterSuit",
            type: "POST",
            data: formData,
            success: function (result) {
                // Update the dropdown with the newly registered suit
                var newSuit = result.suit;
                var optionText = newSuit.suitName + " | " + newSuit.suitPlan;
                var newOption = $("<option>").attr("value", newSuit.suitName).text(optionText);
                $("#suitNameSelect").append(newOption);
                $("#suitNameSelect").val(newSuit.suitName);
                $("#createNewSuit").offcanvas("hide");
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });
    });
});
// TEST CREATION VALIDATE
$("#createTest").submit(function (e) {
    var isValid = this.checkValidity(); // Check if the form is valid
    if (!isValid) {
        e.preventDefault(); // Prevent form submission if there are validation errors
        showValidationErrors();
    }
});
// CONSOLE
$(document).ready(function () {
    var delay = 500;
    $('.card').each(function (index) {
        var card = $(this);
        setTimeout(function () {
            card.removeClass('hidden').addClass('visible');
        }, index * delay);
    });

    const consoleOutput = document.querySelector('.console-output');
    const consoleCursor = document.querySelector('.console-cursor');
    let actions = ['AWAIT - TOOLBOX!'];
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
            index = (index + 1) % actions.length;
            const nextText = actions[index];
            typeText(nextText);
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
            if (lastCharacter instanceof Element) {
                const rect = lastCharacter.getBoundingClientRect();
                const marginLeft = rect.right + 'px';
                consoleCursor.style.marginLeft = marginLeft;
            }
        }
    }

    // Start printing text once loaded
    const initialText = actions[index];
    typeText(initialText);

    // CREATE TEST
    $("#createTest").submit(function (e) {
        e.preventDefault(); // Prevent form submission

        // Serialize the form data
        var formData = $(this).serialize();

        $.ajax({
            url: "/Dashboard/CreateTest",
            type: "POST",
            data: formData,
            success: function (result) {
                // Check if the response contains an error
                if (result.error) {
                    // Handle the case when the suit name already exists
                    console.log("Error: " + result.error);

                    // Show an error notification to the user
                    const toastBody = document.querySelector('.toast-body');
                    if (toastBody) {
                        toastBody.textContent = 'Suit Name Already Exists!';
                    }
                    var toastElement = document.getElementById("notification");
                    var toast = new bootstrap.Toast(toastElement);
                    toast.show();
                } else {
                    // Handle the successful case
                    console.log(result);

                    // Disable the "Save" button
                    $(".btn-outline-info").prop("disabled", true);
                    $(".btn-outline-info").prop("value", "SAVED!");

                    // Update the actions
                    actions = [result.test.action];

                    var startButton = $("#startWebDriver");
                    startButton.prop("disabled", false);
                    startButton.addClass("btn-outline-success");
                    startButton.addClass("pulse-animation");

                    // Show the success notification
                    const toastBody = document.querySelector('.toast-body');
                    if (toastBody) {
                        toastBody.textContent = 'Successfully Created Test!';
                    }
                    var toastElement = document.getElementById("notification");
                    var toast = new bootstrap.Toast(toastElement);
                    toast.show();

                    // Hide the form or perform any other actions
                    $("#createNewSuit").offcanvas("hide");
                }
            },
            error: function (xhr, status, error) {
                console.log("Error: " + error);
            }
        });

    });

});
// BY: Branden v Staden