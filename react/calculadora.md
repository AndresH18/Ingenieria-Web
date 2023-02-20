Crear una calculadora que sume, reste, multiplique y divida.

```typescript jsx
import {useState} from 'react'

export const Calculadora = () => {
    enum Operacion {
        Suma,
        Resta,
        Multiplicacion,
        Division
    }

    const [num1, setNum1] = useState(0);
    const [num2, setNum2] = useState(0);
    const [result, setResult] = useState(0);
    const updateNum1 = (e: React.ChangeEvent<HTMLInputElement>) => setNum1(e.target.value);
    const updateNum2 = (e: React.ChangeEvent<HTMLInputElement>) => setNum2(e.target.value);

    const Operar = (op: Operacion) => {
        switch (op) {
            case Operacion.Suma:
                setResult(num1 + num2);
                break;
            case Operacion.Resta:
                setResult(num1 - num2)
                break;
            case Operacion.Multiplicacion:
                setResult(num1 * num2)
                break;
            case Operacion.Division:
                if (num2 != 0)
                    setResult(num1 / num2);
                break;
        }
    }

    return (
        <>
            <input type="number" value={num1} placeholder="Primer numero" onchange={updateNum1}/>
            <input type="number" value={num2} placeholder="Segundo Numero" onchange={updateNum2}/>

            <div>
                <button onclick={() => Operar(Operacion.Suma)}>Sumar</button>
                <button onclick={() => Operar(Operacion.Resta)}>Restar</button>
                <button onclick={() => Operar(Operacion.Multiplicacion)}>Multiplicar</button>
                <button onclick={() => Operar(Operacion.Dividir)}>Dividir</button>
            </div>

            <h1>{result}</h1>
        </>
    )
}
```