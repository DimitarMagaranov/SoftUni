function notify(message) {
  const div = document.getElementById('notification');
  div.textContent = message;
  div.style.display = 'block';

  div.addEventListener('click', (ev) => {
    if (ev.target.textContent === message) {
      div.style.display = 'none';
    }
  });
}