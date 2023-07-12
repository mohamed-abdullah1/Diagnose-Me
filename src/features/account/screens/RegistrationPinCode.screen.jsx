import { useState } from "react";
import { Alert, Keyboard, View } from "react-native";
import Top from "../components/Top";
import { Background, Btn, Form, Reg, RegOption } from "../styles/Shared.styles";
import Input from "../../components/Input.component";
import { Text } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import {
  useConfirmMutation,
  useForgetPasswordMutation,
  useResendConfirmMutation,
  useVerifyMutation,
} from "../../../services/apis/auth.api";
import { useEffect } from "react";
import {
  changeIsReg,
  selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useDispatch, useSelector } from "react-redux";

const RegistrationPinCode = ({ navigation, route }) => {
  const [isKeyVisible, setIsKeyVisible] = useState(false);
  const [pinCode, setPinCode] = useState("");
  Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
  Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
  const registerUser = useSelector(selectRegisterUser);
  const dispatch = useDispatch();
  const [
    verify,
    {
      data: verifyResponse,
      isError: verifyIsError,
      isSuccess: verifyIsSuccess,
      isLoading: verifyIsLoading,
      error: verifyError,
    },
  ] = useVerifyMutation();
  const [
    confirm,
    {
      isError: confirmIsError,
      isSuccess: confirmIsSuccess,
      error: confirmError,
    },
  ] = useConfirmMutation();
  const [
    resend,
    {
      isLoading: isResendLoading,
      isSuccess: resendIsSuccess,
      isError: resendIsError,
      error: resendError,
    },
  ] = useResendConfirmMutation();
  const [
    forgetPassword,
    { isSuccess: forgetPasswordIsSuccess, isLoading: forgetPasswordIsLoading },
  ] = useForgetPasswordMutation();
  const proceedPressHandler = async () => {
    //navigate to the login screen
    //send the pin code to the verify endpoint
    //confirm endpoint
    //navigate to the login screen
    await verify({ pinCode: pinCode.trim() });
  };
  const resendPressHandler = () => {
    resend({ email: registerUser.email });
  };
  const resendForgetPasswordHandler = () => {
    forgetPassword({ email: route.params?.email });
  };
  useEffect(() => {
    if (confirmIsSuccess) {
      Alert.alert(
        "Finished Successfully 🥳",
        "",
        [
          {
            text: "Choose account Type",
            onPress: () => {
              dispatch(changeIsReg(true));
              navigation.navigate("Login");
            },
          },
        ],
        { cancelable: true }
      );
    }
  }, [confirmIsSuccess]);
  useEffect(() => {
    if (verifyIsError && route.params?.type === "forgetPassword") {
      Alert.alert(
        "Verify Error",
        "Try to Resent a new Request and check your email again",
        [
          {
            text: "Try Again♻️",
            onPress: () => {},
          },
        ],
        { cancelable: true }
      );
    } else if (verifyIsError || confirmIsError) {
      console.log("👉", { verifyError, confirmError });
      Alert.alert(
        "Verify Error",
        "Try to Resent a new Request and check your email again",
        [
          {
            text: "Resend New Pin Code",
            onPress: () => {
              resend({ email: registerUser.email });
            },
          },
        ],
        { cancelable: true }
      );
    }
  }, [verifyIsError, confirmIsError]);
  useEffect(() => {
    if (verifyIsSuccess && route.params?.type === "forgetPassword") {
      navigation.navigate("NewPassword", {
        pinId: verifyResponse.pinId,
      });
    } else if (verifyIsSuccess) {
      confirm({ id: verifyResponse.pinId });
    }
  }, [verifyIsSuccess]);
  useEffect(() => {
    if (resendIsSuccess) {
      Alert.alert(
        "Check Your Email",
        "We have successfully send you a new pin code",
        [
          {
            text: "Ok",
            onPress: () => console.log("OK Pressed"),
          },
        ],
        { cancelable: true }
      );
    }
  }, [resendIsSuccess]);
  useEffect(() => {
    if (resendIsError) {
      console.log("👉", resendError);
      console.log("👉", route.params?.type);
      Alert.alert(
        "Error with resending the pin code",
        `${Object.values(resendError && resendError.errors)[0]}}`,
        [
          {
            text: "Ok",
            onPress: () => console.log("========>", registerUser.email),
          },
        ],
        { cancelable: true }
      );
    }
  }, [resendIsError]);
  useEffect(() => {
    if (forgetPasswordIsSuccess) {
      Alert.alert(
        "Check Your Email",
        "Enter the pin code so you can reset your password",
        [
          {
            text: "Ok",
            onPress: () => {},
          },
        ],
        { cancelable: false }
      );
    }
  }, [forgetPasswordIsSuccess]);
  return (
    <Background>
      <Top
        title="Pin Code"
        desc="Check Your Email and Please enter pin code that you have been received"
        widthDesc={250}
      />

      <Form isKeyVisible={isKeyVisible}>
        <Input
          label="Pin Code"
          state={pinCode}
          setState={setPinCode}
          autoCapitalize="none"
        />
        <View
          style={{
            flexDirection: "row",
            justifyContent: "space-around",
            width: "100%",
          }}
        >
          <Btn
            onPress={proceedPressHandler}
            bgColor="secondary"
            textColor="#fff"
            width={190}
            loading={verifyIsLoading}
          >
            Finish
          </Btn>
          <Btn
            onPress={
              route.params?.type === "forgetPassword"
                ? resendForgetPasswordHandler
                : resendPressHandler
            }
            bgColor="light"
            textColor={colors.secondary}
            width={130}
            style={{
              borderWidth: 1,
              borderColor: colors.secondary,
            }}
            loading={isResendLoading || forgetPasswordIsLoading}
          >
            Resend
          </Btn>
        </View>
      </Form>
    </Background>
  );
};

export default RegistrationPinCode;
