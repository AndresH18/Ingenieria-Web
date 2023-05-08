import {createSlice, PayloadAction} from "@reduxjs/toolkit"
import {AppThunk} from "../store"

/**
 * Estado de autenticacion
 */
interface AuthState {
    isAuth: boolean,
    isLoading: boolean,
    error: string | null,
    token: string | null,
    email: string | null
}

const initialState: AuthState = {
    email: null,
    error: null,
    isAuth: false,
    token: null,
    isLoading: false

}

const authSlice = createSlice({
    name: "auth",
    initialState,
    reducers: {
        checkingAuth: (state) => {
            state.isLoading = true
        },
        completedAuth: (state, action: PayloadAction<{ isAuth: true }>) => {
            state.isAuth = action.payload.isAuth
            state.isLoading = false
        },
        errorAuth: (state) => {
            state.isAuth = false
            state.error = "Error during Authentication"
        },
        loginStart: (state) => {
            state.isLoading = true

        },
        loginSuccess: (state, action: PayloadAction<AuthState>) => {
            state.isLoading = false
            state.isAuth = true
            state.email = action.payload.email
            state.token = action.payload.token
            state.error = null
        },
        loginError: (state, action: PayloadAction<string>) => {
            state.isLoading = false
            state.isAuth = false
            state.error = action.payload
        },
        logout: (state) => {
            state.isAuth = false
            state.error = null
            state.token = null
            state.email = null
        }
    }
})

export const {
    checkingAuth,
    CompletedAuth,
    errorAuth,
    loginAuth,
    loginStart,
    loginSuccess,
    loginError,
    logout
} = authSlice.actions

export default authSlice.reducer

export const login = (username: string, password: string): AppThunk => async (dispatch) => {
    try {
        dispatch(loginStart())
        const response = await fetch("http://localhost:3002/auth/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({email: username, password})
        })
        const data = await response.json()
        if (data.token) {
            const payload: AuthState = {
                email: username,
                error: null,
                isAuth: true,
                isLoading: false,
                token: data.token

            }
            dispatch(loginSuccess(payload))
            localStorage.setItem("IsAuth", JSON.stringify(payload))
        }
        else {
            dispatch(loginError("Error en las credenciales"))
        }
    } catch (error) {
        dispatch(errorAuth("Error, no se pudo conectar"))
    }
}