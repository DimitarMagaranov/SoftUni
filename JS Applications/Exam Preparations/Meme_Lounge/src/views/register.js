import { html, reparentNodes } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../api/data.js';
import { notify } from '../notification.js';


const template = (onSubmit) => html`
<section id="register">
    <form @submit=${onSubmit} id="register-form">
        <div class="container">
            <h1>Register</h1>
            <label for="username">Username</label>
            <input id="username" type="text" placeholder="Enter Username" name="username">
            <label for="email">Email</label>
            <input id="email" type="text" placeholder="Enter Email" name="email">
            <label for="password">Password</label>
            <input id="password" type="password" placeholder="Enter Password" name="password">
            <label for="repeatPass">Repeat Password</label>
            <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
            <div class="gender">
                <input type="radio" name="gender" id="female" value="female">
                <label for="female">Female</label>
                <input type="radio" name="gender" id="male" value="male" checked>
                <label for="male">Male</label>
            </div>
            <input type="submit" class="registerbtn button" value="Register">
            <div class="container signin">
                <p>Already have an account?<a href="#">Sign in</a>.</p>
            </div>
        </div>
    </form>
</section>`;

export async function registerPage(context) {
    context.render(template(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();
    
        const formData = new FormData(ev.target);
        const username = formData.get('username');
        const email = formData.get('email');
        const password = formData.get('password');
        const rePass = formData.get('repeatPass');
        const gender = [...ev.target.querySelector('.gender').querySelectorAll('input')].find(x => x.checked == true).value;

        try {
            if(email == '' || password == '' || username == '' || rePass == '') {
                throw new Error('All fields are required!');
            }

            if(password != rePass) {
                throw new Error('The passwords do not match!');
            }
        
            const response = await register(username, email, password, gender);
            console.log(response)
    
            context.setUserNav();
            context.page.redirect('/allMemes');

        } catch (err) {
            notify(err.message);
            throw err;
        }
    }
}