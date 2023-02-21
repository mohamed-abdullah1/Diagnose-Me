import Top from "../components/Top";
import {
    Background,
    Btn,
    Form,
    InputField,
    Reg,
    RegOption,
} from "../styles/Shared.styles";
import { useState } from "react";
import { Keyboard } from "react-native";

const LoginScreen = ({ navigation }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);

    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
    return (
        <Background>
            <Top
                title="LOGIN"
                desc="Please enter your phone number and email address"
                widthDesc={250}
            />
            <Form isKeyVisible={isKeyVisible}>
                <InputField placeholder="Email" />
                <InputField placeholder="Password" />
                <Btn bgColor="secondary" textColor="#fff" width={323}>
                    LOGIN
                </Btn>
            </Form>
            <RegOption>
                Don't Have An Account ?{" "}
                <Reg onPress={() => navigation.navigate("RegistrationMain")}>
                    Register
                </Reg>
            </RegOption>
            {/* <BottomContainer>
        {!txtFocus ? <TitleOption>Or Continue With </TitleOption> : null}
        <FaceAndGoogleContainer>
          <Btn textColor="#fff" width="142" bgColor="blue">
            Facebook
          </Btn>
          <Btn
            textColor="#fff"
            width="142"
            bgColor="success"
            onPres={() => console.log("👉", "google")}
          >
            Google
          </Btn>
        </FaceAndGoogleContainer>
      </BottomContainer> */}
        </Background>
    );
};
export default LoginScreen;
