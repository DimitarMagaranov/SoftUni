function extractText() {
    const items = document.querySelectorAll('ul#items li');

    const textArea = document.getElementById("result");

    for(let item of items) {
        textArea.value += item.textContent + '\n';
    }
}