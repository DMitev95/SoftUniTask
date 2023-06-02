function attachEvents() {
  const phonebookContainer = document.getElementById("phonebook");
  const personInput = document.getElementById("person");
  const phoneInput = document.getElementById("phone");
  const createBtn = document.getElementById("btnCreate");
  const loadBtn = document.getElementById("btnLoad");
  const BASE_URL = "http://localhost:3030/jsonstore/phonebook/";

  loadBtn.addEventListener("click", loadPhoneBookHandler);
  createBtn.addEventListener("click", createPhoneBookHandler);

  async function loadPhoneBookHandler() {
    try {
      const phoneBookRes = await fetch(BASE_URL);
      const phonebookData = await phoneBookRes.json();
      const values = Object.values(phonebookData);
      phonebookContainer.innerHTML = "";
      for (const { phone, person, _id } of values) {
        const li = document.createElement("li");
        const button = document.createElement("button");
        button.textContent = "Delete";
        button.id = _id;
        button.addEventListener("click", deletePhoneBook);
        li.textContent = `${person}:${phone}`;
        li.appendChild(button);
        phonebookContainer.appendChild(li);
      }
    } catch (error) {
      console.log(error);
    }
  }

  function createPhoneBookHandler() {
    const person = personInput.value;
    const phone = phoneInput.value;
    const httpHeaders = {
      method: "POST",
      body: JSON.stringify({ person, phone }),
    };

    fetch(BASE_URL, httpHeaders)
      .then((res) => res.json())
      .then(() => {
        loadPhoneBookHandler();
        personInput.value = "";
        phoneInput.value = "";
      })
      .catch((err) => {
        console.log(err);
      });
  }

  async function deletePhoneBook() {
    const id = this.id;
    const httpHeader = {
      method: "DELETE",
    };

    fetch(`${BASE_URL}${id}`, httpHeader)
      .then((res) => res.json())
      .then(loadPhoneBookHandler)
      .catch((err) => console.log(err));
  }
}

attachEvents();
