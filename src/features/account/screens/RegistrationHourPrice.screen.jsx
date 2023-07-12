import { useState } from "react";
import ComponentLayout from "../components/CommonLayout.component";

const RegistrationHourPrice = ({ navigation }) => {
  const [price, setPrice] = useState(0);

  return (
    <ComponentLayout
      topTitle="What is your Hour Price?"
      topDesc="Enter Your Hour Price So Patient can Know"
      topWidth={323}
      inputPlaceHolder="Years of Experience"
      imgSrc={require("../../../../assets/helpers/dollar.png")}
      navigationObj={navigation}
      navigateTo="main"
      state={price}
      setState={setPrice}
      imgHeight={215}
      imgWidth={300}
    />
  );
};
export default RegistrationHourPrice;
