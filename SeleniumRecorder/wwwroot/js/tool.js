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
    });
});
// Get all the tab links inside the .nav.nav-tabs element
const tabLinks = document.querySelectorAll('.nav.nav-tabs .nav-link');
// Add click event listener to each tab link
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
$(document).ready(function () {
    const toastLiveExample = document.getElementById('notification');
    const toastTrigger = document.getElementById('startWebDriver');

    $("#startWebDriver").click(function (e) {
        e.preventDefault();
        // Get Stop Button
        const stopWebDriver = document.querySelector('#stopWebDriver');
        // Get URL Input
        var url = $("#newURLValue").val();
        $.ajax({
            url: "/Dashboard/Recorder",
            method: "GET",
            data: { url: url, stop: false },
            success: function (response) {
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.error(error, status, xhr);
            }
        });
        // Update Buttons ariaDisabled
        stopWebDriver.disabled = false;
        this.disabled = true;
        // Find the toast body element by its class
        const toastBody = document.querySelector('.toast-body');

        // Check if the toast body element exists
        if (toastBody) {
            // Change the text content of the toast body element
            toastBody.textContent = 'Tool has Started Recording!';
        }
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
        toastBootstrap.show()

    });

    $("#stopWebDriver").click(function (e) {
        e.preventDefault();
        // Get Save Button
        const saveWebDriver = document.querySelector('#saveWebDriver');
        $.ajax({
            url: "/Dashboard/StopRecorder",
            method: "GET",
            success: function (response) {
                console.log(response);
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

    $("#saveWebDriver").click(function (e) {
        e.preventDefault();
        // Get Start Button
        const startWebDriver = document.querySelector('#startWebDriver');
        $.ajax({
            url: "/Dashboard/SaveRecording",
            method: "POST",
            success: function (response) {
                console.log(response);
                // Update Start Button so that it is no longer disabled
                startWebDriver.disabled = false;
                // Disable Save Button
                this.disabled = true;
            },
            error: function (xhr, status, error) {
                console.error(error, status, xhr);
            }
        });
    });    
    //if (toastTrigger) {
      //  const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
        //toastTrigger.addEventListener('click', () => {
          //  toastBootstrap.show()
        //});
    //}
});

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

//------------------------------------------------------
//============ BUILT BY: Branden van Staden ============
//------------------------------------------------------