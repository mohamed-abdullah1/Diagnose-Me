import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import {
    Ionicons,
    FontAwesome,
    Feather,
    MaterialCommunityIcons,
    Fontisto,
} from "@expo/vector-icons";
import colors from "../infrastructure/theme/colors";
import HomeNavigation from "./home.navigation";
import ChatNavigation from "./chat.navigation";
import * as React from "react";
import ScheduleMain from "../features/schedule/screens/ScheduleMain.screen";
import MainQuestions from "../features/questions/screens/MainQuestions.screen";

const icons = {
    Home: {
        inactive: <Feather name="home" size={24} color={"#c4c4cc"} />,
        focused: <Feather name="home" size={24} color={colors.secondary} />,
        // focused: (
        //     <MaterialCommunityIcons
        //         name="home-variant"
        //         size={24}
        //         color={colors.secondary}
        //     />
        // ),
    },
    Medicine: {
        inactive: (
            <MaterialCommunityIcons name="pill" size={24} color={"#c4c4cc"} />
        ),
        // (
        //     <MaterialIcons name="storefront" size={24} color={colors.light} />
        // ),
        focused: <Fontisto name="pills" size={24} color={colors.secondary} />,
    },
    Messages: {
        inactive: (
            <Ionicons name="chatbubbles-outline" size={24} color={"#c4c4cc"} />
        ),
        focused: (
            <Ionicons name="chatbubbles" size={24} color={colors.secondary} />
        ),
    },
    Schedule: {
        inactive: (
            <Ionicons name="calendar-outline" size={24} color={"#c4c4cc"} />
        ),
        focused: (
            <Ionicons name="calendar" size={24} color={colors.secondary} />
        ),
    },
    Questions: {
        inactive: (
            <FontAwesome name="question-circle-o" size={24} color={"#c4c4cc"} />
        ),
        focused: (
            <FontAwesome
                name="question-circle"
                size={24}
                color={colors.secondary}
            />
        ),
    },
};

const { Navigator, Screen } = createBottomTabNavigator();
const AppNavigator = () => {
    return (
        <Navigator
            screenOptions={({ route }) => ({
                tabBarIcon: ({ focused, color, size }) => {
                    return focused
                        ? icons[route.name].focused
                        : icons[route.name].inactive;
                },
                tabBarActiveTintColor: colors.secondary,
                tabBarInactiveTintColor: "#b0b3bf",
                headerShown: false,
                tabBarStyle: {
                    backgroundColor: colors.light,
                    height: 60,
                    alignItems: "center",
                    paddingBottom: 6,
                    paddingTop: 6,
                    shadowColor: "#000000",
                    elevation: 1,
                },
                tabBarLabelStyle: {
                    fontSize: 12,
                    fontFamily: "PoppinsBold",
                },
            })}
            initialRouteName="Home"
        >
            <Screen name="Home" component={HomeNavigation} />
            <Screen name="Messages" component={ChatNavigation} />
            <Screen name="Schedule" component={ScheduleMain} />
            <Screen name="Questions" component={MainQuestions} />
        </Navigator>
    );
};

export default AppNavigator;
