import { e } from './dom.js';
import { showEdit } from './edit.js';
import { showHome } from './home.js';

async function getLikesByMovieId(id) {
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`);
    const data = await response.json();

    return data;
}

async function getOwnLikesByMovieId(id) {
    const userId = sessionStorage.getItem('userId');
    const response = await fetch(`http://localhost:3030/data/likes?where=movieId%3D%22${id}%22%20and%20_ownerId%3D%22${userId}%22`);
    const data = await response.json();

    return data;
}

async function getMovieById(id) {
    const response = await fetch('http://localhost:3030/data/movies/' + id);

    if (response.ok === false) {
        const error = await response.json();
        alert(error.message);
        return;
    }

    const data = await response.json();
    return data;
}

function createElement(movie, likes, ownLike) {
    const controls = e('div', { className: 'col-md-4 text-center' },
        e('h3', { className: 'my-3' }, 'Movie Description'),
        e('p', {}, movie.description),
    );

    const userId = sessionStorage.getItem('userId');

    if (userId != null) {
        if (userId == movie._ownerId) {
            controls.appendChild(e('a', { id: 'deleteBtn', className: 'btn btn-danger', href: '#', onClick: deleteMovie }, 'Delete'));
            controls.appendChild(e('a', { id: 'editBtn', className: 'btn btn-warning', href: '#', onClick: editMovie }, 'Edit'));
        } else if (ownLike.length == 0) {
            controls.appendChild(e('a', { id: 'likeBtn', className: 'btn btn-primary', href: '#', onClick: likeMovie }, 'Like'));
        }
    }
    let likesSpan = e('span', { className: 'enrolled-span' }, likes + ' like' + (likes == 1 ? '' : 's'));
    controls.appendChild(likesSpan);

    const element = document.createElement('div');
    element.className = 'container';
    element.appendChild(e('input', { type: 'hidden', id: movie._id }));
    element.appendChild(e('div', { className: 'row bg-light text-dark' },
        e('h1', {}, `Movie title: ${movie.title}`),
        e('div', { className: 'col-md-8' }, e('img', { className: 'img-thumbnail', src: movie.img, alt: 'Movie' })),
        controls
    ));

    return element;

    async function likeMovie(ev) {
        const response = await fetch('http://localhost:3030/data/likes/', {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': sessionStorage.getItem('authToken')
            },
            body: JSON.stringify({ movieId: movie._id })
        });

        if (response.ok) {
            ev.target.remove();
            likes++;
            likesSpan.textContent = likes + ' like' + (likes == 1 ? '' : 's');
        }
    }

    function editMovie() {
        showEdit(movie);
    }

    async function deleteMovie() {
        const confirmed = confirm('Are you sure you want to delete the movie?');
        if (confirmed) {
            const response = await fetch('http://localhost:3030/data/movies/' + movie._id, {
                method: 'delete',
                headers: { 'X-Authorization': sessionStorage.getItem('authToken') }
            });

            if (response.ok == false) {
                const error = await response.json();
                alert(error.message);
                return;
            }

            showHome();
        }
    }
}

let main;
let section;

export function setupDetails(mainTarget, sectionTarget) {
    main = mainTarget;
    section = sectionTarget;
}

export async function showDetails(id) {
    section.innerHTML = '';
    main.innerHTML = '';
    main.appendChild(section);

    const [movie, likes, ownLike] = await Promise.all([
        getMovieById(id),
        getLikesByMovieId(id),
        getOwnLikesByMovieId(id)
    ])
    const card = createElement(movie, likes, ownLike);

    section.appendChild(card);
}