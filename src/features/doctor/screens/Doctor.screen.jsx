import {
    useFocusEffect,
    useIsFocused,
    useNavigation,
} from "@react-navigation/native";
import { useCallback, useEffect } from "react";
import { ScrollView, Text, View } from "react-native";
import { doctors } from "../../../helpers/consts";
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
import {
    About,
    AboutContent,
    AboutTitle,
    Container,
    Date,
    Experience,
    Icon,
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

            return () => {
                navigation.getParent().setOptions({
                    tabBarStyle: {
                        backgroundColor: colors.secondary,
                        height: 55,
                        alignItems: "center",
                        display: "flex",
                    },
                });
            };
        }, [])
    );
    console.log("🌘", reviews[0].patientImg);
    console.log("🌘", doctorImg);
    return (
        <BgContainer>
            <View
                style={{
                    alignItems: "center",
                    marginTop: 80,
                }}
            >
                <ImgContainer>
                    <Img source={doctorImg} />
                    {/* <Feather name="message-circle" size={24} color="black" /> */}
                    <Icon />
                </ImgContainer>
                <Wrapper>
                    <View style={{ width: "100%", height: 105 }} />
                    <ScrollView>
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
                                            <ReviewCard key={id}>
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
                                    <LocationIcon />
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

            <BottomButton label="Book Now" bgColor={colors.pantone} />
        </BgContainer>
    );
};
export default Doctor;
