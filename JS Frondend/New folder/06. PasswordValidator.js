function passWordValidator(passWord) {
  const isValidLenght = (pass) => pass.length >= 6 && pass.length <= 10;
  const hasOnlyLettersAndDigits = (pass) => /^[A-Za-z0-9]+$/g.test(pass);
  const hasAtleastTwoDigits = (pass) => [...pass.matchAll(/\d/g)].length >= 2;

  let passIsvalid = true;

  if (!isValidLenght(passWord)) {
    console.log("Password must be between 6 and 10 characters");
    passIsvalid = false;
  }

  if (!hasOnlyLettersAndDigits(passWord)) {
    console.log("Password must consist only of letters and digits");
    passIsvalid = false;
  }

  if (!hasAtleastTwoDigits(passWord)) {
    console.log("Password must have at least 2 digits");
    passIsvalid = false;
  }

  if (passIsvalid) {
    console.log("Password is valid");
  }
}

passWordValidator("MyPass123");
