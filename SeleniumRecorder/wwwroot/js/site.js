// Manage ACTIVE NAV-LINK-TABS
window.addEventListener('DOMContentLoaded', function () {
    var title = this.document.title;
    console.log(title);
    if (title.startsWith('ToolBox') == true) {
        var navItem = document.querySelector('#toolboxNav');
        navItem.classList.add('active');
    }
    if (title.startsWith('Dashboard') == true) {
        var navItem = document.querySelector('#dashboardNav');
        navItem.classList.add('active');
    }

});
