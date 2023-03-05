function solve(fruit, kg, price) {
  console.log(
    `I need $${(kg * 0.001 * price).toFixed(2)} to buy ${(kg * 0.001).toFixed(
      2
    )} kilograms ${fruit}.`
  );
}

solve("orange", 2500, 1.8);
