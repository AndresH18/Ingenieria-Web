# Middlewares

## Creating a Middleware

```typescript
import {NextFunction, Request, Response} from "express"

const middleware = (re:Request, res:Response, next:NextFunction) => {
    console.log("soy el middleware")
    // call to next allows the middleware to continue
    next()
}
```

## Adding Middleware to route
```typescript
import {NextFunction, Request, Response} from "express"
import {middleware} from "middlewares"


router.get('/', middleware, (req: Request, res: Response) => {
    // handle request
})
```