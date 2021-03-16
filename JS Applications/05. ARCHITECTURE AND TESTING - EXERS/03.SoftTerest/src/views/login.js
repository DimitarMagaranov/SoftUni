import {login} from '../api/data.js';

export function setupLogin(section, navigation) {
    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);

    return showLogin;

    async function showLogin() {
        return section;
    }

    async function onSubmit(ev) {
        ev.preventDefault();
    
        const formData = new FormData(ev.target);
        const email = formData.get('email');
        const password = formData.get('password');

        if(email == '' || password == '') {
            alert('All fields are required!');
            return;
        }
    
        await login(email, password);
        form.reset();

        navigation.setUserNav();
        navigation.goTo('home');
    }
}