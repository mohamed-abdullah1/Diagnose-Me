import { createBottomTabNavigator } from "@react-navigation/bottom-tabs";
import { createStackNavigator } from "@react-navigation/stack";
import AiServices from "../features/aiServices/screens/AiServicesMain.screen";
import Blog from "../features/blog/screens/Blog.screen";
import BlogMain from "../features/blog/screens/BlogMain.screen";
import BloodDonationMain from "../features/bloodDonation/screens/BloodDonationMain.screen";

import Doctor from "../features/doctor/screens/Doctor.screen";
import Doctors from "../features/doctor/screens/Doctors.screen";
import MakeAppointment from "../features/doctor/screens/MakeAppointment.screen";
import MakeAppointmentNote from "../features/doctor/screens/MakeAppointmentNote.screen";
import ExercisesMain from "../features/exercises/screens/ExercisesMain.screen";
import Home from "../features/home/screens/Home.screen";
import Profile from "../features/home/screens/Profile.screen";
import CartMedicine from "../features/medicine/screens/CartMedicine.screen";
import MedicineItem from "../features/medicine/screens/MedicineItem.screen";
import MedicineMain from "../features/medicine/screens/MedicineMain.screen";
import HomeDoc from "../features/home/screens/HomeDoc.screen";

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
      <HomeTab.Screen name="Feed" component={HomeDoc} />
      <HomeTab.Screen name="Profile" component={Profile} />
      <HomeTab.Screen name="Blogs" component={BlogMain} />
      <HomeTab.Screen name="BlogPage" component={Blog} />
    </HomeTab.Navigator>
  );
};
export default HomeNavigation;
