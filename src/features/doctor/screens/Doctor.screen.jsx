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
const { getX, getY } = responsive(840, 395);
const Doctor = ({ route }) => {
    const navigation = useNavigation();
    const { doctorId } = route.params;
    const {
        id,
        doctorImg,
        name,
        specialty,
        pricePerHour,
        rate,
        yearsOfExperience,
        numberOfPatients,
        aboutDoctor,
        reviews,
        location,
    } = doctors.find((doc) => doc.id === doctorId);

    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: { display: "none" },
            });
        }, [])
    );
    const bookPressHandler = () =>
        navigation.navigate({
            name: "MakeAppointment",
            params: {
                doctorId: id,
            },
        });
    const ref = useRef(null);

    useScrollToTop(
        useRef({
            scrollToTop: () => ref?.current?.scrollToOffset({ offset: 10 }),
        })
    );
    return (
        <BgContainer>
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
                        <Img source={doctorImg} />
                        <Icon />
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
                            <Name>{"Dr. " + name}</Name>
                            <Specialty>{specialty}</Specialty>
                            <Container>
                                <Patients>
                                    <PatientIcon />
                                    <NumberOfPatient>
                                        {numberOfPatients + " +"}
                                    </NumberOfPatient>
                                </Patients>
                                <Experience>
                                    <WorkIcon />
                                    <NumberOfYears>
                                        {yearsOfExperience + " years"}
                                    </NumberOfYears>
                                </Experience>
                                <Rate rate={rate} />
                            </Container>
                            <About>
                                <AboutTitle>About Doctor</AboutTitle>
                                <AboutContent>{aboutDoctor}</AboutContent>
                            </About>
                            <ReviewsSection>
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
                                                    <ReviewerImg
                                                        source={patientImg}
                                                    />
                                                    <PatientInfoContainer>
                                                        <PatientName>
                                                            {patientName}
                                                        </PatientName>
                                                        <Date>{date}</Date>
                                                    </PatientInfoContainer>
                                                    <Rate rate={rate} />
                                                </Upper>
                                                <ReviewContent>
                                                    {reviewContent}
                                                </ReviewContent>
                                            </ReviewCard>
                                        )
                                    )}
                                </ReviewsCards>
                            </ReviewsSection>
                            <Location>
                                <LocationTitle>Location</LocationTitle>
                                <LocationContainer>
                                    <IconContainer>
                                        <LocationIcon />
                                    </IconContainer>
                                    <LocationContentContainer>
                                        <LocationMainAddress>
                                            {location.mainAddress}
                                        </LocationMainAddress>
                                        <LocationDescAddress>
                                            {location.descAddress}
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
                                <Price>{pricePerHour + ".00 LE"}</Price>
                            </PriceContainer>
                        </View>
                    </ScrollView>
                </Wrapper>
            </View>

            <BottomButton
                pressFunction={bookPressHandler}
                label="Book Now"
                bgColor={colors.light}
            />
        </BgContainer>
    );
};
export default Doctor;
