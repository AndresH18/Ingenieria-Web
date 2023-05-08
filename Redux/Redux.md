En el `App.tsx` estan unos componentes, el `Provider` es el componente principal de la aplicacion.
```tsx
function App() {
    return <>
        <Provider>
            <RouterApp/>
            
        </Provider>
        </>
}
```
## Crear un login middleware 
- Crear un archivo `/redux/store.ts`: este es el ambiente global de la aplicacion
- Crear un archivo `/redux/reducer/login.ts`
- crear el componente de login `/`