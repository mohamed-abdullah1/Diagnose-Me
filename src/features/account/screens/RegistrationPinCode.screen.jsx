import { useState } from "react";
import { Alert, Keyboard, View } from "react-native";
import Top from "../components/Top";
import { Background, Btn, Form, Reg, RegOption } from "../styles/Shared.styles";
import Input from "../../components/Input.component";
import { Text } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import {
    useConfirmMutation,
    useResendConfirmMutation,
    useVerifyMutation,
} from "../../../services/apis/auth.api";
import { useEffect } from "react";
import { selectRegisterUser } from "../../../services/slices/registration.slice";
import { useSelector } from "react-redux";

const RegistrationPinCode = ({ navigation, route }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);
    const [pinCode, setPinCode] = useState("");
    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
    const { email } = useSelector(selectRegisterUser);
    const [
        verify,
        {
            data: verifyResponse,
            isError: verifyIsError,
            isSuccess: verifyIsSuccess,
            isLoading: verifyIsLoading,
        },
    ] = useVerifyMutation();
    const [confirm, { isError: confirmIsError, isSuccess: confirmIsSuccess }] =
        useConfirmMutation();
    const [resend, { isLoading: isResendLoading }] = useResendConfirmMutation();

    const proceedPressHandler = async () => {
        //navigate to the login screen
        //send the pin code to the verify endpoint
        //confirm endpoint
        //navigate to the login screen
        await verify({ pinCode });
    };
    useEffect(() => {
        if (confirmIsSuccess) {
            Alert.alert(
                "Finished Successfully 🥳",
                "",
                [
                    {
                        text: "Go to Login",
                        onPress: () => navigation.navigate("Login"),
                    },
                ],
                { cancelable: true }
            );
        }
    }, [confirmIsSuccess]);
    useEffect(() => {
        if (verifyIsError || confirmIsError) {
            Alert.alert(
                "Verify Error",
                "Try to Resent a new Request and check your email again",
                [
                    {
                        text: "Resend New Pin Code",
                        onPress: () => resend({ email }),
                    },
                ],
                { cancelable: true }
            );
        }
    }, [verifyIsError, confirmIsError]);
    useEffect(() => {
        if (verifyIsSuccess) {
            confirm({ id: verifyResponse.pinId });
        }
    }, [verifyIsSuccess]);
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
                        onPress={proceedPressHandler}
                        bgColor="light"
                        textColor={colors.secondary}
                        width={130}
                        style={{
                            borderWidth: 1,
                            borderColor: colors.secondary,
                        }}
                        loading={isResendLoading}
                    >
                        Resend
                    </Btn>
                </View>
            </Form>
        </Background>
    );
};

export default RegistrationPinCode;
