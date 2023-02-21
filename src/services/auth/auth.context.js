import { createContext, useState } from "react";

const AuthContext = createContext({
    user: null,
    loading: false,
    error: null,
    onLogin: () => null,
    onRegister: () => null,
});

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(true); //❎ make it object again
    //❎TODO: onLogin Edit it
    return (
        <AuthContext.Provider value={{ user }}>{children}</AuthContext.Provider>
    );
};
export default AuthContext;
