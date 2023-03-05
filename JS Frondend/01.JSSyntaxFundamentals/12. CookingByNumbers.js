function solve(number, ...operations) {
  number = parseInt(number);
  for (let index = 0; index < operations.length; index++) {
    switch (operations[index]) {
      case "chop":
        number = number / 2.0;
        break;
      case "dice":
        number = Math.sqrt(number);
        break;
      case "spice":
        number += 1;
        break;
      case "bake":
        number *= 3;
        break;
      case "fillet":
        number *= 0.8;
        break;
    }
    if (number.toString().includes(".")) console.log(number.toFixed(1));
    else console.log(number);
  }
}

solve("32", "chop", "chop", "chop", "chop", "chop");
