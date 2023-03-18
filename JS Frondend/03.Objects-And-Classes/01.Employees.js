function employees(input) {
  let all = input.reduce((obj, employee) => {
    obj[employee] = employee.length;
    return obj;
  }, {});
  for (const key in all) {
    console.log(`Name: ${key} -- Personal Number: ${key.length}`);
  }
}

employees([
  "Silas Butler",
  "Adnaan Buckley",
  "Juan Peterson",
  "Brendan Villarreal",
]);
