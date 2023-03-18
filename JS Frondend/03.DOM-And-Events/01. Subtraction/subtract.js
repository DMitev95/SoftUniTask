function subtract() {
  const firstNumber = Number(document.getElementById("firstNumber").value);
  const secondNumber = Number(document.getElementById("secondNumber").value);
  const newParagraph = document.createElement("p");
  const result = document.getElementById("result");
  const finalResult = firstNumber - secondNumber;
  newParagraph.textContent = finalResult;
  result.appendChild(newParagraph);
}
