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
import { useBookAppointmentMutation } from "../../../services/apis/appointment.api";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { Button } from "react-native-paper";
import { useEffect } from "react";
import { Toast } from "toastify-react-native";
import theme from "../../../infrastructure/theme";

const MakeAppointmentNote = ({ navigation, route }) => {
  const {
    doctorName,
    doctorImg,
    rate,
    specialty,
    numberOfReviews,
    selected,
    selectedTime,
    doctorId,
  } = route.params;
  const token = useSelector(selectToken);
  const user = useSelector(selectUser);
  const [bookAppointment, { isSuccess, isLoading: bookingLoading }] =
    useBookAppointmentMutation();
  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
        tabBarStyle: { display: "none" },
      });
    }, [])
  );
  const processHandler = () => {
    bookAppointment({
      token,
      patientId: user.id,
      day: selected,
      timeId: selectedTime._id,
      doctorId: doctorId,
    });
  };
  useEffect(() => {
    if (isSuccess) {
      navigation.navigate("Home", {
        screen: "Feed",
      });
      Toast.success("Appointment Booked Successfully");
    }
  }, [isSuccess]);
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
        <Button
          textColor="#fff"
          buttonColor={theme.colors.secondary}
          labelStyle={{ fontFamily: "Poppins" }}
          disabled={bookingLoading}
          loading={bookingLoading}
          onPress={processHandler}
          mode="contained"
          style={{
            width: "50%",
            alignSelf: "center",
            marginBottom: 20,
            marginTop: 20,
          }}
        >
          Process Booking
        </Button>
      </Wrapper>
    </BgContainer>
  );
};

export default MakeAppointmentNote;
