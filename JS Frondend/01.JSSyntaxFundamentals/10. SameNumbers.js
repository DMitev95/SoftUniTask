function solve(number) {
  let digits = number.toString();
  let digit = digits[0];
  let trueOrFalse = true;
  let sum = 0;

  for (let index = 0; index < digits.length; index++) {
    if (digits[index] !== digit) {
      trueOrFalse = false;
    }
    sum += parseInt(digits[index]);
  }

  console.log(trueOrFalse);
  console.log(sum);
}

solve(2222222);
