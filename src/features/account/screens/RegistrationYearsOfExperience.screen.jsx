import { useState } from "react";
import ComponentLayout from "../components/CommonLayout.component";

const RegistrationYearsOfExperience = ({ navigation }) => {
    const [years, setYears] = useState(0);
    return (
        <ComponentLayout
            topTitle="Years Experience"
            topDesc="Enter Your years of experience "
            topWidth={323}
            inputPlaceHolder="Years of Experience"
            imgSrc={require("../../../../assets/helpers/experinece.png")}
            navigationObj={navigation}
            navigateTo="RegistrationYearsOfExperience"
            state={years}
            setState={setYears}
            imgHeight={250}
            imgWidth={300}
        />
    );
};
export default RegistrationYearsOfExperience;
