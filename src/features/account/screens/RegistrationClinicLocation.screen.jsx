import { useState } from "react";
import ComponentLayout from "../components/CommonLayout.component";

const RegistrationClinicLocation = ({ navigation }) => {
    const [location, setLocation] = useState("");
    return (
        <ComponentLayout
            topTitle="Your Clinic Location"
            topDesc="Enter Your Hour Price So Patient can Know"
            topWidth={323}
            inputPlaceHolder="Location"
            imgSrc={require("../../../../assets/helpers/location.png")}
            navigationObj={navigation}
            navigateTo="RegistrationYearsOfExperience"
            state={location}
            setState={setLocation}
            imgHeight={265}
            imgWidth={280}
        />
    );
};
export default RegistrationClinicLocation;
