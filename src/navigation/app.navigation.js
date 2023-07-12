import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import {
  Ionicons,
  Feather,
  MaterialCommunityIcons,
  Fontisto,
} from "@expo/vector-icons";
import colors from "../infrastructure/theme/colors";
import HomeNavigation from "./home.navigation";
import ChatNavigation from "./chat.navigation";
import * as React from "react";
import ScheduleMain from "../features/schedule/screens/ScheduleMain.screen";
import { Badge } from "react-native-paper";
import { View } from "react-native";
import QuestionNavigator from "./question.navigation";
import { useSelector } from "react-redux";
import { selectChat } from "../services/slices/chat.slice";
import { useEffect } from "react";

const Wrapper = ({ badgeNumber, children }) => {
  return (
    <View>
      <Badge
        style={{
          backgroundColor: colors.secondary,
          position: "absolute",
          top: -8,
          right: -10,
          zIndex: 1000,
          borderColor: colors.light,
          borderWidth: 2,
        }}
        visible={badgeNumber > 0}
        // size=}
      >
        {badgeNumber}
      </Badge>
      {children}
    </View>
  );
};

const icons = {
  Home: {
    inactive: <Feather name="home" size={24} color={"#c4c4cc"} />,
    focused: <Feather name="home" size={24} color={colors.secondary} />,
  },
  Medicine: {
    inactive: (
      <MaterialCommunityIcons name="pill" size={24} color={"#c4c4cc"} />
    ),
    focused: <Fontisto name="pills" size={24} color={colors.secondary} />,
  },
  Messages: {
    inactive: (
      <Ionicons name="chatbubbles-outline" size={24} color={"#c4c4cc"} />
    ),
    focused: <Ionicons name="chatbubbles" size={24} color={colors.secondary} />,
  },
  Schedule: {
    inactive: <Ionicons name="calendar-outline" size={24} color={"#c4c4cc"} />,
    focused: <Ionicons name="calendar" size={24} color={colors.secondary} />,
  },
  Questions: {
    inactive: <Ionicons name="earth" size={24} color={"#c4c4cc"} />,
    focused: <Ionicons name="earth" size={24} color={colors.secondary} />,
  },
};
const badgeNumbers = {
  Home: 0,
  Messages: 3,
  Schedule: 5,
  Questions: 1,
};
const { Navigator, Screen } = createBottomTabNavigator();
const AppNavigator = () => {
  const chatsInfo = useSelector(selectChat);
  useEffect(() => {
    badgeNumbers.Messages = chatsInfo.numOfChats;
  }, []);
  return (
    <Navigator
      screenOptions={({ route }) => ({
        tabBarIcon: ({ focused, color, size }) => {
          const e = focused
            ? icons[route.name].focused
            : icons[route.name].inactive;
          return <Wrapper badgeNumber={badgeNumbers[route.name]}>{e}</Wrapper>;
        },
        tabBarActiveTintColor: colors.secondary,
        tabBarInactiveTintColor: "#b0b3bf",
        headerShown: false,
        tabBarStyle: {
          backgroundColor: colors.light,
          height: 58,
          alignItems: "center",
          paddingBottom: 0,
          paddingTop: 4,
        },

        tabBarLabelStyle: {
          fontSize: 12,
          fontFamily: "PoppinsBold",
        },
        tabBarHideOnKeyboard: true,
      })}
      initialRouteName="Home"
    >
      <Screen name="Home" component={HomeNavigation} />
      <Screen name="Messages" component={ChatNavigation} />
      <Screen name="Schedule" component={ScheduleMain} />
      <Screen name="Questions" component={QuestionNavigator} />
    </Navigator>
  );
};

export default AppNavigator;
