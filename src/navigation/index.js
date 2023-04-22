import { NavigationContainer } from "@react-navigation/native";
import { useDispatch, useSelector } from "react-redux";
import { selectUser } from "../services/slices/auth.slice";
import AccountNavigator from "./account.navigation";
import AppNavigator from "./app.navigation";
import AppDocNavigator from "./doctor/appDoc.navigation";
import { useGetChatsQuery } from "../services/apis/chat.api";
import { selectChat } from "../services/slices/chat.slice";
import { useEffect } from "react";
import { setNumOfChats } from "../services/slices/chat.slice";

const Com = ({ name = "screen" }) => (
    <View style={{ flex: 1, justifyContent: "center", alignItems: "center" }}>
        <Text>{name}</Text>
    </View>
);
//component for MainNavigator to check if user is logged in or not
const MainNavigator = () => {
    const user = useSelector(selectUser);
    const chatInfo = useSelector(selectChat);
    const dispatch = useDispatch();
    const {
        data: chats,
        error: chatsError,
        isSuccess: chatsIsSuccess,
    } = useGetChatsQuery(chatInfo.token);
    useEffect(() => {
        if (chatsIsSuccess) {
            console.log("👉🗣️", chats);
            dispatch(setNumOfChats(chats.length));
        }
    }, [chatsIsSuccess]);
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
