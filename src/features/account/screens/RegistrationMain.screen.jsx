import { useState } from "react";
import Top from "../components/Top";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";
import { Keyboard } from "react-native";

const RegistrationMain = ({ navigation }) => {
  const [isKeyVisible, setIsKeyVisible] = useState(false);

  Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
  Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
  const proceedPressHandler = () => {
    navigation.navigate("RegistrationName");
  };
  return (
    <Background>
      <Top
        title="REGISTER"
        desc="Please enter your Phone and Email"
        widthDesc={250}
      />
      <Form isKeyVisible={isKeyVisible}>
        <InputField placeholder="Email" />
        <InputField placeholder="Phone Number" />

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

export default RegistrationMain;
