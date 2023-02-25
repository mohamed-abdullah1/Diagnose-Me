import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createStackNavigator } from "@react-navigation/stack";

import Doctor from "../features/doctor/screens/Doctor.screen";
import Doctors from "../features/doctor/screens/Doctors.screen";
import MakeAppointment from "../features/doctor/screens/MakeAppointment.screen";
import MakeAppointmentNote from "../features/doctor/screens/MakeAppointmentNote.screen";
import Home from "../features/home/screens/Home.screen";

const HomeTab = createStackNavigator();

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
            <HomeTab.Screen
                name="MakeAppointment"
                component={MakeAppointment}
            />
            <HomeTab.Screen
                name="MakeAppointmentNote"
                component={MakeAppointmentNote}
            />
            <HomeTab.Screen name="Doctors" component={Doctors} />
        </HomeTab.Navigator>
    );
};
export default HomeNavigation;
