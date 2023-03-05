function calculations(firstNum, secondNum, thirdNum) {
  const sum = (a, b) => a + b;
  const substract = (mySym, num) => mySym - num;

  return substract(sum(firstNum, secondNum), thirdNum);
}

console.log(calculations(1, 17, 30));
