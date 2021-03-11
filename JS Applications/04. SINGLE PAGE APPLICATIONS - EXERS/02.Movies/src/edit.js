import {showDetails} from './details.js';

let main;
let section;
let movieId;

export function setupEdit(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
    section.querySelector('form').addEventListener('submit', onSubmit);
}

export async function showEdit(movie) {
    main.innerHTML = '';
    movieId = movie._id;

    section.querySelector('#titleInput').value = movie.title;
    section.querySelector('#descriptionInput').value = movie.description;
    section.querySelector('#imageInput').value = movie.img;

    main.appendChild(section);
}

async function onSubmit(ev) {
    ev.preventDefault();

    const formData = new FormData(ev.target);
    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageUrl');

    if (title == '' || description == '' || img == '') {
        alert('All fields are required!');
        return;
    }

    const response = await fetch('http://localhost:3030/data/movies/' + movieId, {
        method: 'put',
        headers: {
            'Content-Type': 'application/json',
            'X-Authorization': sessionStorage.getItem('authToken')
        },
        body: JSON.stringify({ title, description, img })
    });

    if (response.ok == false) {
        const error = await response.json();
        alert(error.message);
        return;
    }

    showDetails(movieId);
}