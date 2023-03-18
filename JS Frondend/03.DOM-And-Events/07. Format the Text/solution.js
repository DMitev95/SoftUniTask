function solve() {
  const output = document.getElementById("output");
  const textArea = document.getElementById("input");
  let sentences = textArea.value.split(".");
  sentences.pop();

  while (sentences.length > 0) {
    let paragrapthSentences = sentences.splice(0, 3).map((p) => p.trimStart());
    const newParagraph = document.createElement("p");
    newParagraph.textContent = paragrapthSentences.join(".") + ".";
    output.appendChild(newParagraph);
  }
}
