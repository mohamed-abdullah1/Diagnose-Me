import { createStackNavigator } from "@react-navigation/stack";

import AppDocNavigator from "./appDoc.navigation";
import RegistrationSpecialty from "../../features/account/screens/RegistrationSpecialty.screen";
import RegistrationHourPrice from "../../features/account/screens/RegistrationHourPrice.screen";
import RegistrationClinicLocation from "../../features/account/screens/RegistrationClinicLocation.screen";
import { useDispatch, useSelector } from "react-redux";
import {
  changeIsReg,
  changeWantToBeDoctor,
  selectIsReg,
} from "../../services/slices/registration.slice";
import { Button } from "react-native-paper";
import { Text } from "react-native";
import { View } from "react-native";
import { useVerifyDoctorMutation } from "../../services/apis/auth.api";
import { useEffect } from "react";
import {
  login,
  selectToken,
  setUserInfo,
} from "../../services/slices/auth.slice";
import colors from "../../infrastructure/theme/colors";
import { BgContainer } from "../../features/home/styles/Global.styles";
import { useRef } from "react";
import { Platform } from "react-native";
import * as Device from "expo-device";
import * as Notifications from "expo-notifications";

const AnotherNavigator = createStackNavigator();
const Verify = ({ navigation }) => {
  const token = useSelector(selectToken);
  const [verify, { data, isSuccess, isLoading }] = useVerifyDoctorMutation();
  const dispatch = useDispatch();
  const handlePress = () => {
    verify({ token });
  };
  useEffect(() => {
    // dispatch(changeIsReg(false));
    // dispatch(changeWantToBeDoctor(false));
    if (isSuccess) {
      navigation.navigate("RegistrationSpecialty");
      dispatch(login({ token: data?.token }));
    }
  }, [isSuccess]);
  return (
    <BgContainer>
      <Text>Verified</Text>
      <Button
        loading={isLoading}
        disabled={isLoading}
        onPress={handlePress}
        mode="contained"
        buttonColor={colors.secondary}
        style={{ width: "50%", alignSelf: "center" }}
      >
        Next
      </Button>
    </BgContainer>
  );
};

Notifications.setNotificationHandler({
  handleNotification: async () => ({
    shouldShowAlert: true,
    shouldPlaySound: true,
    shouldSetBadge: true,
  }),
});

// Can use this function below OR use Expo's Push Notification Tool from: https://expo.dev/notifications
async function sendPushNotification(expoPushToken) {
  const message = {
    to: expoPushToken,
    sound: "default",
    title: "Original Title",
    body: "And here is the body!",
    data: { someData: "goes here" },
  };

  await fetch("https://exp.host/--/api/v2/push/send", {
    method: "POST",
    headers: {
      Accept: "application/json",
      "Accept-encoding": "gzip, deflate",
      "Content-Type": "application/json",
    },
    body: JSON.stringify(message),
  });
}

async function registerForPushNotificationsAsync() {
  let token;
  if (Device.isDevice) {
    const { status: existingStatus } =
      await Notifications.getPermissionsAsync();
    let finalStatus = existingStatus;
    if (existingStatus !== "granted") {
      const { status } = await Notifications.requestPermissionsAsync();
      finalStatus = status;
    }
    if (finalStatus !== "granted") {
      alert("Failed to get push token for push notification!");
      return;
    }
    token = (await Notifications.getExpoPushTokenAsync()).data;
    console.log(token);
  } else {
    alert("Must use physical device for Push Notifications");
  }

  if (Platform.OS === "android") {
    Notifications.setNotificationChannelAsync("default", {
      name: "default",
      importance: Notifications.AndroidImportance.MAX,
      vibrationPattern: [0, 250, 250, 250],
      lightColor: "#FF231F7C",
    });
  }

  return token;
}

const UpperDoc = () => {
  const isReg = useSelector(selectIsReg);
  const [expoPushToken, setExpoPushToken] = useState("");
  const [notification, setNotification] = useState(false);
  const notificationListener = useRef();
  const responseListener = useRef();

  useEffect(() => {
    registerForPushNotificationsAsync().then((token) =>
      setExpoPushToken(token)
    );

    notificationListener.current =
      Notifications.addNotificationReceivedListener((notification) => {
        setNotification(notification);
      });

    responseListener.current =
      Notifications.addNotificationResponseReceivedListener((response) => {
        console.log(response);
      });

    return () => {
      Notifications.removeNotificationSubscription(
        notificationListener.current
      );
      Notifications.removeNotificationSubscription(responseListener.current);
    };
  }, []);
  console.log(expoPushToken);
  return (
    <AnotherNavigator.Navigator
      screenOptions={{
        presentation: "modal",
        headerShown: false,
        // ...TransitionPresets.SlideFromRightIOS,
      }}
      initialRouteName={isReg ? "RegistrationDocVerify" : "main"}
    >
      <AnotherNavigator.Screen name="main" component={AppDocNavigator} />
      <AnotherNavigator.Screen
        name="RegistrationDocVerify"
        component={Verify} //TODO: build this component
      />
      <AnotherNavigator.Screen
        name="RegistrationSpecialty"
        component={RegistrationSpecialty}
      />
      <AnotherNavigator.Screen
        name="RegistrationClinicLocation"
        component={RegistrationClinicLocation}
      />
      <AnotherNavigator.Screen
        name="RegistrationHourPrice"
        component={RegistrationHourPrice}
      />
    </AnotherNavigator.Navigator>
  );
};
export default UpperDoc;
