import { e } from '../dom.js';
import { getMovies } from '../api/data.js';



export function setupHome(section, nav) {
    const container = section.querySelector('.card-deck.d-flex.justify-content-center');

    return showHome;

    async function showHome() {
        container.innerHTML = 'Loading&hellip;';

        const movies = await getMovies();
        const cards = movies.map(createMoviePreview);

        const fragment = document.createDocumentFragment();
        cards.forEach(x => fragment.appendChild(x));

        container.innerHTML = '';
        container.appendChild(fragment);

        return section;
    }

    function createMoviePreview(movie) {
        const element =
            e('div', { className: 'card mb-4' },
                e('img', { className: 'card-img-top', src: movie.img, alt: 'Card image cap', width: '400' }),
                e('div', { className: 'card-body' },
                    e('h4', { className: 'card-title' }, movie.title)),
                e('div', { className: 'card-footer' },
                    e('button', { id: movie._id, type: 'button', className: 'btn btn-info movieDetailsLink', onClick: () => nav.goTo('details', movie._id) }, 'Details')));
    
        return element;
    };
}