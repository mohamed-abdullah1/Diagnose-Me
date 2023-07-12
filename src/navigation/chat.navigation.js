import { createStackNavigator } from "@react-navigation/stack";
import Chat from "../features/chat/screens/Chat.screen";
import MainChat from "../features/chat/screens/MainChat.screen";
import VideoCall from "../features/chat/screens/VideoCall.screen";

const ChatStack = createStackNavigator();

const ChatNavigation = () => {
  return (
    <ChatStack.Navigator
      screenOptions={{ headerShown: false }}
      initialRouteName="MainChat"
    >
      <ChatStack.Screen name="MainChat" component={MainChat} />
      <ChatStack.Screen name="Chat" component={Chat} />
      <ChatStack.Screen name="VideoCall" component={VideoCall} />
    </ChatStack.Navigator>
  );
};
export default ChatNavigation;
