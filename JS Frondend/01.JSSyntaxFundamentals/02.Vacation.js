function solve(groupNumber, groupType, weekday) {
  let totalPrice = 0;
  switch (weekday) {
    case "Friday":
      switch (groupType) {
        case "Students":
          totalPrice = groupNumber * 8.45;
          if (groupNumber >= 30) {
            totalPrice *= 0.85;
          }
          break;
        case "Business":
          totalPrice = groupNumber * 10.9;
          if (groupNumber >= 100) {
            totalPrice -= 10 * 10.9;
          }
          break;
        case "Regular":
          totalPrice = groupNumber * 15;
          if (groupNumber >= 10 && groupNumber <= 20) {
            totalPrice *= 0.95;
          }
          break;
      }
      break;
    case "Saturday":
      switch (groupType) {
        case "Students":
          totalPrice = groupNumber * 9.8;
          if (groupNumber >= 30) {
            totalPrice *= 0.85;
          }
          break;
        case "Business":
          totalPrice = groupNumber * 15.6;
          if (groupNumber >= 100) {
            totalPrice -= 10 * 15.6;
          }
          break;
        case "Regular":
          totalPrice = groupNumber * 20;
          if (groupNumber >= 10 && groupNumber <= 20) {
            totalPrice *= 0.95;
          }
          break;
      }
      break;
    case "Sunday":
      switch (groupType) {
        case "Students":
          totalPrice = groupNumber * 10.46;
          if (groupNumber >= 30) {
            totalPrice *= 0.85;
          }
          break;
        case "Business":
          totalPrice = groupNumber * 16;
          if (groupNumber >= 100) {
            totalPrice -= 10 * 16;
          }
          break;
        case "Regular":
          totalPrice = groupNumber * 22.5;
          if (groupNumber >= 10 && groupNumber <= 20) {
            totalPrice *= 0.95;
          }
          break;
      }
      break;
  }

  console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

solve(30, "Students", "Sunday");
solve(40, "Regular", "Saturday");
