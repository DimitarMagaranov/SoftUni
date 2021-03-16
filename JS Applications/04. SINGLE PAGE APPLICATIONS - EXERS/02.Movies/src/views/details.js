import { e } from '../dom.js';
import { getLikesByMovieId, getOwnLikesByMovieId, getMovieById, likeMovieById, deleteMovieById } from '../api/data.js';


export function setupDetails(section, navigation) {
    return showDetails;

    async function showDetails(id) {
        section.innerHTML = '';
    
        const [movie, likes, ownLike] = await Promise.all([
            getMovieById(id),
            getLikesByMovieId(id),
            getOwnLikesByMovieId(id)
        ]);

        const card = createElement(movie, likes, ownLike, navigation.goTo);
    
        section.appendChild(card);

        return section;
    }
}

function createElement(movie, likes, ownLike, goTo) {
    const controls = e('div', { className: 'col-md-4 text-center' },
        e('h3', { className: 'my-3' }, 'Movie Description'),
        e('p', {}, movie.description),
    );

    const userId = sessionStorage.getItem('userId');

    if (userId != null) {
        if (userId == movie._ownerId) {
            controls.appendChild(e('a', { id: 'deleteBtn', className: 'btn btn-danger', href: '#', onClick: onDelete }, 'Delete'));
            controls.appendChild(e('a', { id: 'editBtn', className: 'btn btn-warning', href: '#', onClick: () => goTo('details', movie._id) }, 'Edit'));
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

    async function onDelete() {
        const confirmed = confirm('Are you sure you want to delete the movie?');
        if (confirmed) {
            await deleteMovieById(movie._id);
        }
    }

    async function likeMovie(ev) {
        const movieId = { movieId: movie._id };

        await likeMovieById(movieId);

        ev.target.remove();
        likes++;
        likesSpan.textContent = likes + ' like' + (likes == 1 ? '' : 's');
    }
}