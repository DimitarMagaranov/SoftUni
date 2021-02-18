function solve() {
  const textWords = document.getElementById('text').value;
  const namingConvention = document.getElementById('naming-convention').value;
  const resultField = document.getElementById('result');

  let result = '';

  if(namingConvention === 'Camel Case') {
    result = convertToCamelCase(textWords);
  } else if(namingConvention === 'Pascal Case') {
    result = convertToPascalCase(textWords);
  } else {
    result = 'Error!';
  }

  resultField.textContent = result;

  function convertToCamelCase(input) {
    const words = input.split(' ');
    let result = words[0].toLowerCase();
  
    for (let i = 1; i < words.length; i++) {
      let currWord = words[i];
      result += currWord[0].toUpperCase() + words[i].slice(1).toLowerCase();
    }
  
    return result;
  }
  
  function convertToPascalCase(input) {
    let result = '';
    const words = input.split(' ');
    for (let i = 0; i < words.length; i++) {
      let currWord = words[i];
      result += currWord[0].toUpperCase() + words[i].slice(1).toLowerCase();
    }
  
    return result;
  }
}