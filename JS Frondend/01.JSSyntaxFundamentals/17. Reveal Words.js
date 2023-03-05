function revealWords(words, text) {
  for (const word of words.split(", ")) {
    for (const item of text.split(" ")) {
      if (item === "*".repeat(item.length) && word.length === item.length) {
        text = text.replace(item, word);
      }
    }
  }
  console.log(text);
}

revealWords(
  "great",
  "softuni is ***** place for learning new programming languages"
);
