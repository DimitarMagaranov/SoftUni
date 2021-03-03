function solve() {
   const siteContent = document.getElementsByClassName('site-content')[0];
   const authorInputField = document.getElementById('creator');
   const titleInputField = document.getElementById('title');
   const categoryInputField = document.getElementById('category');
   const contentInputField = document.getElementById('content');
   const postSection = document.getElementsByTagName('main')[0].children[0];
   const archiveSection = document.getElementsByClassName('archive-section')[0];

   siteContent.addEventListener('click', onclick);

   function onclick(ev) {
      if (ev.target.tagName === 'BUTTON') {
         if (ev.target.textContent === 'Create') {
            ev.preventDefault();

            if (authorInputField.value === '' || titleInputField.value === '' || categoryInputField.value === '' || contentInputField.value === '') {
               return;
            }

            const title = createElement('h1', titleInputField.value);
            const strongCategory = createElement('strong', categoryInputField.value);
            const category = createElement('p', 'Category:', strongCategory);
            const strongAuthor = createElement('strong', authorInputField.value);
            const name = createElement('p', 'Creator:', strongAuthor);
            const content = createElement('p', contentInputField.value);
            const deleteButton = createElement('button', 'Delete');
            deleteButton.classList.add('btn');
            deleteButton.classList.add('delete');
            const archiveButton = createElement('button', 'Archive');
            archiveButton.classList.add('btn');
            archiveButton.classList.add('archive');
            const div = createElement('div', deleteButton, archiveButton);
            div.classList.add('buttons');
            const article = createElement('article', title, category, name, content, div);
            postSection.appendChild(article);

            
         } else if (ev.target.textContent === 'Archive') {
            const element = ev.target.parentNode.parentNode;
            const title = element.children[0].textContent;
            const li = createElement('li', title);
            archiveSection.children[1].appendChild(li);
            sortArchiveSection();
            element.remove();
         } else if (ev.target.textContent === 'Delete') {
            const element = ev.target.parentNode.parentNode;
            element.remove();
         }
      }
   }

   function sortArchiveSection() {
      let allLiElements = Array.from(archiveSection.children[1].querySelectorAll('li'));
      let sortedLiElements = allLiElements.sort((a, b) => a.textContent.localeCompare(b.textContent));

      while (archiveSection.children[1].firstChild) {
         archiveSection.children[1].firstChild.remove();
      }

      for (const element of sortedLiElements) {
         archiveSection.children[1].appendChild(element);
      }
   }

   function clearInputFields() {
      authorInputField.value = '';
      titleInputField.value = '';
      categoryInputField.value = '';
      contentInputField.value = '';
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
}
