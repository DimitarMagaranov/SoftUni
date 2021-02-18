function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let rows = document.getElementsByTagName('tbody')[0].children;
      let searchField = document.getElementById('searchField');
      let searchFieldText = searchField.value.toLowerCase();

      for(let i = 0; i < rows.length; i++) {
         let currRow = rows[i];
         let tds = currRow.children;
         let rowTextContent = '';

         for(let j = 0; j < tds.length; j++) {
            rowTextContent += tds[j].textContent.toLowerCase();
         }

         currRow.classList.remove('select');

         if(searchFieldText != '' && rowTextContent.includes(searchFieldText)) {
            currRow.classList.add('select');
         }
      }

      searchField.value = '';
   }
}