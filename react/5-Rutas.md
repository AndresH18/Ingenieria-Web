# Rutas e Imagenes

Para usar imagenes locales, se necesita crear un archivo a nivel raiz.

`src/global.d.ts`
```typescript
declare module "*.module.css" {
    const classes: { [key: string]: string }
    export default classes
}
declare module "*.png"
declare module "*.svg"
declare module "*.gif"
```

Ya se pueden llamar imagenes dentro del codigo.
```typescript jsx
import imagen from "./img/nombre.extension"

const Mostrar = () => {
    return (
        <>
            <img src={imagen} />
        </>
    )
}
```