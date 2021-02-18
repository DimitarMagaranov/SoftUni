function editElement(el, match, replacer) {
    const matcher = new RegExp(match, 'g');
    el.textContent = el.textContent.replace(matcher, replacer);
}