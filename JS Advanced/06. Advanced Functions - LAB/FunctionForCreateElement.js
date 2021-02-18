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