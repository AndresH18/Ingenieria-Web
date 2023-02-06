// importar Estudiante
// constant
import {Estudiante} from "./estudiante";
import {Carro} from "./Carro";

const saludo = "Hello World";
// 'local' variable
let numero: number = 0;
let falso: boolean = true;
console.log(`${saludo}`)

let estudiante: Estudiante = {deportista: false, edad: 0, promedio: 0, nombre: "hol"}
let carro = new Carro(2023, "Mazda", 3_000)

// usando propiedades
let nuevoModelo = (carro.Modelo = 2024);

