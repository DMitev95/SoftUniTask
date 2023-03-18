function wordsTracker(input) {
  let words = input[0].split(" ");
  let text = input.splice(1);
  let obj = {};
  for (const word of words) {
    let wordOccurrence = text.filter((x) => x === word).length;
    obj[word] = wordOccurrence;
  }
  let sorted = Object.entries(obj).sort((a, b) => {
    let [_nameA, countA] = a;
    let [_nameB, countB] = b;
    return countB - countA;
  });

  for (const [key, value] of sorted) {
    console.log(`${key} - ${value}`);
  }
}

wordsTracker([
  "this sentence",
  "In",
  "this",
  "sentence",
  "you",
  "have",
  "to",
  "count",
  "the",
  "occurrences",
  "of",
  "the",
  "words",
  "this",
  "and",
  "sentence",
  "because",
  "this",
  "is",
  "your",
  "task",
]);
