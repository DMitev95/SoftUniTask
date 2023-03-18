function dictionary(input) {
  let obj = {};
  for (const item of input) {
    let itemObj = JSON.parse(item);
    let arr = Object.entries(itemObj);
    for (const [term, definition] of arr) {
      obj[term] = definition;
    }
  }

  let array = Object.entries(obj);
  let sorted = array.sort((a, b) => a[0].localeCompare(b[0]));

  for (const [term, definition] of sorted) {
    console.log(`Term: ${term} => Definition: ${definition}`);
  }
}

dictionary([
  '{"Coffee":"A hot drink made from the roasted and ground seeds (coffee beans) of a tropical shrub."}',
  '{"Bus":"A large motor vehicle carrying passengers by road, typically one serving the public on a fixed route and for a fare."}',
  '{"Boiler":"A fuel-burning apparatus or container for heating water."}',
  '{"Tape":"A narrow strip of material, typically used to hold or fasten something."}',
  '{"Microphone":"An instrument for converting sound waves into electrical energy variations which may then be amplified, transmitted, or recorded."}',
]);
