import LoginScreen from "../features/account/screens/Login.screen";
import {
    createNativeStackNavigator,
    // TransitionPresets,
} from "@react-navigation/native-stack";
import RegistrationMain from "../features/account/screens/RegistrationMain.screen";
import LoginMainScreen from "../features/account/screens/LoginMain.screen";
import RegistrationName from "../features/account/screens/RegistrationName.screen";
import RegistrationPassword from "../features/account/screens/RegistrationPassword.screen";
import RegistrationGender from "../features/account/screens/RegistrationGender.screen";
import RegistrationTypeOfAccount from "../features/account/screens/RegistrationTypeOfAccount.screen";
import RegistrationAge from "../features/account/screens/RegistrationAge.screen";
import RegistrationWeightHeight from "../features/account/screens/RegistrationWeightHeight.screen";
import RegistrationBloodType from "../features/account/screens/RegistrationBloodType.screen";
import RegistrationSpecialty from "../features/account/screens/RegistrationSpecialty.screen";
import RegistrationHourPrice from "../features/account/screens/RegistrationHourPrice.screen";
import RegistrationClinicLocation from "../features/account/screens/RegistrationClinicLocation.screen";
import RegistrationYearsOfExperience from "../features/account/screens/RegistrationYearsOfExperience.screen";

const Stack = createNativeStackNavigator();
const AccountNavigator = () => {
    return (
        <Stack.Navigator
            screenOptions={{
                presentation: "modal",
                headerShown: false,
                // ...TransitionPresets.SlideFromRightIOS,
            }}
        >
            <Stack.Screen name="LoginMain" component={LoginMainScreen} />
            <Stack.Screen name="Login" component={LoginScreen} />
            <Stack.Screen
                name="RegistrationMain"
                component={RegistrationMain}
            />
            <Stack.Screen
                name="RegistrationName"
                component={RegistrationName}
            />
            <Stack.Screen
                name="RegistrationPassword"
                component={RegistrationPassword}
            />
            <Stack.Screen
                name="RegistrationGender"
                component={RegistrationGender}
            />
            <Stack.Screen
                name="RegistrationTypeOfAccount"
                component={RegistrationTypeOfAccount}
            />
            <Stack.Screen name="RegistrationAge" component={RegistrationAge} />
            <Stack.Screen
                name="RegistrationWeightHeight"
                component={RegistrationWeightHeight}
            />
            <Stack.Screen
                name="RegistrationBloodType"
                component={RegistrationBloodType}
            />
            <Stack.Screen
                name="RegistrationSpecialty"
                component={RegistrationSpecialty}
            />
            <Stack.Screen
                name="RegistrationHourPrice"
                component={RegistrationHourPrice}
            />
            <Stack.Screen
                name="RegistrationClinicLocation"
                component={RegistrationClinicLocation}
            />
            <Stack.Screen
                name="RegistrationYearsOfExperience"
                component={RegistrationYearsOfExperience}
            />
        </Stack.Navigator>
    );
};
export default AccountNavigator;
