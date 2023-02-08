import {Heroe} from "./Heroe";

let heroes: Heroe[] = [
    {
        id: 1,
        name: "Chapulin colorado",
        poderes: ["chapulin colorado", "empatia"],
        especie: "humano",
        poder: 1
    },
    {
        id: 2,
        name: "Saitama",
        poderes: ["Saitama", "Calvo"],
        especie: "Humano",
        poder: 999999999999999
    },
    {
        id: 3,
        name: "Goku",
        poderes: ["Super saiyan", "Super saiyan 2", "Super saiyan 3", "Super saiyan 4", "Super saiyan God", "Super saiyan God Super Saiyan"],
        especie: "Saiyan",
        poder: 999999999999999
    }
]

function sortHeroByStrength(a: Heroe, b: Heroe) {
    return a.poder - b.poderes
}

heroes.sort(sortHeroByStrength);
heroes.filter((hero: Heroe) => hero.poder > 5).map((hero: Heroe) => {
    let {name, poder, especie} = hero;
    console.log(`El heroe ${name} tiene una fuerza de ${poder} y su especie es ${especie}`)

})