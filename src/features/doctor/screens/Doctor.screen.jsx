import {
  useFocusEffect,
  useIsFocused,
  useNavigation,
  useScrollToTop,
} from "@react-navigation/native";
import { useCallback, useEffect, useRef } from "react";
import { ScrollView, Text, View } from "react-native";
import { doctors } from "../../../helpers/consts";
import responsive from "../../../helpers/responsive";
import colors from "../../../infrastructure/theme/colors";
import BottomButton from "../../components/BottomButton.component";
import Card from "../../components/Card.component";
import Rate from "../../components/Rate.Component";
import TitleSeeAll from "../../home/components/TitleSeeAll.component";
import {
  BgContainer,
  CardsSection,
  CategoriesSection,
} from "../../home/styles/Global.styles";
import UpperBack from "../components/UpperBack.component";
import {
  About,
  AboutContent,
  AboutTitle,
  Container,
  Date,
  Experience,
  Icon,
  IconContainer,
  Img,
  ImgContainer,
  Location,
  LocationContainer,
  LocationContentContainer,
  LocationDescAddress,
  LocationIcon,
  LocationMainAddress,
  LocationTitle,
  Name,
  NumberOfPatient,
  NumberOfYears,
  PatientIcon,
  PatientInfoContainer,
  PatientName,
  Patients,
  Price,
  PriceContainer,
  PriceTitle,
  ReviewCard,
  ReviewContent,
  ReviewerImg,
  ReviewsCards,
  ReviewsSection,
  Specialty,
  Upper,
  WorkIcon,
  Wrapper,
} from "../styles/Doctor.styles";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { ActivityIndicator, Button } from "react-native-paper";
import theme from "../../../infrastructure/theme";
import { useGetSingleDoctorQuery } from "../../../services/apis/medicalService";
import { Pressable } from "react-native";
import { useCreateAccessChatMutation } from "../../../services/apis/chat.api";
import useSocketSetup from "../../../helpers/useSocketSetup";
import { imgUrl } from "../../../services/apiEndPoint";

const { getX, getY } = responsive(840, 395);
/* The above code is a React component written in JavaScript. It is a Doctor component that displays
information about a doctor, such as their name, specialty, number of patients, years of experience,
average rate, bio, location, consultation price, and reviews. It also allows the user to book an
appointment with the doctor. The component uses various hooks and Redux selectors to fetch data from
an API and manage state. It also includes styling and navigation logic. */
const Doctor = ({ route }) => {
  const socket = useSocketSetup();

  const navigation = useNavigation();
  const { doctorId } = route.params;
  const token = useSelector(selectToken);
  console.log("I am Called");
  const [
    makeChat,
    { data: chat, isSuccess: chatIsSuccess, isLoading: makeChatIsLoading },
  ] = useCreateAccessChatMutation();
  const currentUser = useSelector(selectUser);
  const {
    data: doctor,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetSingleDoctorQuery({ token, doctorId });
  console.log({ doctor });
  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
        tabBarStyle: { display: "none" },
      });
    }, [])
  );
  useEffect(() => {
    if (error) {
      console.error(error);
      console.log(error);
    }
  }, [error]);
  const bookPressHandler = () =>
    navigation.navigate({
      name: "MakeAppointment",
      params: {
        doctorId: doctor?.id,
        doctor,
      },
    });
  const ref = useRef(null);

  useScrollToTop(
    useRef({
      scrollToTop: () => ref?.current?.scrollToOffset({ offset: 10 }),
    })
  );
  const formLocationUpper = (address) => {
    console.log("address", address);
    return `${address.country} , at city ${address.city}  `;
  };
  const formLocationDown = (address) => {
    return `state ${address.state}  , street ${address?.street}  `;
  };

  console.log("doctor🔥", doctor);

  useEffect(() => {
    if (chatIsSuccess) {
      console.log("👉🗣️chat", chat.users.length, chat?.users);
      chat?.users.filter((user) => user._id !== currentUser.id)[0];
      navigation.navigate("Messages", {
        screen: "Chat",
        params: {
          chatId: chat?._id,
          otherPerson: chat?.users.filter(
            (user) => user._id !== currentUser.id
          )[0],
          socket,
        },
      });
    }
  }, [chatIsSuccess]);

  const handleChat = (doctorId, patientId) => {
    // create or access a chat between patient and doctor and start talking
    makeChat({ token, userId: doctorId });
  };
  return (
    <BgContainer>
      {isLoading ? (
        <ActivityIndicator
          animating={isLoading}
          color={theme.colors.primary}
          style={{
            flex: 1,
            justifyContent: "center",
            alignItems: "center",
          }}
        />
      ) : (
        <>
          <View
            style={{
              alignItems: "center",
              justifyContent: "center",
              // borderColor: "red",
              // borderWidth: 1,
              flex: 1,
            }}
          >
            <Wrapper
              style={{
                shadowColor: "#000000b9",
                shadowOffset: {
                  width: -10,
                  height: 10,
                },
                shadowOpacity: 0.25,
                shadowRadius: 16,

                elevation: 25,
                // shadowColor: "#171717f",
                // shadowOffset: { width: 0, height: 1 },
                // shadowOpacity: 0.2,
                // shadowRadius: 16,
              }}
            >
              <UpperBack top={-70} left={0} />

              <ImgContainer>
                <Img
                  source={
                    doctor?.profilePictureUrl
                      ? { uri: `${imgUrl}${doctor?.profilePictureUrl}` }
                      : require("../../../../assets/characters/male.png")
                  }
                />
                <Pressable onPress={() => handleChat(doctor.id, "")}>
                  <Icon />
                </Pressable>
              </ImgContainer>

              <View style={{ width: "100%", height: getY(114) }} />
              <ScrollView ref={ref}>
                <View
                  style={{
                    alignItems: "center",
                    // borderColor: "red",
                    // borderWidth: 1,
                    height: "100%",
                    flex: 1,
                  }}
                >
                  <Name>{"Dr. " + doctor?.fullName}</Name>
                  <Specialty>{doctor?.clinicSpecialization}</Specialty>
                  <Container>
                    <Patients>
                      <PatientIcon />
                      <NumberOfPatient>
                        {doctor?.numberOfPatients + " +"}
                      </NumberOfPatient>
                    </Patients>
                    <Experience>
                      <WorkIcon />
                      <NumberOfYears>
                        {doctor?.yearsOfExperience + " years"}
                      </NumberOfYears>
                    </Experience>
                    <Rate rate={doctor?.averageRate} />
                  </Container>
                  <About>
                    <AboutTitle>About Doctor</AboutTitle>
                    <AboutContent>{doctor?.bio}</AboutContent>
                  </About>
                  {/* <ReviewsSection>
                    <TitleSeeAll title="Reviews" />

                    <ReviewsCards>
                      {reviews.map(
                        ({
                          id,
                          patientName,
                          rate,
                          reviewContent,
                          date,
                          patientImg,
                        }) => (
                          <ReviewCard
                            style={{
                              shadowColor: "#000000da",
                              shadowOffset: {
                                width: -10,
                                height: 10,
                              },
                              shadowOpacity: 0.25,
                              shadowRadius: 16,
                              elevation: 5,
                              // shadowColor: "#171717f",
                              // shadowOffset: { width: 0, height: 1 },
                              // shadowOpacity: 0.2,
                              // shadowRadius: 16,
                            }}
                            key={id}
                          >
                            <Upper>
                              <ReviewerImg source={patientImg} />
                              <PatientInfoContainer>
                                <PatientName>{patientName}</PatientName>
                                <Date>{date}</Date>
                              </PatientInfoContainer>
                              <Rate rate={rate} />
                            </Upper>
                            <ReviewContent>{reviewContent}</ReviewContent>
                          </ReviewCard>
                        )
                      )}
                    </ReviewsCards>
                  </ReviewsSection> */}
                  <Location>
                    <LocationTitle>Location</LocationTitle>
                    <LocationContainer>
                      <IconContainer>
                        <LocationIcon />
                      </IconContainer>
                      <LocationContentContainer>
                        <LocationMainAddress>
                          {doctor?.ownedClinicAddresses[0] &&
                            formLocationUpper(doctor?.ownedClinicAddresses[0])}
                        </LocationMainAddress>
                        <LocationDescAddress>
                          {doctor?.ownedClinicAddresses[0] &&
                            formLocationDown(doctor?.ownedClinicAddresses[0])}
                        </LocationDescAddress>
                      </LocationContentContainer>
                    </LocationContainer>
                  </Location>
                  <PriceContainer
                    style={{
                      borderBottomRightRadius: 32,
                      borderBottomLeftRadius: 32,
                    }}
                  >
                    <PriceTitle>Consultation Price</PriceTitle>
                    <Price>{doctor?.pricePerSession + ".00 LE"}</Price>
                  </PriceContainer>
                </View>
              </ScrollView>
            </Wrapper>
          </View>
          {/* 
          <BottomButton
            pressFunction={bookPressHandler}
            label="Book Now"
            bgColor=
            {colors.light}
          /> */}
          <Button
            textColor="#fff"
            buttonColor={theme.colors.secondary}
            labelStyle={{ fontFamily: "Poppins" }}
            onPress={bookPressHandler}
            mode="contained"
            style={{
              width: "50%",
              alignSelf: "center",
              marginBottom: 20,
            }}
          >
            Book
          </Button>
        </>
      )}
    </BgContainer>
  );
};
export default Doctor;
