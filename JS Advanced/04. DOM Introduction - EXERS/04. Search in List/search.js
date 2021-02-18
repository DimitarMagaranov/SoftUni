function search() {
   let towns = document.querySelectorAll('ul#towns li');
   let searchInputField = document.getElementById('searchText');
   let resultField = document.getElementById('result');
   let matches = [];

   for (let i = 0; i < towns.length; i++) {
      let currTown = towns[i];
      let currTownTextContent = currTown.textContent.toLowerCase();
      let inputFieldTextContent = searchInputField.value.toLowerCase();

      currTown.style.fontWeight = '';
      currTown.style.textDecoration = '';

      if (currTownTextContent.includes(inputFieldTextContent) && inputFieldTextContent !== '') {
         currTown.style.fontWeight = 'bold';
         currTown.style.textDecoration = 'underline';
         matches.push(currTown);
      }
   }

   searchInputField.value = '';
   resultField.textContent = `${matches.length} matches found`;
}
