function movies(input) {
  let allMovies = [];
  for (const element of input) {
    let parts = element.split(" ");
    let director;
    let date;
    if (parts[0] === "addMovie") {
      movieName = parts.slice(1).join(" ");
      let obj = {};
      obj.name = movieName;
      allMovies.push(obj);
    } else if (parts.includes("directedBy")) {
      let index = parts.indexOf("directedBy");
      movieName = parts.slice(0, index).join(" ");
      director = parts.slice(index + 1).join(" ");
      let movie = allMovies.find((x) => x.name === movieName);
      if (movie) {
        movie.director = director;
      }
    } else if (parts.indexOf("onDate")) {
      let index = parts.indexOf("onDate");
      movieName = parts.slice(0, index).join(" ");
      date = parts.slice(index + 1).join(" ");
      let movie = allMovies.find((x) => x.name === movieName);
      if (movie) {
        movie.date = date;
      }
    }
  }
  for (const movie of allMovies) {
    if (
      movie.hasOwnProperty("name") &&
      movie.hasOwnProperty("director") &&
      movie.hasOwnProperty("date")
    ) {
      console.log(JSON.stringify(movie));
    }
  }
}

movies([
  "addMovie Fast and Furious",
  "addMovie Godfather",
  "Inception directedBy Christopher Nolan",
  "Godfather directedBy Francis Ford Coppola",
  "Godfather onDate 29.07.2018",
  "Fast and Furious onDate 30.07.2018",
  "Batman onDate 01.08.2018",
  "Fast and Furious directedBy Rob Cohen",
]);
