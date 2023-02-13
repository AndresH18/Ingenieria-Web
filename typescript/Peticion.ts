import {axios} from "axios"
import {Producto} from "producto"

// promesas devuelven cierto tipo de dato
(async () => {
    async function getProductos() {
        const {data} = await axios.get<Producto>("https://api.escuelajs.co/api/v1/products")
        return data;
    }

    const productos = await getProductos();
    console.log(productos)
})()