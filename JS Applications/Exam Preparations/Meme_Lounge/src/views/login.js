import { html } from '../../node_modules/lit-html/lit-html.js';
import { login } from '../api/data.js';
import { notify } from '../notification.js';

const template = (onSubmit) => html`
<section id="login">
    <form @submit="${onSubmit}" id="login-form">
        <div class="container">
            <h1>Login</h1>
            <label for="email">Email</label>
            <input id="email" placeholder="Enter Email" name="email" type="text">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <input type="submit" class="registerbtn button" value="Login">
            <div class="container signin">
                <p>Dont have an account?<a href="#">Sign up</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export async function loginPage(context) {
    context.render(template(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();
    
        const formData = new FormData(ev.target);
        const email = formData.get('email');
        const password = formData.get('password');

        try {
            if(email == '' || password == '') {
                throw new Error('All fields are required!');
            }
        
            await login(email, password);
    
            context.setUserNav();
            context.page.redirect('/');

        } catch (err) {
            notify(err.message);
            throw err;
        }
    }
}