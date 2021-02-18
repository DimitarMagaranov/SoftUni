function validate() {
    const inputField = document.getElementById('email');

    const regex = /^[a-z0-9]+@[a-z0-9]+\.[a-z0-9]+$/gm;

    inputField.addEventListener('change', onchange);

    function onchange(ev) {
        if(regex.test(ev.target.value) === false) {
            inputField.classList.add('error');
        } else {
            inputField.removeAttribute('class');
        }
    }
}