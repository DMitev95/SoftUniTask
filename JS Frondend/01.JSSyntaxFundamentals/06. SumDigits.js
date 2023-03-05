function solve(number) {
  let sum = 0;
  let digits = number.toString().split("");
  for (let index = 0; index < digits.length; index++) {
    sum += parseInt(digits[index]);
  }
  console.log(sum);
}

solve(245678);
