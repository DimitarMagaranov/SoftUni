function solve() {
    const container = document.getElementsByClassName('container')[0];
    const modulesDiv = container.getElementsByClassName('modules')[0];
    const form = container.children[1].getElementsByTagName('form')[0];
    const lectureInput = form.children[0].getElementsByTagName('input')[0];
    const dateInput = form.children[1].getElementsByTagName('input')[0];
    const moduleDropdown = form.children[2].getElementsByTagName('select')[0];

    container.addEventListener('click', onclick);

    function onclick(ev) {
        if (ev.target.tagName === 'BUTTON' && ev.target.textContent === 'Add') {
            ev.preventDefault();

            const selectedModule = moduleDropdown.options[moduleDropdown.selectedIndex].value;

            if (lectureInput.value === '' ||
                dateInput.value === '' ||
                selectedModule === 'Select module...') {
                return;
            }

            const lectureName = lectureInput.value;
            const date = dateInput.value;

            addLectureToTrainingsSection(lectureName, date, selectedModule);
        } else if(ev.target.tagName === 'BUTTON' && ev.target.textContent === 'Del'){
            const li = ev.target.parentNode;
            const lis = Array.from(li.parentNode.children);

            if(lis.length === 1) {
                li.parentNode.parentNode.remove();
            } else {
                li.remove();
            }
        }
    }

    function addLectureToTrainingsSection(lectureName, datetime, selectedModule) {
        const h3s = Array.from(modulesDiv.getElementsByTagName('h3'));
        let parentDiv = undefined;

        for (let currH3 of h3s) {
            if (currH3.textContent === `${selectedModule.toString().toUpperCase()}-MODULE`) {
                parentDiv = currH3.parentNode;
            }
        }

        if (parentDiv !== undefined) {
            const ul = parentDiv.children[1];

            const date = new Date(datetime);
            const li = createLiElement(date, lectureName);
            ul.appendChild(li);

            let allLiElements = Array.from(ul.querySelectorAll('li'));
            let sortedLiElements = allLiElements.sort((a, b) => (`${a.innerText.split(' - ')[1]} - ${a.innerText.split(' - ')[2]}`).localeCompare(`${b.innerText.split(' - ')[1]} - ${b.innerText.split(' - ')[2]}`));

            while (ul.firstChild) {
                ul.firstChild.remove();
            }

            for (const element of sortedLiElements) {
                ul.appendChild(element);
            }
        } else {
            const date = new Date(datetime);
            const li = createLiElement(date, lectureName);
            const ul = createElement('ul', li);
            const h3 = createElement('h3', `${selectedModule.toString().toUpperCase()}-MODULE`);
            const div = createElement('div', h3, ul);
            div.classList.add('module');
            modulesDiv.appendChild(div);
        }
    }

    function createLiElement(date, lectureName) {
        // TODO: check how to take DOM
        const datestring = `${lectureName} - ` + date.getFullYear().toString().padStart(4, '0') + "/"
            + (date.getMonth() + 1).toString().padStart(2, '0') + "/" + date.getDate().toString().padStart(2, '0') + " - " +
            date.getHours().toString().padStart(2, '0') + ":" + date.getMinutes().toString().padStart(2, '0');
        const h4 = createElement('h4', datestring);
        const delButton = createElement('button', 'Del');
        delButton.classList.add('red');
        const li = createElement('li', h4, delButton);
        li.classList.add('flex');
        return li;
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
};