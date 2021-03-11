import { showHome } from './home.js';

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

    const response = await fetch('http://localhost:3030/users/login', {
        method: 'post',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ email, password })
    });

    if (response.ok === false) {
        const error = await response.json();
        alert(error.message);
        return;
    }

    ev.target.reset();

    const data = await response.json();

    sessionStorage.authToken = data.accessToken;
    sessionStorage.userId = data._id;
    sessionStorage.email = data.email;

    [...document.querySelectorAll('nav .user')].forEach(x => x.style.display = 'block');
    [...document.querySelectorAll('nav .guest')].forEach(x => x.style.display = 'none');
    document.getElementById('welcome-msg').textContent = `Welcome, ${data.email}`;

    showHome();
}