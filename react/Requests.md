# Requests

## Create a new React App

```ps
npm create vite@latest 
```

Select `React` and select `TypeScript` as the language.

## Breaking Bad Api

The api that we are going to use is: [Breaking Bad Quotes Api](https://api.breakingbadquotes.xyz/v1/quotes)

Create a **Quote Object** that will represent a response from the api

### Create the Visual Components

```typescript
export interface Quote {
    quote: string,
    author: string
}
```

Create a component that will render the **Quote** object, import the interface. *File extension: .tsx*  
Lets call it *render.tsx*

```typescript jsx
import {Quote} from "../model/Quote"

interface Api {
    quote: Quote
}

export const Render = ({quote}: Api) => {
    return (
        <>
            <h2>{quote.author}</h2>
            <h2>{quote.quote}</h2>
        </>
    )
}
```

Create a component that will use the rendered.

```typescript jsx
import {Render} from "./render"
import {useState} from "react"
import {Quote} from "..model/Quote"

export const Mostrar = () => {
    const [quote, setQuote] = useState<Quote>({
        author: "Walter White",
        quote: "Mp es ima ETL"
    })

    return (
        <div>
            <Render quote={quote}/>
        </div>
    )
}
```

In **App.tsx**.

```typescript jsx
import {Mostrar} from "./components/Mostrar"

function App() {
    return (
        <>
            <div>
                <Mostrar/>
            </div>
        </>
    )
}
```

### Create the request

Inside **Mostrar.tsx**

```typescript jsx

import {useState, useEffect} from "react";

const cargar = async () => {
    const response = await fetch(
        "https://api.breakingbadquotes.xyz/v1/quotes"
    )
    console.log(response)
    const result = await response.json();
    const datos: Quote = result[0];
    setQuote(datos)
}

useEffect(() => {
    cargar()
}, [])

return (
    <div>
        <Render quote={quote}/>
        <button onclick={cargar}></button>
    </div>
)
```

### Exercise
Get A list of [NBA Players](https://mach-eight.uc.r.appspot.com/), use an input to filter the player by name
```typescript jsx
import {useState, useEffect} from "react"

// create response objects
// export interface Players {
//     values: Value[];
// }

export interface Player {
    first_name: string;
    h_in: string;
    h_meters: string;
    last_name: string;
}

// Create Player Component
const RenderPlayers = ({players}: Player[]) => {
    return (
        <>
            {
                players.map(p => {
                    <li>{p.first_name}</li>
                })
            }
        </>
    )
}

const Mostrar = () => {
    const [players, setPlayers] = useState<Player[]>([]);
    const [filteredPlayers, setFilteredPlayers] = useState<Players>();
    const [name, setName] = useState("");

    const loadPlayers = async () => {
        const response = await fetch("https://mach-eight.uc.r.appspot.com/")
        console.log(response)
        const result = await response.json();
        const playersArray = result.values.toArray();
        setPlayers(playersArray);
        setFilteredPlayers(playersArray)
    }

    const filter = () => {
        if (name.length == 0) {
            setFilteredPlayers(players)
        } else {
            setFilteredPlayers(players.filter(p=> p.first_name.concat(p.last_name).includes(name)))
        }
    }

    return (
        <div>
            <RenderPlayers players={filteredPlayers}/>
            <div>
                <input type="text" value={name} onchange={(e) => setName(e.target.value)}/>
                <button onclick={() => filter()}></button>
            </div>
        </div>
    )
}
```
