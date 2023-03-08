import { NavigationContainer } from "@react-navigation/native";
import { useContext } from "react";
import AuthContext from "../services/auth/auth.context";
import AccountNavigator from "./account.navigation";
import AppNavigator from "./app.navigation";
import AppDocNavigator from "./doctor/appDoc.navigation";

const Com = ({ name = "screen" }) => (
    <View style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
        <Text>{name}</Text>
    </View>
);

const MainNavigator = () => {
    const { user } = useContext(AuthContext);
    console.log(user);
    return (
        <NavigationContainer>
            {user ? (
                user === "patient" ? (
                    <AppNavigator />
                ) : (
                    <AppDocNavigator />
                )
            ) : (
                <AccountNavigator />
            )}
        </NavigationContainer>
    );
};

export default MainNavigator;
