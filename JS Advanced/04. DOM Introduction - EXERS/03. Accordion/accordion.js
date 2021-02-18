function toggle() {
    let text = document.getElementById('extra');
    let button = document.getElementsByClassName('button')[0];

    let buttonTextValue = button.textContent.toLowerCase();

    if(buttonTextValue === 'more') {
        button.textContent = 'Less';
        text.style.display = 'block';
    } else if (buttonTextValue === 'less') {
        button.textContent = 'More';
        text.style.display = 'none';
    }
}