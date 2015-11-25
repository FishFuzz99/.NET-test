// site.js
(function startup() {
    var element = document.getElementById("username");
    element.innerHTML = "Andrew Gray";

    var main = document.getElementById("main");
    main.onmouseenter = function () {
        main.style = "background-color: #888;";
    };
    main.onmouseleave = function () {
        main.style = "";
    };
})();
