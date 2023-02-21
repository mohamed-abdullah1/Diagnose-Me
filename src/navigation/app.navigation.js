import { Text, View } from "react-native";
import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import {
    MaterialIcons,
    FontAwesome5,
    Entypo,
    AntDesign,
    Ionicons,
    FontAwesome,
    Feather,
    MaterialCommunityIcons,
    Fontisto,
} from "@expo/vector-icons";
import colors from "../infrastructure/theme/colors";
import Home from "../features/home/screens/Home.screen";
import HomeNavigation from "./home.navigation";
import { getFocusedRouteNameFromRoute } from "@react-navigation/native";

function HomeScreen() {
    return (
        <View
            style={{ flex: 1, alignItems: "center", justifyContent: "center" }}
        >
            <Text> Home Screen </Text>
        </View>
    );
}
function Setting() {
    return (
        <View
            style={{ flex: 1, alignItems: "center", justifyContent: "center" }}
        >
            <Text> Setting Screen </Text>
        </View>
    );
}
const icons = {
    Home: {
        inactive: <Feather name="home" size={24} color={colors.muted} />,
        focused: <Entypo name="home" size={24} color={colors.light} />,
    },
    Medicine: {
        inactive: (
            <MaterialCommunityIcons
                name="pill"
                size={24}
                color={colors.muted}
            />
        ),
        // (
        //     <MaterialIcons name="storefront" size={24} color={colors.light} />
        // ),
        focused: <Fontisto name="pills" size={24} color={colors.light} />,
    },
    Messages: {
        inactive: (
            <Ionicons
                name="chatbubbles-outline"
                size={24}
                color={colors.muted}
            />
        ),
        focused: <Ionicons name="chatbubbles" size={24} color={colors.light} />,
    },
    Schedule: {
        inactive: (
            <Ionicons name="calendar-outline" size={24} color={colors.muted} />
        ),
        focused: <Ionicons name="calendar" size={24} color={colors.light} />,
    },
    Questions: {
        inactive: (
            <FontAwesome
                name="question-circle-o"
                size={24}
                color={colors.muted}
            />
        ),
        focused: (
            <FontAwesome
                name="question-circle"
                size={24}
                color={colors.light}
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
                tabBarActiveTintColor: colors.light,
                tabBarInactiveTintColor: colors.focused,
                headerShown: false,
                tabBarStyle: {
                    backgroundColor: colors.secondary,
                    height: 55,
                    alignItems: "center",
                    // paddingBottom: 9,
                    // paddingTop: 9,
                    // borderTopLeftRadius: 32,
                    // borderTopRightRadius: 32,
                },
                tabBarLabelStyle: {
                    fontSize: 10,
                    fontFamily: "Poppins",
                },
            })}
            initialRouteName="Home"
        >
            <Screen name="Home" component={HomeNavigation} />
            <Screen name="Schedule" component={Setting} />
            <Screen name="Questions" component={Setting} />
            <Screen name="Messages" component={Setting} />
        </Navigator>
    );
};

export default AppNavigator;
