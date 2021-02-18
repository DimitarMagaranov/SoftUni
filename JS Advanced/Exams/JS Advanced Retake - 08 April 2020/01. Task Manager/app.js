function solve() {
    const parentDiv = document.getElementsByClassName('wrapper')[0];
    const form = document.getElementsByTagName('form')[0];
    const taskInputField = form.querySelector('#task');
    const descriptionInputFIeld = form.querySelector('#description');
    const dueDateInputField = form.querySelector('#date');
    const formButton = form.querySelector('#add');
    const openSection = parentDiv.children[1];
    const openDiv = openSection.children[1];
    const inProgresSection = parentDiv.children[2];
    const completeSection = parentDiv.children[3];


    parentDiv.addEventListener('click', onclick);

    function onclick(ev) {
        if (ev.target === formButton) {
            ev.preventDefault();

            if (taskInputField.value === '' || descriptionInputFIeld.value === '' || dueDateInputField.value === '') {
                return;
            }

            createOpenElement();
        } else if (ev.target.parentNode.parentNode.parentNode.parentNode === openSection) {
            const article = ev.target.parentNode.parentNode;
            
            if (ev.target.textContent === 'Start') {
                moveTaskToInProgressSection(article);
            } else if (ev.target.textContent === 'Delete') {
                article.remove();
            }
        } else if(ev.target.parentNode.parentNode.parentNode.parentNode === inProgresSection) {
            const article = ev.target.parentNode.parentNode;

            if(ev.target.textContent === 'Finish') {
                const completeArticle = article.cloneNode(true);
                article.remove();
                completeArticle.querySelector('.flex').remove();
                completeSection.children[1].appendChild(completeArticle);
            } else if(ev.target.textContent === 'Delete') {
                article.remove();
            }
        }
    }

    function moveTaskToInProgressSection(article) {
        const duplicateArticle = article.cloneNode(true);
        article.remove();
        duplicateArticle.querySelectorAll('button')[0].textContent = 'Delete';
        duplicateArticle.querySelectorAll('button')[0].classList.remove('green');
        duplicateArticle.querySelectorAll('button')[0].classList.add('red');
        duplicateArticle.querySelectorAll('button')[1].textContent = 'Finish';
        duplicateArticle.querySelectorAll('button')[1].classList.remove('red');
        duplicateArticle.querySelectorAll('button')[1].classList.add('orange');
        inProgresSection.children[1].appendChild(duplicateArticle);
    }

    function createOpenElement() {
        const h3 = createElement('h3', taskInputField.value);
        const p1 = createElement('p', `Description: ${descriptionInputFIeld.value}`);
        const p2 = createElement('p', `Due Date: ${dueDateInputField.value}`);
        const startButton = createElement('button', 'Start');
        startButton.classList.add('green');
        const deleteButton = createElement('button', 'Delete');
        deleteButton.classList.add('red');
        const div = createElement('div', startButton, deleteButton);
        div.classList.add('flex');
        const article = createElement('article', h3, p1, p2, div);
        openDiv.appendChild(article);

        clersInputFields();
    }

    function clersInputFields() {
        taskInputField.value = '';
        descriptionInputFIeld.value = '';
        dueDateInputField.value = '';
    }

    function createElement(type, ...content) {
        const result = document.createElement(type);

        content.forEach(e => {
            if (typeof e == 'string') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }
}