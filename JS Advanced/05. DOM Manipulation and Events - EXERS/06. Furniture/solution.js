function solve() {
  const textAreas = document.getElementsByTagName('textarea');
  const buttons = document.querySelectorAll('button');
  const tbody = document.querySelector('tbody');

  document.getElementsByTagName('body')[0].addEventListener('click', onclick);

  function onclick(ev) {
    if (ev.target.tagName !== 'BUTTON') {
      return;
    }

    if (ev.target.textContent === 'Generate') {
      const objects = JSON.parse(textAreas[0].value);

      for (let obj of objects) {
        const tr = document.createElement('tr');

        const imgTd = document.createElement('td');
        const img = document.createElement('img');
        img.setAttribute('src', obj.img);
        imgTd.appendChild(img);

        const nameTd = document.createElement('td');
        const nameParagraph = document.createElement('p');
        nameParagraph.textContent = obj.name;
        nameTd.appendChild(nameParagraph);

        const priceTd = document.createElement('td');
        const priceParagraph = document.createElement('p');
        priceParagraph.textContent = obj.price;
        priceTd.appendChild(priceParagraph);

        const decFactorTd = document.createElement('td');
        const decFactorParagraph = document.createElement('p');
        decFactorParagraph.textContent = obj.decFactor;
        decFactorTd.appendChild(decFactorParagraph);

        const checkboxTd = document.createElement('td');
        const input = document.createElement('input');
        input.setAttribute('type', 'checkbox');
        checkboxTd.appendChild(input);

        tr.appendChild(imgTd);
        tr.appendChild(nameTd);
        tr.appendChild(priceTd);
        tr.appendChild(decFactorTd);
        tr.appendChild(checkboxTd);

        tbody.appendChild(tr);
      }
    } else {
      const furnitures = Array.from(tbody.querySelectorAll('input[type=checkbox]:checked'))
        .map(x => x.parentNode.parentNode);

      const result = {
        bought: [],
        totalPrice: 0,
        decFactorSum: 0
      };

      for (let row of furnitures) {
        let cells = row.children;

        const name = cells[1].children[0].textContent;
        result.bought.push(name);

        const price = Number(cells[2].children[0].textContent);
        result.totalPrice += price;

        const decFactor = Number(cells[3].children[0].textContent);
        result.decFactorSum += decFactor;
      }

      textAreas[1].value = `Bought furniture: ${result.bought.join(', ')}\nTotal price: ${result.totalPrice.toFixed(2)}\nAverage decoration factor: ${result.decFactorSum / furnitures.length}`;
    }
  }
}