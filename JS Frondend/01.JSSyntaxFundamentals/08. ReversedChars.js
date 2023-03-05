function solve(firstChar, secondChar, thirdChar) {
  let result = thirdChar.concat(" " + secondChar + " ").concat(firstChar);
  console.log(result);
}

solve("A", "B", "C");
