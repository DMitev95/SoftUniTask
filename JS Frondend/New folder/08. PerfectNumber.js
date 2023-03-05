function isPerfectNumber(number) {
  let divisors = [];
  for (let currNum = 1; currNum < number; currNum++) {
    if (number % currNum === 0) {
      divisors.push(currNum);
    }
  }

  let divisorsSum = divisors.reduce((previosValue, currentValue) => {
    return previosValue + currentValue;
  }, 0);

  if (divisorsSum === number) {
    console.log("We have a perfect number!");
  } else {
    console.log("It's not so perfect.");
  }
}

isPerfectNumber(6);
isPerfectNumber(28);
isPerfectNumber(1236498);
