function solve(array) {
  array.sort((a, b) => a - b);
  let newArray = [];
  let countBackwards = 1;
  for (let index = 0; index < array.length / 2; index++) {
    newArray.push(array[index]);
    newArray.push(array[array.length - countBackwards]);
    countBackwards++;
  }
  array.length % 2 === 0 ? newArray : newArray.pop();
  return newArray;
}

console.log(solve([1, 65, 3, 52, 48, 63, 31, -3, 18]));
