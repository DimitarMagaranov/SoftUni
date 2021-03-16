import { register } from '../api/data.js';

let main;
let section;

export function setupRegister(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    const form = section.querySelector('form');
    form.addEventListener('submit', onRegisterSubmit);
}

export async function showRegister() {
    main.innerHTML = '';
    main.appendChild(section);
}

async function onRegisterSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('rePass');

    if (email == '' || password == '' || rePass == '') {
        alert('All fields are required!');
        return;
    }

    if (password != rePass) {
        alert('Passwords do not match!');
        return;
    }

    await register(email, password);

    ev.target.reset();

    [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'block');
    [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'none');
    document.getElementById('welcome-msg').textContent = `Welcome, ${data.email}`;
}