import { NavigationContainer } from "@react-navigation/native";
import { useContext } from "react";
import { useSelector } from "react-redux";
import AuthContext from "../services/auth/auth.context";
import { selectUser } from "../services/slices/auth.slice";
import AccountNavigator from "./account.navigation";
import AppNavigator from "./app.navigation";
import AppDocNavigator from "./doctor/appDoc.navigation";

const Com = ({ name = "screen" }) => (
    <View style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
        <Text>{name}</Text>
    </View>
);

const MainNavigator = () => {
    const user = useSelector(selectUser);
    console.log("🔒", user);
    return (
        <NavigationContainer>
            {user ? (
                !user.isDoctor ? (
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
