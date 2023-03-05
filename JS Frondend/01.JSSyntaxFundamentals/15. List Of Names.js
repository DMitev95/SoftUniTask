function solve(array) {
  array.sort((name1, name2) =>
    name1.toLowerCase().localeCompare(name2.toLowerCase())
  );
  let count = 0;
  for (let index = 0; index < array.length; index++) {
    console.log(++count + "." + array[index]);
  }
}

solve(["John", "Bob", "Christina", "Ema"]);
