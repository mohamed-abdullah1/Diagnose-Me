import { useFocusEffect } from "@react-navigation/native";
import { useCallback } from "react";
import { View } from "react-native";
import BottomButton from "../../components/BottomButton.component";
import { BgContainer } from "../../home/styles/Global.styles";
import InfoSection from "../components/InfoSection.component";
import UpperBack from "../components/UpperBack.component";
import {
    InputContainer,
    InputField,
    Wrapper,
} from "../styles/MakeAppointmentNote.styles";

const MakeAppointmentNote = ({ navigation, route }) => {
    const { doctorName, doctorImg, rate, specialty, numberOfReviews } =
        route.params;
    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: { display: "none" },
            });
        }, [])
    );
    return (
        <BgContainer>
            <Wrapper>
                <UpperBack top={40} left={18} />
                <View
                    style={{
                        flex: 0.6,
                        justifyContent: "space-around",
                    }}
                >
                    <InfoSection
                        doctorName={doctorName}
                        doctorImg={doctorImg}
                        rate={rate}
                        specialty={specialty}
                        numberOfReviews={numberOfReviews}
                    />
                </View>
                <InputContainer>
                    <InputField
                        style={{
                            textAlignVertical: "top",
                            elevation: 15,
                            shadowColor: "#000000bb",
                            shadowOffset: { width: -2, height: 4 },
                            shadowOpacity: 0.82,
                            shadowRadius: 3,
                        }}
                        multiline={true}
                        placeholder="Enter Information for the Doctor ......"
                    />
                </InputContainer>
                <BottomButton
                    label={"Proceed To Pay"}
                    onPress={() => console.log("Proceed To Pay")}
                    pressFunction={() => console.log("press Function ⭐")}
                />
            </Wrapper>
        </BgContainer>
    );
};

export default MakeAppointmentNote;
