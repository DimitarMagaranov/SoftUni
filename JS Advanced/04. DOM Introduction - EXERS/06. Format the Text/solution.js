function solve() {
  let textArea = document.getElementById('input');
  let divOutput = document.getElementById('output');

  const sentences = textArea.value.split('.');

  let paragraphsTextArray = [];
  let count = 0;
  let paragraphText = '';

  if(sentences.some(x => x)) {
    for (let i = 0; i < sentences.length; i++) {
      let currSentence = sentences[i].trim();
  
      if (currSentence.length > 0) {
        if (count < 3) {
          paragraphText += `${currSentence}.`;
          count++;
        } else {
          paragraphsTextArray.push(`<p> ${paragraphText.trim()} </p>`);
          paragraphText = '';
          count = 0;
          i--;
        }
      }
    }
  
    if (count > 0) {
      paragraphsTextArray.push(`<p> ${paragraphText.trim()} </p>`);
    }
  
    divOutput.innerHTML = paragraphsTextArray.join('\n');
  }
}