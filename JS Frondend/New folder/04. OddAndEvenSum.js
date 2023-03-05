function addEvenSum(number) {
  let digits = number.toString().split("");
  let realDigits = digits.map(Number);
  let oddSum = 0;
  let evenSum = 0;
  realDigits.forEach((element) => {
    if (element % 2 == 0) {
      evenSum += element;
    } else {
      oddSum += element;
    }
  });
  console.log(`Odd sum = ${oddSum}, Even sum = ${evenSum}`);
}

addEvenSum(1000435);
