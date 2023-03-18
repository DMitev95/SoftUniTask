function towns(input) {
  let obj = {};
  for (const element of input) {
    let parts = element.split(" | ");
    obj.town = parts[0];
    obj.latitude = Number(parts[1]).toFixed(2);
    obj.longitude = Number(parts[2]).toFixed(2);
    console.log(obj);
  }
}

towns(["Sofia | 42.696552 | 23.32601", "Beijing | 39.913818 | 116.363625"]);
