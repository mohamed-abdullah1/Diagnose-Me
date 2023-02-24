import { createStackNavigator } from "@react-navigation/stack";
import Chat from "../features/chat/screens/Chat.screen";
import MainChat from "../features/chat/screens/MainChat.screen";

const ChatStack = createStackNavigator();

const ChatNavigation = () => {
    return (
        <ChatStack.Navigator screenOptions={{ headerShown: false }}>
            <ChatStack.Screen name="MainChat" component={MainChat} />
            <ChatStack.Screen name="Chat" component={Chat} />
        </ChatStack.Navigator>
    );
};
export default ChatNavigation;
