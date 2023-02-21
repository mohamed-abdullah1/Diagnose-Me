import { useState } from "react";
import { Keyboard } from "react-native";
import Top from "../components/Top";
import {
    Circle,
    Background,
    Btn,
    Content,
    Form,
    InputField,
    Instruction,
    InstructionList,
    ContentContainer,
} from "../styles/Shared.styles";

const RegistrationPassword = ({ navigation }) => {
    const [isKeyVisible, setKeyboardVisible] = useState(false);

    const proceedPressHandler = () => {
        navigation.navigate("RegistrationGender");
    };
    Keyboard.addListener("keyboardDidShow", () => {
        setKeyboardVisible(true); // or some other action
    });
    Keyboard.addListener("keyboardDidHide", () => {
        setKeyboardVisible(false); // or some other action
    });
    return (
        <Background>
            <Top
                title="PASSWORD"
                desc="Please enter your New Password and Confirm it"
                widthDesc={250}
            />
            <Form isKeyVisible={isKeyVisible} flexKeyIsHide={0.4}>
                <InputField placeholder="Password" />
                <InputField placeholder="Confirm Password" />
                {!isKeyVisible && (
                    <InstructionList>
                        <Instruction>
                            <Circle />
                            <ContentContainer>
                                <Content>At Least 8 Characters</Content>
                            </ContentContainer>
                        </Instruction>
                        <Instruction>
                            <Circle />
                            <ContentContainer>
                                <Content>Both uppercase and lowercase</Content>
                            </ContentContainer>
                        </Instruction>
                        <Instruction>
                            <Circle />
                            <ContentContainer>
                                <Content>at least one number or symbol</Content>
                            </ContentContainer>
                        </Instruction>
                    </InstructionList>
                )}
                <Btn
                    onPress={proceedPressHandler}
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                >
                    Proceed
                </Btn>
            </Form>
        </Background>
    );
};

export default RegistrationPassword;
