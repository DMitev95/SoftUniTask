function palindromIntegers(numbers) {
  // numbers.forEach((num) => {
  //   console.log(isPalindrome(num));
  // });

  // function isPalindrome(num) {
  //   let reversed = Number([...num.toString()].reverse().join(""));

  //   return num === reversed;
  // }

  const isPalindrome = (num) =>
    Number([...num.toString()].reverse().join("")) === num;
  return numbers.map(isPalindrome).join("\n");
}

// palindromIntegers([123, 323, 421, 121]);

console.log(palindromIntegers([123, 323, 421, 121]));
