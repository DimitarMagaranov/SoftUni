import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { logout } from './api/data.js';

import { welcomePage } from './views/welcomePage.js';
import { allMemesPage } from './views/allMemesPage.js';
import { loginPage } from './views/login.js';
import { registerPage } from './views/register.js';
import { createPage } from './views/create.js';
import { detailsPage } from './views/details.js';
import { editPage } from './views/edit.js';
import { userPage } from './views/userPage.js';

setUserNav();

const main = document.querySelector('main');

page('/', decorateContext, welcomePage);
page('/allMemes', decorateContext, allMemesPage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/create', decorateContext, createPage);
page('/data/memes/:id', decorateContext, detailsPage);
page('/edit/:id', decorateContext, editPage);
page('/myProfile', decorateContext, userPage);

page.start();

function decorateContext(context, next) {
    context.render = (content) => render(content, main);
    context.setUserNav = setUserNav;
    next();
}

function setUserNav() {
    const userToken = sessionStorage.getItem('authToken');

    if (userToken) {
        document.querySelector('nav > .user').style.display = 'block';
        document.querySelector('nav > .guest').style.display = 'none';
        document.getElementById('welcomeMsg').textContent = `Welcome, ${sessionStorage.getItem('email')}`;
    } else {
        document.querySelector('nav > .user').style.display = 'none';
        document.querySelector('nav > .guest').style.display = 'block';
        document.getElementById('welcomeMsg').textContent = '';
    }
}

document.getElementById('logoutBtn').addEventListener('click', async () => {
    // const confirmed = confirm('Are you sure you want to logout?');
    // if (confirmed) {
    //     await logout();
    //     setUserNav();
    //     page.redirect('/');
    // }

    await logout();
    setUserNav();
    page.redirect('/');
})