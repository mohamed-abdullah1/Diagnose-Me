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
import axios from "axios";
import { Text, View } from "react-native";
import WebView from "react-native-webview";
const HomeTab = createStackNavigator();

const HOST = "http://10.0.2.2:3000";

const BrainTreePaymentWebView = ({ onNonceRetrieved }) => {
  return (
    <View style={{ height: 450 }}>
      <Text style={{ fontSize: 30, fontWeight: "500" }}>
        BrainTree Payment Integration
      </Text>
      <WebView
        source={{ uri: `https://www.google.com` }}
        onMessage={(event) => {
          onNonceRetrieved(event.nativeEvent.data);
        }}
      />
    </View>
  );
};

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
      <HomeTab.Screen name="AI Services" component={AiServices} />
      <HomeTab.Screen name="Feed" component={Home} />
      <HomeTab.Screen name="DoctorDetails" component={Doctor} />
      <HomeTab.Screen name="MakeAppointment" component={MakeAppointment} />
      <HomeTab.Screen
        name="MakeAppointmentNote"
        component={MakeAppointmentNote}
      />
      <HomeTab.Screen name="Doctors" component={Doctors} />
      <HomeTab.Screen name="Blogs" component={BlogMain} />
      <HomeTab.Screen name="BlogPage" component={Blog} />
      <HomeTab.Screen name="Profile" component={Profile} />
      <HomeTab.Screen name="Medicine" component={MedicineMain} />
      <HomeTab.Screen name="MedicinePage" component={MedicineItem} />
      <HomeTab.Screen name="Cart" component={CartMedicine} />
      <HomeTab.Screen name="Blood Donation" component={BloodDonationMain} />
      <HomeTab.Screen
        name="Exercises"
        component={() => (
          <BrainTreePaymentWebView
            onNonceRetrieved={async (nonce) => {
              const response = await axios.post(
                `${HOST}/createPaymentTransaction`,
                {
                  amount: 10, //change to price gotten from your user
                  nonce: nonce,
                }
              );
              const { isPaymentSuccessful, errorText } = await response.data;
              console.log("xxxxxxx✅✅✅✅✅✅");
              Alert.alert(
                isPaymentSuccessful
                  ? "Payment successful"
                  : `Payment error - ${errorText}`
              );
            }}
          />
        )}
      />
    </HomeTab.Navigator>
  );
};
export default HomeNavigation;
