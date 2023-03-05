function PascalCaseSplitter(text) {
  let result = "";
  for (const letter of text) {
    let asciiCode = letter.charCodeAt(letter);
    if (asciiCode >= 65 && asciiCode <= 90) {
      if (result.length > 0) {
        result += ", ";
      }
      result += letter;
    } else {
      result += letter;
    }
  }
  console.log(result);
}

PascalCaseSplitter("SplitMeIfYouCanHaHaYouCantOrYouCan");
