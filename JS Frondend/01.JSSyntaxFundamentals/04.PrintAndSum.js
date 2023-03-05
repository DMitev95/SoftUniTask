function solve(num1, num2) {
  let sum = 0;
  let result = "";
  for (let index = num1; index <= num2; index++) {
    if (index === num2) {
      result += index;
    } else {
      result += index + " ";
    }
    sum += index;
  }
  console.log(result);
  console.log(`Sum: ${sum}`);
}

solve(5, 10);
