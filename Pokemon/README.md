# Pokemon Page

Pagina Web usando Asp.Net Core, que se conecta con la **API** de [Pokemon](https://pokeapi.co/). Utiliza los *wrappers* de [PokeApiNnet](https://github.com/mtrdp642/PokeApiNet) [![NuGet](https://img.shields.io/nuget/v/PokeApiNet.svg?logo=nuget)](https://www.nuget.org/packages/PokeApiNet).

## Librerias

### Libman
Revisrar que libman este instalado
```ps
>dotnet tool list --global

Package Id                            Version      Commands
-----------------------------------------------------------
microsoft.web.librarymanager.cli      2.1.175      libman
```

Instalar Libman
```ps
dotnet tool install --global Microsoft.Web.librarymManager.Cli --version 2.1.175
```

Navegar al Directorio de `./Pokemon`
```ps
cd .\Pokemon
```

Si no se encuentra el archivo **libman.json**, ejecuta inicializa libman e instala los siguientes paquete
```ps
libman init -p cdnjs
```

### [Bootstrap](https://getbootstrap.com/docs/5.2/getting-started/introduction/)
```
libman install bootstrap@5.2.3 -d wwwroot/lib/bootstrap
```

### [Font-Awesome](https://fontawesome.com/search?o=r&m=free)
```md
libman install font-awesome@6.2.1 -d wwwroot/lib/font-awesome
```

### Restaurar Paquetes
```ps
libman restore
```
