# React

Para crear aplicaciones en react se necesita `node`

## Crear App de React usando TypeScript

```ps
npx create-react-app <nombre-app> --template typescript
```

Otra opción es usar vite, el problema es que no crea muchas de las configuraciones iniciales del proyect

```ps
npm create vite@latest 
....
```

Seleccionar la opcion de react y typescript. Luego instalar las dependencias

```ps
npm i
```

## App

El archivo **app.tsx** contiene la entrada a la aplicación, *nunca borrar*.

Para correr la aplicación

```ps
npm run dev
```

Para crear un componente

```typescript jsx
export const Primero = () => {
    return (
        <div>Primero</div>
    )
}
```

Para usar un componente:

```typescript jsx
<Primero/>
```

Crear **clases** de react, *aunque ya no se usa casi*:

```typescript jsx
import React from "react"

export class Clase extends React.Component {
    render() {
        return (
            <>
                <h1>Soy una clase</h1>
            </>
        )
    }
}
```

Para combinar **HTML** con código, se usa *{nombre-variable}* dentro del html

```typescript jsx
let nombre: string;

<h1>Hola {nombre}</h1>
```

## Virtual DOM vs DOM

Cuando hay un cambio, el **Virtual DOM** cambia solo un pedazo de la página, mientras que el **DOM** recarga todo el
contenido de la página

## Extension del navegador para desarrollar
`React Dev Tools`