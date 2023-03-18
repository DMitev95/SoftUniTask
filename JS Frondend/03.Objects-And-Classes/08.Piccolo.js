function picollo(input) {
  let parkingLot = [];
  for (let index = 0; index < input.length; index++) {
    let command = input[index].split(", ")[0];
    let carNumber = input[index].split(", ")[1];
    if (command === "IN" && !parkingLot.includes(carNumber)) {
      parkingLot.push(carNumber);
    } else if (command === "OUT") {
      let carIndex = parkingLot.indexOf(carNumber);
      if (carIndex !== -1) {
        parkingLot.splice(carIndex, 1);
      }
    }
  }
  let sorted = parkingLot.sort((a, b) => a.localeCompare(b));
  if (sorted.length > 0) {
    sorted.forEach((x) => console.log(x));
  } else {
    console.log("Parking Lot is Empty");
  }
}

picollo([
  "IN, CA2844AA",
  "IN, CA1234TA",
  "OUT, CA2844AA",
  "IN, CA9999TT",
  "IN, CA2866HI",
  "OUT, CA1234TA",
  "IN, CA2844AA",
  "OUT, CA2866HI",
  "IN, CA9876HH",
  "IN, CA2822UU",
]);
