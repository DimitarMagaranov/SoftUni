async function solution() {
    const main = document.getElementById('main');

    const allArticlesUrl = 'http://localhost:3030/jsonstore/advanced/articles/list';
    const responseArticles = await fetch(allArticlesUrl);
    const allArticles = await responseArticles.json();

    for(let article of allArticles) {
        const span = createElement('span', article.title);
        const button = createElement('button', 'More');
        button.classList.add('button');
        button.id = article._id;
        button.addEventListener('click', onclick);
        const headDiv = createElement('div', span, button);
        headDiv.classList.add('head');

        const articleInfoUrl = 'http://localhost:3030/jsonstore/advanced/articles/details/' + article._id;
        const articleInfoResponse = await fetch(articleInfoUrl);
        const data = await articleInfoResponse.json();
        const extraDiv = createElement('div', createElement('p', data.content));
        extraDiv.classList.add('extra');

        const accordionDiv = createElement('div', headDiv, extraDiv);
        accordionDiv.classList.add('accordion');

        main.appendChild(accordionDiv);
    }
}

function onclick(ev) {
    const hiddenDiv = ev.target.parentNode.parentNode.children[1];
    
    if(ev.target.textContent === 'More') {
        ev.target.textContent = 'Less';
        hiddenDiv.classList.remove('extra');
    } else {
        ev.target.textContent = 'More';
        hiddenDiv.classList.add('extra');
    }
}

function createElement(type, ...content) {
    const result = document.createElement(type);

    content.forEach(e => {
        if (typeof e == 'string' || typeof e == 'number') {
            const node = document.createTextNode(e.toString());
            result.appendChild(node);
        } else {
            result.appendChild(e);
        }
    });

    return result;
}