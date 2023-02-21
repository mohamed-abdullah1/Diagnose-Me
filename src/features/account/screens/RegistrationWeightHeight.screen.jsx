import { useState } from "react";
import { Keyboard } from "react-native";
import Top from "../components/Top";
import Upper from "../components/Upper";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";
const RegistrationWeightHeight = ({ navigation }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);

    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));

    const pressHandler = () => navigation.navigate("RegistrationBloodType");
    return (
        <Background>
            <Upper navigation={navigation} />
            <Top
                title="Weight and Height"
                desc="Most Doctors Need it"
                widthDesc={250}
            />
            <Form isKeyVisible={isKeyVisible}>
                <InputField placeholder="Weight" />
                <InputField placeholder="Height" />
                <Btn
                    onPress={pressHandler}
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                >
                    Next
                </Btn>
            </Form>
        </Background>
    );
};

export default RegistrationWeightHeight;
