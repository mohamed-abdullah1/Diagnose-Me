import { useState } from "react";
import { Keyboard, TouchableOpacity } from "react-native";
import Top from "../components/Top";
import { Background, Btn, Form, InputField } from "../styles/Shared.styles";
import * as yup from "yup";
import { Formik } from "formik";
import Input from "../../components/Input.component";
import { Text } from "react-native";
import { DateTimePickerAndroid } from "@react-native-community/datetimepicker";
import * as dateFns from "date-fns";
import { View } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import { MaterialIcons } from "@expo/vector-icons";
import { useDispatch, useSelector } from "react-redux";
import {
    addInfo,
    selectRegisterUser,
} from "../../../services/slices/registration.slice";
import { useEffect } from "react";

const regNameSchema = yup.object({
    userName: yup.string().required("Username ise Required"),
});

const RegistrationUserName = ({ navigation }) => {
    const [isKeyVisible, setIsKeyVisible] = useState(false);
    const [date, setDate] = useState(new Date());
    const registerUser = useSelector(selectRegisterUser);
    const dispatch = useDispatch();

    Keyboard.addListener("KeyboardDidShow", () => setIsKeyVisible(true));
    Keyboard.addListener("KeyboardDidHide", () => setIsKeyVisible(false));
    const proceedPressHandler = (values) => {
        navigation.navigate("RegistrationPassword");
        // if (!registerUser.dateOfbirth || !registerUser.userName) {
        dispatch(
            addInfo({
                ...values,
                dateOfbirth: dateFns.format(date, "yyyy-MM-dd"),
            })
        );
        // console.log("👉");
        // }
    };
    const showMode = (currentMode) => {
        DateTimePickerAndroid.open({
            value: date,
            onChange,
            mode: currentMode,
            is24Hour: true,
            is24Hour: false,
            themeVariant: "dark",
        });
    };
    const onChange = (event, selectedDate) => {
        const currentDate = selectedDate;
        console.log("👉👉", dateFns.format(currentDate, "yyy-MM-dd"));
        setDate(currentDate);
    };
    const showDatePicker = () => {
        showMode("date");
    };
    useEffect(() => {
        if (registerUser.dateOfbirth) {
            setDate(new Date(registerUser.dateOfbirth));
        } else {
            setDate(new Date());
        }
    }, []);
    return (
        <Background>
            <Top
                title="REGISTER"
                desc="Please enter Your Username and Date of Birth"
                widthDesc={250}
            />
            <Formik
                initialValues={{
                    userName: registerUser?.userName
                        ? registerUser.userName
                        : "",
                }}
                onSubmit={proceedPressHandler}
                validationSchema={regNameSchema}
            >
                {({
                    handleChange,
                    handleBlur,
                    handleSubmit,
                    values,
                    errors,
                    touched,
                }) => (
                    <Form isKeyVisible={isKeyVisible}>
                        <Input
                            label="Username"
                            state={values.userName}
                            setState={handleChange("userName")}
                            onBlur={handleBlur("userName")}
                            autoCapitalize="none"
                            error={errors.userName && touched.userName}
                        />
                        {errors.userName && touched.userName && (
                            <Text
                                style={{
                                    color: "red",
                                    width: "80%",
                                }}
                            >
                                {errors.userName}
                            </Text>
                        )}
                        <View
                            style={{
                                width: "80%",
                            }}
                        >
                            <Text
                                style={{
                                    fontFamily: "Poppins",
                                    fontSize: 16,
                                }}
                            >
                                Select Your Birth Date
                            </Text>
                            <TouchableOpacity
                                onPress={() => showDatePicker()}
                                style={{
                                    backgroundColor: colors.moreMuted,
                                    paddingHorizontal: 16,
                                    paddingVertical: 8,
                                    height: 50,
                                    borderRadius: 8,
                                    flexDirection: "row",
                                    justifyContent: "space-between",
                                    alignItems: "center",
                                    borderColor: colors.secondary,
                                    borderWidth: 1,
                                }}
                            >
                                <Text
                                    style={{
                                        fontFamily: "Poppins",
                                        fontSize: 14,
                                    }}
                                >
                                    {dateFns.format(date, "yyyy/MM/dd")}
                                </Text>
                                <MaterialIcons
                                    name="date-range"
                                    size={24}
                                    color={colors.secondary}
                                />
                            </TouchableOpacity>
                        </View>
                        <Btn
                            onPress={handleSubmit}
                            bgColor="secondary"
                            textColor="#fff"
                            width={323}
                        >
                            Proceed
                        </Btn>
                    </Form>
                )}
            </Formik>
        </Background>
    );
};

export default RegistrationUserName;
