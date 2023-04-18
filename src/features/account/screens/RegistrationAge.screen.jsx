import ComponentLayout from "../components/CommonLayout.component";
import * as yup from "yup";
const regSchema = yup.object({
    age: yup
        .number()
        .required("Age is Required")
        .min(18, "Minimum Age is 18")
        .max(100, "Maximum Age is 100"),
});

const RegistrationAge = ({ navigation, route }) => {
    return (
        <ComponentLayout
            topTitle="How Old are you?"
            topDesc="Type Your Age"
            topWidth={323}
            inputPlaceHolder="Age"
            imgSrc={require("../../../../assets/helpers/doctors.png")}
            navigationObj={navigation}
            navigateTo="RegistrationWeightHeight"
            imgHeight={245}
            imgWidth={300}
            route={route}
            regSchema={regSchema}
            paramName="age"
            keyboardType="numeric"
        />
    );
};
export default RegistrationAge;
