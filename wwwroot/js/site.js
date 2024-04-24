// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const tableElement = document.querySelectorAll('[id=data]');


tableElement.forEach(element => {
    element.addEventListener('dblclick', () => {
        console.log('hier steht was');
    });
});
