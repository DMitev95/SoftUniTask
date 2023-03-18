function oddOccurrences(input) {
  let obj = {};
  let text = input.split(" ");
  for (const item of text) {
    let word = item.toLowerCase();
    if (!obj.hasOwnProperty(word)) {
      obj[word] = 0;
    }
    obj[word]++;
  }

  let objArray = Object.entries(obj).sort((a, b) => b[1] - a[1]);

  let output = [];
  for (const [word, count] of objArray) {
    if (count % 2 !== 0) {
      output.push(word);
    }
  }
  console.log(output.join(" "));
}

oddOccurrences("Java C# Php PHP Java PhP 3 C# 3 1 5 C#");
