import {useState} from "react"
import {useDispatch, useSelector} from "react-redux"
import {RootState} from "../../redux/store";
import {login} from "../../redux/reducers/login";
import {ThunksDispatch} from "@reduxjs/toolkit"

export const Login = () => {
    const [username, setUsername] = useState("")
    const [password, setPassword] = useState("")
    const dispatch: ThunksDispatch<RootState, any, any> = useDispatch
    const error = useSelector((state: RootState) => state.auth.error)
    const handleSubmit = (event: React.FormEvent) => {
        event.preventDefault()
        dispatch(login(username, password))
        setUsername("")
        setPassword("")
    }
    return (
        <>
            <form onsubmit={handleSubmit}>
                <input type="text" value={username} onchange={(e) => setUsername(e.target.value)}
                       placeholder="Username"/>
                <input type="password" value={password} onchange={(e) => setPassword(e.target.value)}
                       placeholder="Password"/>
            </form>
        </>
    )
}