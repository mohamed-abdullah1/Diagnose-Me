import { useState } from "react";
import ComponentLayout from "../components/CommonLayout.component";

const RegistrationAge = ({ navigation }) => {
    const [age, setAge] = useState(0);
    return (
        <ComponentLayout
            topTitle="How Old are you?"
            topDesc="Type Your Age"
            topWidth={323}
            inputPlaceHolder="Age"
            imgSrc={require("../../../../assets/helpers/doctors.png")}
            navigationObj={navigation}
            navigateTo="RegistrationWeightHeight"
            state={age}
            setState={setAge}
            imgHeight={245}
            imgWidth={300}
        />
    );
};
export default RegistrationAge;
