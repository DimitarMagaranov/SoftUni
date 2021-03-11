import {showDetails} from './details.js';

let main;
let section;

export function setupCreate(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    section.querySelector('form').addEventListener('submit', onSubmit);
}

export async function showCreate() {
    main.innerHTML = '';
    main.appendChild(section);
}

async function onSubmit(ev) {
    ev.preventDefault();
    
    const formData = new FormData(ev.target);
    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    if(title == '' || description == '' || img == '') {
        alert('All fields are required!');
        return;
    }

    const response = await fetch('http://localhost:3030/data/movies', {
        method: 'post',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify({title, description, img})
    });

    if(response.ok == false) {
        const error = await response.json();
        alert(error.message);
        return;
    }

    const data = await response.json();
    showDetails(data._id);
}