function solve(number) {
  let output = "";
  for (let index = 1; index <= 10; index++) {
    if (index === 10) output += `${number} X ${index} = ${number * index}`;
    else output += `${number} X ${index} = ${number * index}` + "\n";
  }
  console.log(output);
}

solve(5);
