function addItem() {
    const textField = document.getElementById('newItemText');
    const valueField = document.getElementById('newItemValue');

    const textContent = textField.value;
    const value = valueField.value;

    const option = document.createElement('option');
    option.textContent = textContent;
    option.value = value;
    
    const dropdown = document.getElementById('menu');
    dropdown.appendChild(option);

    textField.value = '';
    valueField.value = '';
}