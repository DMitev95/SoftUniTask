function hashtagWords(text) {
  specialWordsArr = [];
  for (let word of text.split(" ")) {
    if (word.startsWith("#") && word.length > 1) {
      word = word.substring(1);
      if (/^[a-zA-Z]+$/.test(word)) {
        specialWordsArr.push(word);
      }
    }
  }
  console.log(specialWordsArr.join("\n"));
}

hashtagWords("Nowadays everyone uses # to tag a #special word in #socialMedia");
