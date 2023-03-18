function storeProvision(arrayOne, arrayTwo) {
  let array = [...arrayOne, ...arrayTwo];
  let obj = {};
  for (let index = 0; index < array.length; index += 2) {
    if (!obj.hasOwnProperty(array[index])) {
      obj[array[index]] = 0;
    }
    obj[array[index]] += Number(array[index + 1]);
  }

  for (const key in obj) {
    console.log(`${key} -> ${obj[key]}`);
  }
}

storeProvision(
  ["Chips", "5", "CocaCola", "9", "Bananas", "14", "Pasta", "4", "Beer", "2"],
  ["Flour", "44", "Oil", "12", "Pasta", "7", "Tomatoes", "70", "Bananas", "30"]
);
