import{register} from '../api/data.js';

export function setupRegister(section, navigation) {
    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit);

    return showRegister;

    async function showRegister() {
        return section;
    }

    async function onSubmit(ev) {
        ev.preventDefault();

        const formData = new FormData(ev.target);
        const email = formData.get('email');
        const password = formData.get('password');
        const rePass = formData.get('repeatPassword');

        if(email == '' || password == '' || rePass == '') {
            alert('All fields are required!');
            return;
        }

        if(password != rePass) {
            alert('The passwords do not match!');
            return;
        }

        await register(email, password);
        form.reset();

        navigation.setUserNav();
        navigation.goTo('home');
    }
}