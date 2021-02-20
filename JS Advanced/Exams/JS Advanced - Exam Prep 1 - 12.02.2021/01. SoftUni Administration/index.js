function solve() {
    const formControls = document.querySelectorAll('.form-control input');
    const lecture = formControls[0];
    const date = formControls[1];
    const moduleName = document.querySelector('select');

    document.querySelector('.container').addEventListener('click', (ev) => {
        if(ev.target.tagName !== 'BUTTON') {
            return;
        }

        if(ev.target.textContent === 'Del') {

        } else if (ev.target.textContent === 'Add') {
            ev.preventDefault();
            add();
        }
    })

    function add() {
        if(lecture.value === '' || date.value === '' || moduleName.value === 'Select module') {
            return;
        }

        const delButton = createElement('button', 'Del');
        delButton.classList.add('red');
        const lectureName = lecture.value;
        const dateString = date.value;
        const lectureTitle = `${lecture.value}`
        const h4 = createElement('h4', lectureTitle)
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