function loading(number) {
  let chars = number / 10;
  let leftChars = 10 - chars;
  const charToRepeat = "%";
  const leftChats = ".";

  if (number === 100) {
    console.log("100% Complete!");
    console.log(
      `[${charToRepeat.repeat(chars)}${leftChats.repeat(leftChars)}]`
    );
  } else {
    console.log(
      `${number}% [${charToRepeat.repeat(chars)}${leftChats.repeat(leftChars)}]`
    );
    console.log("Still loading...");
  }
}

loading(100);
