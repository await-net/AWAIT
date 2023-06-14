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
    $("#setNewURL").click(function (e) {
        e.preventDefault();

        var isPressed = $(this).attr("aria-pressed") === "false";
        var dispose = false;
        if (isPressed) {
            dispose = true;
        }
        
        if (dispose) {
            // Send the AJAX request
            $.ajax({
                url: "/Dashboard/DisposeWebDriver",
                method: "GET",
                success: function (response) {
                    console.log(response);
                },
                error: function (xhr, status, error) {
                    console.error(error);
                }
            });
        } else {
            var url = $("#newURLValue").val();
            // Send the AJAX request
            $.ajax({
                url: "/Dashboard/Recorder",
                method: "GET",
                data: { url: url },
                success: function (response) {
                    console.log(response);
                },
                error: function (xhr, status, error) {
                    console.error(error);
                }
            });
        }
    });
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
    const toastTrigger = document.getElementById('playbackNotify')
    const toastLiveExample = document.getElementById('notification')

    if (toastTrigger) {
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)
        toastTrigger.addEventListener('click', () => {
            toastBootstrap.show()
        })
        }
    });
});

//------------------------------------------------------
//============ BUILT BY: Branden van Staden ============
//------------------------------------------------------