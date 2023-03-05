function solve(speed, area) {
  let speedLimit = 0;
  let status = "";
  let output = "";
  switch (area) {
    case "motorway":
      speedLimit = 130;
      break;
    case "interstate":
      speedLimit = 90;
      break;
    case "city":
      speedLimit = 50;
      break;
    case "residential":
      speedLimit = 20;
      break;
  }

  let speedDifference = speed - speedLimit;
  if (speedDifference <= 0) {
    output = `Driving ${speed} km/h in a ${speedLimit} zone`;
  } else {
    if (speedDifference > 0 && speedDifference <= 20) status = "speeding";
    else if (speedDifference <= 40) status = "excessive speeding";
    else if (speedDifference > 40) status = "reckless driving";
    output = `The speed is ${speedDifference} km/h faster than the allowed speed of ${speedLimit} - ${status}`;
  }
  console.log(output);
}

solve(40, "city");
