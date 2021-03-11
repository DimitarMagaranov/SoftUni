// import modules
import { setupHome, showHome } from './home.js';
import { setupDetails } from './details.js';
import { setupLogin, showLogin } from './login.js';
import { setupRegister, showRegister } from './register.js';
import { setupCreate, showCreate } from './create.js';
import { setupEdit } from './edit.js';


const main = document.querySelector('main');

const links = {
    'homeLink': showHome,
    'loginLink': showLogin,
    'registerLink': showRegister,
}

setupSection("home-page", setupHome);
setupSection("add-movie", setupCreate);
setupSection("movie-details", setupDetails);
setupSection("edit-movie", setupEdit);
setupSection("form-login", setupLogin);
setupSection("form-sign-up", setupRegister);

setupNavigation();

// start application in home view
showHome();

function setupSection(sectionId, setup) {
    const section = document.getElementById(sectionId);
    setup(main, section);
}

function setupNavigation() {
    setupVisibleNavLinks();

    document.querySelector('nav').addEventListener('click', (ev) => {
        const view = links[ev.target.id];
        if (typeof view == 'function') {
            ev.preventDefault();
            view();
        }
    });

    document.getElementById('createLink').addEventListener('click', (ev) => {
        ev.preventDefault();
        showCreate();
    });

    document.getElementById('logoutBtn').addEventListener('click', logout);
}

function setupVisibleNavLinks() {
    const userEmail = sessionStorage.email;

    const userLinks = [...document.querySelectorAll('nav .user')];
    const guestLinks = [...document.querySelectorAll('nav .guest')];

    if (userEmail != null) {
        userLinks.forEach(x => x.style.display = 'block');
        guestLinks.forEach(x => x.style.display = 'none');
        document.getElementById('welcome-msg').textContent = `Welcome, ${userEmail}`;
    } else {
        userLinks.forEach(x => x.style.display = 'none');
        guestLinks.forEach(x => x.style.display = 'block');
    }
}

async function logout() {
    const token = sessionStorage.getItem('authToken');
    const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: { 'X-Authorization': token }
    });

    if (response.ok == false) {
        const error = await response.json();
        alert(error.message);
        return;
    }

    sessionStorage.removeItem('authToken');
    sessionStorage.removeItem('userId');
    sessionStorage.removeItem('email');

    setupVisibleNavLinks();
    showHome();
}