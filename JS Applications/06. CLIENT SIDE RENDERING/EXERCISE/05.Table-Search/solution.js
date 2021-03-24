import { html, render } from '../node_modules/lit-html/lit-html.js';

const rowTemplate = (student, select) => html`
<tr class=${select ? 'select' : ''}>
   <td>${student.firstName} ${student.lastName}</td>
   <td>${student.email}</td>
   <td>${student.course}</td>
</tr>`;

const tbody = document.querySelector('tbody');

start();

async function start() {
   document.querySelector('#searchBtn').addEventListener('click', () => onClick(list));

   const response = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await response.json();
   const list = Object.values(data);

   update(list);
}

function onClick(list) {
   const matchFIeld = document.getElementById('searchField');
   update(list, matchFIeld.value.toLowerCase());
   matchFIeld.value = '';
}

function update(list, match = '') {
   const result = list.map(x => rowTemplate(x, compare(x, match)));
   render(result, tbody);
}

function compare(item, match) {
   const itExist =  Object.values(item).some(x => match && x.toLowerCase().includes(match));
   return itExist;
}