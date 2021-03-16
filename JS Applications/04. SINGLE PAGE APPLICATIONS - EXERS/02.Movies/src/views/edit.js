import {editMovieById} from '../api/data.js';

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

    const data = {
        title,
        description,
        img
    };

    await editMovieById(movieId, data);

    showDetails(movieId);
}