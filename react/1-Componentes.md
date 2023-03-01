# Componentes y comunicación entre Componentes

### PeliculaModel.tsx

```typescript jsx
export interface PeliculaModel {
    id: number,
    titulo: string,
    genero: string,
}
```

### Pelicula.tsx

```typescript jsx
import {PeliculaModel} from ".";
import {useState} from "react";

interface PeliculaProps {
    pelicula: PeliculaModel,
}

export const Pelicula = ({pelicula}: PeliculaProps) => {
    // destructuring
    const {id, titulo, genero} = pelicula;

    return (
        <>
            <h1>{id}</h1>
            <h2>{titulo}</h2>
            <h3>{genero}</h3>
        </>
    )
}
```

### PeliculaComponent.tsx
```typescript jsx
import {PeliculaModel} from "PeliculaModel"
import {useState} from "reaact"
import {Pelicula} from "Pelicula"

export const Peliculas = () => {
    const [peliculas, setPeliculas] = useState<PeliculaModel[]>([
        {
            id: 1,
            titulo: 'John Wick',
            genero: 'Accion'
        },
        {
            id: 2,
            titulo: 'Detective Pikachu',
            genero: 'Fantasia'
        },
        {
            id: 3,
            titulo: 'El Gato Con Botas',
            genero: 'Animation'
        }
    ])
    // const [pelicula, setPelicula] = useState<PeliculaModel>(peliculas[0]);

    return (
        // <Pelicula pelicula={pelicula}/>
        <>
            {
                peliculas.map(p => <Pelicula pelicula={p} key={p.id}/>
                )
            }
        </>
    )
}

```