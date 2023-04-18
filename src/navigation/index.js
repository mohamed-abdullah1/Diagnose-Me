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
//component for MainNavigator to check if user is logged in or not
const MainNavigator = () => {
    const user = useSelector(selectUser);
    return (
        <NavigationContainer>
            {/* {user ? (
                user.isDoctor ? (
                    <AppDocNavigator />
                ) : (
                    <AppNavigator />
                )
            ) : (
                <AccountNavigator />
            )} */}
            {user ? (
                user.fullName === "Doctor " ? (
                    <AppDocNavigator />
                ) : (
                    <AppNavigator />
                )
            ) : (
                <AccountNavigator />
            )}
        </NavigationContainer>
    );
};

export default MainNavigator;
