import { login } from '../api/data.js';

let main;
let section;

export function setupLogin(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    const form = section.querySelector('form');
    form.addEventListener('submit', onLoginSubmit);
}

export async function showLogin() {
    main.innerHTML = '';
    main.appendChild(section);
}

async function onLoginSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const email = formData.get('email');
    const password = formData.get('password');

    if (email == '' || password == '') {
        alert('All fields are required!');
        return;
    }

    await login(email, password);

    ev.target.reset();

    [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'block');
    [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'none');
    document.getElementById('welcome-msg').textContent = `Welcome, ${response.email}`;
}