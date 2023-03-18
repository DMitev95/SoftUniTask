function solve() {
  const searchInput = document.getElementById("searchField");
  document.querySelector("#searchBtn").addEventListener("click", onClick);

  function onClick() {
    const searchWord = searchInput.value;
    const tableRows = Array.from(document.querySelectorAll("tbody tr"));
    for (const row of tableRows) {
      let trimmedTextContent = row.textContent.trim();

      if (row.classList.contains("select")) {
        row.classList.remove("select");
      }

      if (trimmedTextContent.includes(searchWord)) {
        row.classList.add("select");
      }
    }

    searchInput = "";
  }
}
