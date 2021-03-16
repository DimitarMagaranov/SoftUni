import { e } from '../dom.js';
import { deleteIdeaById, getIdeaById } from '../api/data.js';

export function setupDetails(section, navigation) {
    return showDetails;

    async function showDetails(id) {
        section.innerHTML = '';

        const idea = await getIdeaById(id);

        const userId = sessionStorage.getItem('userId');

        const isOwner = userId == idea._ownerId ? true : false;

        const card = createIdeaCard(idea, isOwner, navigation.goTo);

        section.appendChild(card);
        return section;
    }
}

function createIdeaCard(idea, isOwner, goTo) {
    const result = document.createDocumentFragment();

    result.appendChild(e('img', { className: 'det-img', src: idea.img }));
    result.appendChild(e('div', { className: 'desc' },
        e('h2', { className: 'display-5' }, idea.title),
        e('p', { className: 'infoType' }, 'Description:'),
        e('p', { className: 'idea-description' }, idea.description)
    ));

    if (isOwner) {
        result.appendChild(e('div', { className: 'text-center' },
            e('a', { className: 'btn detb', href: '', onClick: onDelete }, 'Delete')
        ));
    }

    return result;

    async function onDelete(ev) {
        ev.preventDefault();

        const confirmed = confirm('Are you sure you want to delete this idea?');

        if (confirmed) {
            await deleteIdeaById(idea._id);
            goTo('dashboard');
        }
    }
}