// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// select + input label animation
/*window.onload = function () {
    // Material Design Input function
    var inputs = document.querySelectorAll('select, input');

    for (var i = 0; i < inputs.length; i++) {
        inputs[i].addEventListener('focus', function (e) {
            this.parentElement.classList.add('is-focused');
        }, false);

        inputs[i].onkeyup = function (e) {
            if (this.value != "") {
                this.parentElement.classList.add('is-filled');
            } else {
                this.parentElement.classList.remove('is-filled');
            }
        };

        inputs[i].addEventListener('focusout', function (e) {
            if (this.value != "") {
                this.parentElement.classList.add('is-filled');
            }
            this.parentElement.classList.remove('is-focused');
        }, false);
    }

    // Ripple Effect
    var ripples = document.querySelectorAll('.btn');

    for (var i = 0; i < ripples.length; i++) {
        ripples[i].addEventListener('click', function (e) {
            var targetEl = e.target;
            var rippleDiv = targetEl.querySelector('.ripple');

            rippleDiv = document.createElement('span');
            rippleDiv.classList.add('ripple');
            rippleDiv.style.width = rippleDiv.style.height = Math.max(targetEl.offsetWidth, targetEl.offsetHeight) + 'px';
            targetEl.appendChild(rippleDiv);

            rippleDiv.style.left = (e.offsetX - rippleDiv.offsetWidth / 2) + 'px';
            rippleDiv.style.top = (e.offsetY - rippleDiv.offsetHeight / 2) + 'px';
            rippleDiv.classList.add('ripple');
            setTimeout(function () {
                rippleDiv.parentElement.removeChild(rippleDiv);
            }, 600);
        }, false);
    }
};*/
