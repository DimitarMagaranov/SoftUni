import { render } from '../node_modules/lit-html/lit-html.js';
import page from '../node_modules/page/page.mjs';

import { logout } from './api/data.js';

import {homePage} from './views/home.js';
import {loginPage} from './views/login.js';
import {registerPage} from './views/register.js';
import {allListingsPage} from './views/allListings.js';
import {detailsPage} from './views/details.js';
import {createPage} from './views/create.js';
import {editListing} from './views/edit.js';
import {myListingsPage} from './views/myListings.js';
import {searchPage} from './views/search.js';

setUserNav();

const main = document.getElementById('site-content');

page('/', decorateContext, homePage);
page('/login', decorateContext, loginPage);
page('/register', decorateContext, registerPage);
page('/allListings', decorateContext, allListingsPage);
page('/details/:id', decorateContext, detailsPage);
page('/create', decorateContext, createPage);
page('/edit/:id', decorateContext, editListing);
page('/myListings', decorateContext, myListingsPage);
page('/search', decorateContext, searchPage);

page.start();

function decorateContext(context, next) {
    context.render = (content) => render(content, main);
    context.setUserNav = setUserNav;
    next();
}

function setUserNav() {
    const userToken = sessionStorage.getItem('authToken');

    if (userToken) {
        document.getElementById('guest').style.display = 'none';
        document.getElementById('profile').style.display = 'block';
        document.getElementById('welcomeMsg').textContent = `Welcome ${sessionStorage.getItem('username')}`;
    } else {
        document.getElementById('guest').style.display = 'block';
        document.getElementById('profile').style.display = 'none';
        document.getElementById('welcomeMsg').textContent = '';
    }
}

document.getElementById('logoutBtn').addEventListener('click', async () => {
    await logout();
    setUserNav();
    page.redirect('/');
})