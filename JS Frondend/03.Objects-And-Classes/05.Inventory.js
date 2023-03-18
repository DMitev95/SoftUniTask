function inventory(input) {
  let allHeroes = [];
  for (const element of input) {
    let parts = element.split(" / ");
    let heroName = parts.shift();
    let heroLevel = Number(parts.shift());
    let heroItems = parts;
    allHeroes.push({ heroName, heroLevel, heroItems });
  }
  let sortedHeroes = allHeroes.sort((a, b) => a.heroLevel - b.heroLevel);
  for (const { heroName, heroLevel, heroItems } of sortedHeroes) {
    console.log(
      `Hero: ${heroName}\nlevel => ${heroLevel}\nitems => ${heroItems}`
    );
  }
}

inventory([
  "Isacc / 25 / Apple, GravityGun",
  "Derek / 12 / BarrelVest, DestructionSword",
  "Hes / 1 / Desolator, Sentinel, Antara",
]);
