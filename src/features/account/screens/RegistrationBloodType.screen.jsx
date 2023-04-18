import { useEffect, useState } from "react";
import { FlatList } from "react-native";
import Top from "../components/Top";
import Upper from "../components/Upper";
import {
    Background,
    BloodGroup,
    BloodItem,
    BloodItemContent,
    BloodItemsContainer,
    BottomBtnWrapper,
    Btn,
    VectorBgContainer,
    VectorImg,
} from "../styles/Shared.styles";
import { useRegisterMutation } from "../../../services/apis/auth.api";
import { Alert } from "react-native";
import { useDispatch, useSelector } from "react-redux";
import { selectRegisterUser } from "../../../services/slices/registration.slice";

const bloodGroups = [
    {
        id: 1,
        blood: "A+",
    },

    {
        id: 2,
        blood: "A-",
    },

    {
        id: 3,
        blood: "B+",
    },

    {
        id: 4,
        blood: "B-",
    },

    {
        id: 5,
        blood: "O+",
    },

    {
        id: 6,
        blood: "O-",
    },

    {
        id: 7,
        blood: "AB+",
    },

    {
        id: 8,
        blood: "AB-",
    },
];

const Item = ({ item, blood, setBlood }) => (
    <BloodItem
        onPress={() => setBlood(item.blood)}
        blood={blood}
        itemBlood={item.blood}
    >
        <BloodItemContent>{item.blood}</BloodItemContent>
    </BloodItem>
);

const RegistrationBloodType = ({ navigation }) => {
    const [blood, setBlood] = useState("none");
    const [
        registerUser,
        {
            // data: registerResponse,
            isSuccess: registerSuccess,
            isError: registerIsError,
            isLoading: registerIsLoading,
            error: registerError,
        },
    ] = useRegisterMutation();
    const { weight, height, isDoctor, ...userData } =
        useSelector(selectRegisterUser);
    const dispatch = useDispatch();
    console.log("👉", userData);
    console.log("👉", blood);
    const nextPressHandler = async () => {
        //register request
        //TODO: handle the nationalID
        await registerUser({
            ...userData,
            nationalID: "12345678912345",
            bloodType: blood,
        });
        if (!Object.keys(userData).includes("bloodType")) {
            dispatch(addInfo({ bloodType: blood }));
        }
    };
    useEffect(() => {
        if (registerIsError) {
            console.log("👉", registerError);
            Alert.alert(
                "Something went wrong",
                `Error:- ${registerError}`,
                [
                    {
                        text: "Try again",
                    },
                ],
                { cancelable: true }
            );
        }
    }, [registerIsError]);
    useEffect(() => {
        if (registerSuccess) {
            Alert.alert(
                "Registered Successfully 😀🎈",
                `Check Your Email Address for Pin code and enter it`,
                [
                    {
                        text: "Next",
                        onPress: () =>
                            navigation.navigate("RegistrationPinCode"),
                    },
                ],
                { cancelable: true }
            );
        }
    }, [registerSuccess]);
    useEffect(() => {
        if (Object.keys(userData).includes("bloodType")) {
            setBlood(userData.bloodType);
        }
    }, []);
    return (
        <Background>
            <Upper navigation={navigation} showSkip={false} />
            <Top
                widthDesc={250}
                title="Blood Group"
                desc="Most Doctors Need it"
            />
            <BloodGroup>
                <BloodItemsContainer>
                    <FlatList
                        data={bloodGroups}
                        renderItem={({ item }) => (
                            <Item
                                setBlood={setBlood}
                                item={item}
                                blood={blood}
                            />
                        )}
                        keyExtractor={(item) => item.id}
                        numColumns={2}
                    />
                </BloodItemsContainer>
            </BloodGroup>
            <BottomBtnWrapper>
                <Btn
                    activeOpacity={blood === "none" ? 1 : 0.7}
                    disabled={blood === "none"}
                    mode="contained"
                    bgColor="secondary"
                    textColor="#fff"
                    width={323}
                    onPress={nextPressHandler}
                    loading={registerIsLoading}
                >
                    Done ✅
                </Btn>
            </BottomBtnWrapper>
            <VectorBgContainer>
                <VectorImg
                    source={require("../../../../assets/helpers/bg.png")}
                />
            </VectorBgContainer>
        </Background>
    );
};
export default RegistrationBloodType;
