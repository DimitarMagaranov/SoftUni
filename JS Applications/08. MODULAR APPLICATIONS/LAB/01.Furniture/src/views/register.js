import { html, reparentNodes } from '../../node_modules/lit-html/lit-html.js';
import { register } from '../api/data.js';

const registerTemplate = (onSubmit, isInvalidEmail, isInvalidPass, isInvalidRePass) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class=${'form-control' + (isInvalidEmail ? ' is-invalid' : '')} id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class=${'form-control' + (isInvalidPass ? ' is-invalid' : '')} id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class=${'form-control' + (isInvalidRePass ? ' is-invalid' : '')} id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>`;

export async function registerPage(context) {
    context.render(registerTemplate(onSubmit));

    async function onSubmit(ev) {
        ev.preventDefault();
    
        const formData = new FormData(ev.target);
        const email = formData.get('email');
        const password = formData.get('password');
        const rePass = formData.get('rePass');
    
        if(email == '' || password == '' || rePass == '') {
            context.render(registerTemplate(onSubmit, email == '', password == '', rePass == ''));
            return alert('All fields are required!');
        }
    
        if(password != rePass) {
            context.render(registerTemplate(onSubmit, false, true, true));
            return alert('The passwords do not match!');
        }
    
        await register(email, password);

        context.setUserNav();
        context.page.redirect('/');
    }
}