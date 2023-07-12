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
  Alert,
  Dimensions,
  Pressable,
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
import {
  logout,
  selectToken,
  selectUser,
} from "../../../services/slices/auth.slice";
import { useGetTrendQuestionsQuery } from "../../../services/apis/questions.api";
import { ActivityIndicator, Button } from "react-native-paper";
import theme from "../../../infrastructure/theme";
import { format, set } from "date-fns";
import { useGetAppointmentsQuery } from "../../../services/apis/appointment.api";
import { useGetBlogsQuery } from "../../../services/apis/blogs.api";
import {
  NoMeetingContainer,
  NoMeetingImg,
  NoMeetingTitle,
} from "../../schedule/styles/ScheduleMainDoc.styles";
import {
  Entypo,
  Feather,
  FontAwesome5,
  Ionicons,
  MaterialIcons,
} from "@expo/vector-icons";
import { imgUrl } from "../../../services/apiEndPoint";
import { StyleSheet } from "react-native";
import { CharImg } from "../../styles/TopHeader.styles";

const ItemRow = ({ icon, title, onPress }) => {
  const [press, setPress] = useState(false);
  return (
    <Pressable
      style={styles.itemContainer}
      onPress={() => {
        setPress(true);
        onPress();
      }}
      onPressOut={() => setPress(false)}
    >
      <View style={styles.icon}>{icon}</View>
      <View style={styles.titleItem}>
        <Text
          style={
            !press
              ? styles.titleItemText
              : [styles.titleItemText, { color: colors.secondary }]
          }
        >
          {title}
        </Text>
      </View>
    </Pressable>
  );
};

const HomeDoc = ({ navigation }) => {
  const [userFirstName, setUserFirstName] = useState("");
  const user = useSelector(selectUser);
  const [drawerVisible, setDrawerVisible] = useState(false);
  const dispatch = useDispatch();
  console.log(`🤯🤯 ${imgUrl}${user.profilePictureUrl}`);
  const imgPressHandler = () => {
    navigation.navigate("Profile");
    // console.log("👉", "pressed");
    //TODO make a profile screen for doctor
    // dispatch(logout());
  };
  const token = useSelector(selectToken);
  const {
    data: trendQuestions,
    error: trendQuestionsError,
    isLoading: trendQuestionsLoading,
    isError: trendQuestionsIsError,
  } = useGetTrendQuestionsQuery({ token });
  const {
    data: blogs,
    isError: blogsIsError,
    error: blogsError,
    isLoading: blogsIsLoading,
  } = useGetBlogsQuery({ token, page: 1 });
  const {
    data: bookedAppointments,
    isLoading: bookedAppointmentsIsLoading,
    isSuccess: bookedAppointmentsIsSuccess,
  } = useGetAppointmentsQuery(token);

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
  console.log("👉", user);
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
  useEffect(() => {
    if (bookedAppointmentsIsSuccess) {
      console.log(
        "🚀 ~ file: HomeDoc.screen.jsx ~ line 83 ~ useEffect ~ bookedAppointments",
        bookedAppointments
      );
    }
  }, [bookedAppointmentsIsSuccess]);
  console.log(trendQuestions);
  return (
    <BgContainer>
      <TopHeader
        onPress={() => {
          setDrawerVisible(true);
        }}
        onPressImg={imgPressHandler}
        userImg={`${imgUrl}${user.profilePictureUrl}`}
      />
      <Modal
        coverScreen={false}
        backdropColor={"#000"}
        style={{
          maxWidth: "70%",
          backgroundColor: colors.light,
          margin: 0,
          padding: 0,

          flex: 1,
          justifyContent: "flex-start",
        }}
        animationIn="slideInLeft"
        animationOut="slideOutLeft"
        // hasBackdrop={false}
        onBackdropPress={() => setDrawerVisible(false)}
        isVisible={drawerVisible}
      >
        <View style={styles.topContainer}>
          <CharImg
            source={{ uri: `${imgUrl}${user.profilePictureUrl}` }}
            style={styles.img}
          />
          <Text style={styles.header}>{user.fullName}</Text>
        </View>

        <View
          style={[
            {
              flex: 0.3,
              // borderColor: "red",
              // borderWidth: 1,
              justifyContent: "space-between",
            },
            styles.bottomContainer,
          ]}
        >
          <ItemRow
            onPress={() => {
              navigation.navigate("Blogs");
              setDrawerVisible(false);
            }}
            icon={<Entypo name="pencil" size={24} color={colors.secondary} />}
            title="Write Blog"
          />
          <ItemRow
            icon={
              <Ionicons name="settings" size={24} color={colors.secondary} />
            }
            title="Settings"
          />
          <ItemRow
            icon={
              <MaterialIcons name="info" size={24} color={colors.secondary} />
            }
            title="DiagnoseMe"
          />
          <Button
            labelStyle={{
              color: colors.light,
              fontFamily: "Poppins",
            }}
            icon="door"
            buttonColor={colors.secondary}
            style={{ width: "50%", alignSelf: "center", marginTop: 40 }}
            // icon={"pen"}
          >
            Logout
          </Button>
          {/* <TouchableOpacity
            onPress={() => {
              navigation.navigate("Blogs");
              setDrawerVisible(false);
            }}
          >
            <Text>⭐ Blog</Text>
          </TouchableOpacity>
          <TouchableOpacity
            onPress={() => {
              navigation.navigate("Blogs");
              setDrawerVisible(false);
            }}
          >
            <Text>⭐ Blog</Text>
          </TouchableOpacity>
          <TouchableOpacity
            onPress={() => {
              navigation.navigate("Blogs");
              setDrawerVisible(false);
            }}
          >
            <Text>⭐ Blog</Text>
          </TouchableOpacity> */}
        </View>
      </Modal>
      <ScrollView>
        <HeaderContainer>
          <Hello>Hi, Dr. {user.name}</Hello>
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
          <TitleSeeAll title="Today Meetings " showSeeAll={false} />
          <CardsSection
            contentContainerStyle={{
              // paddingTop: 10,
              // paddingBottom: 10,
              // paddingLeft: 4,
              // paddingRight: 4,
              borderColor: "red",
              borderWidth: 1,
            }}
          >
            {bookedAppointmentsIsLoading ? (
              <ActivityIndicator
                animating={bookedAppointmentsIsLoading}
                color={colors.secondary}
                style={{
                  flex: 1,
                  alignSelf: "center",
                  justifySelf: "center",
                }}
              />
            ) : bookedAppointments?.objects?.length > 0 ? (
              bookedAppointments
                ?.filter(
                  (m) =>
                    format(new Date(m.start_date), "yyyy-MM-dd") ===
                    format(new Date(), "yyyy-MM-dd")
                )
                ?.map((t) => (
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
                        <PatientImg
                          source={
                            t.patient.pic
                              ? { uri: t.patient.pic }
                              : require("../../../../assets/characters/male.png")
                          }
                        />
                        <Time>{format(new Date(t.start_date), "hh:mm a")}</Time>
                      </UpperSectionMeeting>
                      <Name>{t.patient.name}</Name>
                    </MeetingCard>
                  </View>
                ))
            ) : (
              <>
                <NoMeetingContainer
                  style={{
                    // borderColor: "red",
                    // borderWidth: 1,
                    width: 320,
                    height: 200,
                  }}
                >
                  <NoMeetingImg
                    source={require("../../../../assets/helpers/no_meeting_2.png")}
                  />
                  <NoMeetingTitle>No Booked Meetings Today</NoMeetingTitle>
                </NoMeetingContainer>
              </>
            )}
          </CardsSection>
        </TodayMeetings>
        <TrendQuestionsSection>
          <CategoriesSection>
            <TitleSeeAll
              title="Trend Questions❓"
              pressFunction={() =>
                navigation.navigate("Questions", {
                  screen: "MainQuestion",
                })
              }
            />
            <CardsSection>
              {trendQuestionsLoading ? (
                <ActivityIndicator
                  animating={trendQuestionsLoading}
                  color={theme.colors.primary}
                  style={{
                    flex: 1,
                    alignSelf: "center",
                    justifySelf: "center",
                  }}
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
          <TrendQuestionsSection>
            <CategoriesSection>
              <TitleSeeAll
                title="Blogs 📓"
                pressFunction={() => navigation.navigate("Blogs")}
              />
              <CardsSection>
                {blogsIsLoading ? (
                  <ActivityIndicator
                    animating={trendQuestionsLoading}
                    color={theme.colors.primary}
                    style={{
                      flex: 1,
                      alignSelf: "center",
                      justifySelf: "center",
                    }}
                  />
                ) : (
                  blogs?.objects.map((blog) => (
                    <BlogCard
                      onPress={() =>
                        navigation.navigate("Home", {
                          screen: "BlogPage",
                          params: { blogId: blog?.id },
                        })
                      }
                      key={blog?.id}
                      blog={blog}
                      total={6}
                      index={blog?.id}
                    />
                  ))
                )}
              </CardsSection>
            </CategoriesSection>
          </TrendQuestionsSection>
        </Spacer>
      </ScrollView>
    </BgContainer>
  );
};
export default HomeDoc;
const styles = StyleSheet.create({
  img: {
    height: 100,
    width: 100,
    borderRadius: 100,
    alignSelf: "center",
    borderColor: colors.light,
    borderWidth: 2,
  },
  topContainer: {
    backgroundColor: colors.secondary,
    flex: 1,
    justifyContent: "center",
  },
  bottomContainer: {
    flex: 2,
    justifyContent: "flex-start",
  },
  header: {
    fontFamily: "Poppins",
    fontSize: 20,
    color: colors.light,
    textAlign: "center",
    marginTop: 10,
  },
  subHeader: {
    fontFamily: "Poppins",
    fontSize: 15,
  },
  itemContainer: {
    // borderColor: "red",
    // borderWidth: 1,
    flexDirection: "row",
    paddingLeft: 24,
    paddingTop: 16,
    alignItems: "center",
    marginTop: 8,
  },
  titleItem: {
    paddingLeft: 16,
  },
  titleItemText: {
    fontFamily: "Poppins",
  },
});
