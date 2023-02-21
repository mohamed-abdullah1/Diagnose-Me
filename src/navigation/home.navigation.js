import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
// import { createStackNavigator } from "@react-navigation/stack";
import Doctor from "../features/doctor/screens/Doctor.screen";
import Home from "../features/home/screens/Home.screen";

const HomeTab = createBottomTabNavigator();

const HomeNavigation = () => {
    return (
        <HomeTab.Navigator
            screenOptions={{
                headerShown: false,
                tabBarStyle: {
                    display: "none",
                },
            }}
        >
            <HomeTab.Screen name="Feed" component={Home} />
            <HomeTab.Screen name="DoctorDetails" component={Doctor} />
        </HomeTab.Navigator>
    );
};
export default HomeNavigation;
