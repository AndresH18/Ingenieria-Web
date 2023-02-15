# Estados

```typescript jsx
import {useState} from 'react'

export const Estado = () => {
    let valor = 10;
    const add = () => valor++;
    return (
        <>
            <h1>{valor}</h1>
            <button onclick={add}>+1</button>
        </>
    )
}
```

Esto no funciona porque el valor se lee una sola vez, entonces cuando cambia no se vuelve a renderizar.  
Para que cambie cuando el valor cambie, se tienen que usar estados

```typescript jsx
import {useState} from 'react'

export const Estado = () => {
    const [valor, setValor] = useState(0);
    const add = (num: number = 1) => setValor(valor + num);
    const reset = () => setValor(0);
    return (
        <>
            <h1>{valor}</h1>
            <button onclick={() => add(1)}>+1</button>
            <button onclick={() => add(2)}>+2</button>
            <button onclick={reset}>reset</button>
        </>
    )
}
```

## Changing elements

```typescript jsx
import {useState} from 'react'

export const campoTexto = () => {
    const [nombre, setNombre] = useState("");
    const cambiarNombre = (e: React.ChangeEvent<HTMLInputElement>) => setNombre(e.target.value);
    return (
        <>
            <p>{nombre}</p>
            <input type="text"
                   placeholder="Ingrese su Nombre"
                   onchange={cambiarNombre}/>
        </>
    )
}
```

### Ejercicio

Hacer que cuando se presione el botón, se adicione el texto dentro de las comidas y se muestren en pantalla

```typescript jsx
import {useState} from 'react'

export const campoTexto = () => {
    const [nombre, setNombre] = useState<string>("");
    const [comida, setComida] = useState<string[]>(['tofu', 'extrovertida'])
    const cambiarNombre = (e: React.ChangeEvent<HTMLInputElement>) => setNombre(e.target.value);
    const addComida = (c: string) => {
        setComida(comida.push(c))
        setNombre('')
    }
    return (
        <>
            <p>{nombre}</p>
            <input type="text"
                   placeholder="Ingrese comida"
                   value={nombre}
                   onchange={cambiarNombre}/>
            <button onclick={() => addComida(nombre)}>Agregar</button>
            <ul>
                {comida.map((c, i) => <li key={i}>c</li>)}
            </ul>
        </>
    )
}
```