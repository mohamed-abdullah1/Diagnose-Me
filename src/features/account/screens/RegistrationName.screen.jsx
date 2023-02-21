import { useState } from "react";
import { Keyboard } from "react-native";
import Top from "../components/Top";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";

const RegistrationName = ({ navigation }) => {
  const [isKeyVisible, setIsKeyVisible] = useState(false);

  Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
  Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
  const proceedPressHandler = () => navigation.navigate("RegistrationPassword");

  return (
    <Background>
      <Top
        title="REGISTER"
        desc="Please enter your  First and Last name"
        widthDesc={250}
      />
      <Form isKeyVisible={isKeyVisible}>
        <InputField placeholder="First Name" />
        <InputField placeholder="Last Name" />

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

export default RegistrationName;
