export class Carro {
    private modelo: number
    private marca: string
    private cilindraje: number

    constructor(modelo: number, marca: string, cilindraje: number) {
        this.modelo = modelo;
        this.marca = marca;
        this.cilindraje = cilindraje;
    }

    public get Model() {
        return this.modelo
    }

    public set Modelo(m: number) {
        this.modelo = m
    }
}