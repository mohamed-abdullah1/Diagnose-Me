import { useCallback, useEffect, useState } from "react";
import TopHeader from "../../components/TopHeader.component";
import TitleSeeAll from "../components/TitleSeeAll.component";
import {
  BgContainer,
  CardsSection,
  CategoriesSection,
  DoctorsSection,
  Emoji,
  HeaderContainer,
  Hello,
  MeetingCard,
  Name,
  PatientImg,
  Time,
  TodayMeetings,
  TrendQuestionsSection,
  UpperSectionMeeting,
} from "../styles/Global.styles";
import {
  blogs,
  doctors,
  services,
  specialties,
  trendQuestions,
} from "../../../helpers/consts";
import ServiceCard from "../../components/ServiceCard.component";
import DoctorCard from "../../components/DoctorCard.component";
import {
  Dimensions,
  ScrollView,
  Text,
  TouchableOpacity,
  View,
} from "react-native";
import Spacer from "../../../infrastructure/components/Spacer";
import Card from "../../components/Card.component";
import QuestionCard from "../../components/QuestionCard.component";
import BlogCard from "../../components/BlogCard.component";
import colors from "../../../infrastructure/theme/colors";
import { useFocusEffect } from "@react-navigation/native";
import Modal from "react-native-modal";
import { todayMeetings as loadedTodayMeetings } from "../../../helpers/consts";
import { useDispatch, useSelector } from "react-redux";
import { logout, selectToken } from "../../../services/slices/auth.slice";
import { useGetTrendQuestionsQuery } from "../../../services/apis/questions.api";
import { ActivityIndicator } from "react-native-paper";
import theme from "../../../infrastructure/theme";

const HomeDoc = ({ navigation }) => {
  const [userFirstName, setUserFirstName] = useState("Mohamed");
  const [drawerVisible, setDrawerVisible] = useState(false);
  const [todayMeetings, setTodayMeetings] = useState([]);
  const dispatch = useDispatch();

  const imgPressHandler = () => {
    // navigation.navigate("Profile");
    // console.log("👉", "pressed");
    //TODO make a profile screen for doctor
    dispatch(logout());
  };
  const token = useSelector(selectToken);
  const {
    data: trendQuestions,
    error: trendQuestionsError,
    isLoading: trendQuestionsLoading,
    isError: trendQuestionsIsError,
  } = useGetTrendQuestionsQuery({ token });
  useFocusEffect(
    useCallback(() => {
      navigation.setOptions({
        tabBarStyle: {
          backgroundColor: colors.light,
          height: 58,
          alignItems: "center",
          paddingBottom: 0,
          paddingTop: 4,
        },
      });
    }, [])
  );
  useEffect(() => {
    setTodayMeetings(loadedTodayMeetings);
  }, []);
  useEffect(() => {
    if (trendQuestionsError) {
      Alert.alert(
        "Error",
        "Something Went Wrong in TrendQuestions",
        [{ text: "Ok" }],
        { cancelable: false }
      );
    }
  }, [trendQuestionsIsError]);
  return (
    <BgContainer>
      <TopHeader
        onPress={() => {
          setDrawerVisible(true);
        }}
        onPressImg={imgPressHandler}
        userImg={require("../../../../assets/characters/doctor_male_1.png")}
      />
      <Modal
        coverScreen={false}
        backdropColor={"#000"}
        style={{
          maxWidth: "70%",
          backgroundColor: colors.light,
          margin: 0,
          padding: 0,
        }}
        animationIn="slideInLeft"
        animationOut="slideOutLeft"
        // hasBackdrop={false}
        onBackdropPress={() => setDrawerVisible(false)}
        isVisible={drawerVisible}
      >
        <TouchableOpacity
          onPress={() => {
            navigation.navigate("Blogs");
            setDrawerVisible(false);
          }}
        >
          <Text>⭐ Blog</Text>
        </TouchableOpacity>
      </Modal>
      <ScrollView>
        <HeaderContainer>
          <Hello>Hi, Dr. {userFirstName}</Hello>
          <Emoji source={require("../../../../assets/helpers/emoji.png")} />
        </HeaderContainer>
        {/* <CategoriesSection>
                    <TitleSeeAll title="Categories 📖" showSeeAll={false} />
                    <CardsSection>
                        {specialties.map(({ key, value, src }) => (
                            <ServiceCard
                                pressFunction={() => specialtyHandler(value)}
                                total={specialties.length}
                                key={key}
                                title={value}
                                img={src}
                                index={key}
                            />
                        ))}
                    </CardsSection>
                </CategoriesSection>
                <DoctorsSection>
                    <TitleSeeAll
                        pressFunction={seeAllDoctorsHandler}
                        title="Popular Doctors 🌟"
                    />
                    <CardsSection>
                        {doctors.map((doctor) => (
                            <DoctorCard
                                key={doctor.id}
                                doctor={doctor}
                                index={doctor.id}
                                total={doctors.length}
                            />
                        ))}
                    </CardsSection>
                </DoctorsSection> */}
        {/* <CategoriesSection>
                    <TitleSeeAll title="Services 👨‍🔧" showSeeAll={false} />
                    <CardsSection>
                        {services.map(({ id, title, src }) => (
                            <ServiceCard
                                total={services.length}
                                key={id}
                                title={title}
                                img={src}
                                index={id}
                                pressFunction={() => navigation.navigate(title)}
                            />
                        ))}
                    </CardsSection>
                </CategoriesSection> */}
        <TodayMeetings>
          <TitleSeeAll title="Today Meetings 🌻" showSeeAll={false} />
          <CardsSection
            contentContainerStyle={{
              paddingTop: 10,
              paddingBottom: 10,
              paddingLeft: 4,
              paddingRight: 4,
            }}
          >
            {todayMeetings?.map((t) => (
              <View
                key={t.id}
                elevation={2}
                style={{
                  marginRight: 16,
                  borderRadius: 32,
                  width: 171,
                  backgroundColor: colors.light,
                }}
              >
                <MeetingCard>
                  <UpperSectionMeeting>
                    <PatientImg source={t.img} />
                    <Time>
                      {t.clock.hour +
                        ":" +
                        t.clock.minutes +
                        " " +
                        t.clock.amOrPm}
                    </Time>
                  </UpperSectionMeeting>
                  <Name>{t.patientName}</Name>
                </MeetingCard>
              </View>
            ))}
          </CardsSection>
        </TodayMeetings>
        <TrendQuestionsSection>
          <CategoriesSection>
            <TitleSeeAll
              title="Trend Questions❓"
              pressFunction={() => navigation.navigate("Questions")}
            />
            <CardsSection>
              {trendQuestionsLoading ? (
                <ActivityIndicator
                  animating={trendQuestionsLoading}
                  color={theme.colors.primary}
                />
              ) : (
                trendQuestions?.objects?.map((q) => (
                  <QuestionCard
                    question={q}
                    key={q.id}
                    onPress={() => {
                      navigation.navigate("Questions", {
                        screen: "QuestionPage",
                        params: {
                          questionId: q?.id,
                        },
                      });
                    }}
                  />
                ))
              )}
            </CardsSection>
          </CategoriesSection>
        </TrendQuestionsSection>
        <Spacer position="bottom" size={16}>
          {/* <TrendQuestionsSection>
            <CategoriesSection>
              <TitleSeeAll
                title="Blogs 📓"
                pressFunction={() => navigation.navigate("Blogs")}
              />
              <CardsSection>
                {blogs.map((blog) => (
                  <BlogCard
                    onPress={() =>
                      navigation.navigate("Home", {
                        screen: "BlogPage",
                        params: { blog },
                      })
                    }
                    key={blog?.id}
                    blog={blog}
                    total={blogs.length}
                    index={blog?.id}
                  />
                ))}
              </CardsSection>
            </CategoriesSection>
          </TrendQuestionsSection> */}
        </Spacer>
      </ScrollView>
    </BgContainer>
  );
};
export default HomeDoc;
