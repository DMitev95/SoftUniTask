function lockedProfile() {
  const buttons = Array.from(document.getElementsByTagName("button"));
  buttons.forEach((button) => {
    button.addEventListener("click", toggleInfo);
  });

  function toggleInfo(e) {
    const btn = this;
    const currProfile = btn.parentElement;
    const childern = Array.from(currProfile.children);
    const unlock = childern[4];
    const additionalInfo = childern[9];

    if (unlock.checked) {
      if (btn.textContent === "Show more") {
        additionalInfo.style.display = "block";
        btn.textContent = "Hide it";
      } else {
        additionalInfo.style.display = "none";
        btn.textContent = "Show more";
      }
    }
  }
}
