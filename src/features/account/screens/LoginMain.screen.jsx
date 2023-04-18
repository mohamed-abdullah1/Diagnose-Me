import { useEffect, useState } from "react";
import Top from "../components/Top";
import { Background, Btn, Form, Reg, RegOption } from "../styles/Shared.styles";
import { Keyboard } from "react-native";
import { useSelector } from "react-redux";
import { selectWaitPinCode } from "../../../services/slices/registration.slice";

const LoginMainScreen = ({ navigation }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);

    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
    const loginPressHandler = () => navigation.navigate("Login");
    const pinCodeState = useSelector(selectWaitPinCode);
    useEffect(() => {
        if (pinCodeState) {
            navigation.navigate("RegistrationPinCode");
        }
    }, []);
    return (
        <Background>
            <Top
                title="LOGIN"
                desc="Please Choose Your Login Method"
                widthDesc={250}
            />
            <Form isKeyVisible={isKeyVisible}>
                <Btn height={50} width={323} textColor="#fff" bgColor="blue">
                    Facebook
                </Btn>
                <Btn
                    height={50}
                    textColor="#fff"
                    width={323}
                    bgColor="success"
                    onPres={() => console.log("👉", "google")}
                >
                    Google
                </Btn>
                <Btn
                    onPress={loginPressHandler}
                    height={50}
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                >
                    LOGIN
                </Btn>
                <RegOption>
                    Don't Have An Account ?{" "}
                    <Reg
                        onPress={() => navigation.navigate("RegistrationMain")}
                    >
                        Register
                    </Reg>
                </RegOption>
            </Form>
        </Background>
    );
};
export default LoginMainScreen;
