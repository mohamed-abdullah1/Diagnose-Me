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
  TrendQuestionsSection,
} from "../styles/Global.styles";
import {
  blogs,
  doctors,
  services,
  specialties as xSpecialties,
  // trendQuestions,
} from "../../../helpers/consts";
import ServiceCard from "../../components/ServiceCard.component";
import DoctorCard from "../../components/DoctorCard.component";
import {
  Alert,
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
import { useDispatch, useSelector } from "react-redux";
import {
  logout,
  selectToken,
  selectUser,
} from "../../../services/slices/auth.slice";
import { useGetTrendQuestionsQuery } from "../../../services/apis/questions.api";
import { ActivityIndicator, Button } from "react-native-paper";
import theme from "../../../infrastructure/theme";
import { useGetBlogsQuery } from "../../../services/apis/blogs.api";
import {
  useGetPopularDoctorsQuery,
  useGetSpecialtiesQuery,
  usePopularDoctorsQuery,
} from "../../../services/apis/medicalService";
import { imgUrl } from "../../../services/apiEndPoint";
import { Pressable } from "react-native";
import { CharImg } from "../../styles/TopHeader.styles";
import { Entypo, Ionicons, MaterialIcons } from "@expo/vector-icons";
import { StyleSheet } from "react-native";

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

const Home = ({ navigation }) => {
  const [userFirstName, setUserFirstName] = useState("Mohamed");
  const [drawerVisible, setDrawerVisible] = useState(false);
  const user = useSelector(selectUser);
  const token = useSelector(selectToken);
  const dispatch = useDispatch();

  const {
    data: popularDoctors,
    isLoading: popularDoctorsIsLoading,
    isError: popularDoctorsIsError,
    error: popularDoctorsError,
  } = usePopularDoctorsQuery({ token });
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
    isFetching: blogsIsFetching,
  } = useGetBlogsQuery({ token, page: 1 });
  const {
    data: specialties,
    error: specialtyError,
    loading: specialtyIsLoading,
  } = useGetSpecialtiesQuery({ token, page: 1 });
  // const chatInfo = useSelector(selectChat);
  // const {
  //     data: chats,
  //     error: chatsError,
  //     isSuccess,
  // } = useGetChatsQuery(chatInfo.token);
  console.log("👉 HOME SCREEN: ", user);
  console.log("👉 HOME SCREEN: ", token);
  // console.log("👉HOME SCREEN: ", chatInfo);

  useFocusEffect(
    useCallback(() => {
      navigation.getParent().setOptions({
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
  const seeAllDoctorsHandler = () => {
    navigation.navigate({
      name: "Doctors",
      params: {
        category: "all",
      },
    });
  };
  const specialtyHandler = (value) =>
    navigation.navigate({
      name: "Doctors",
      params: {
        category: value,
      },
    });
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
  const logoutHandler = () => {
    dispatch(logout());
  };
  // useEffect(() => {
  //     if (chatInfo) {
  //         getChats(chatInfo.token);
  //     }
  // }, [chatInfo]);
  // useEffect(() => {
  //     console.log("👉CHATS LENGTH: ", chats);
  //     console.log("🔥CHATS Errors: ", chatsError);
  // }, [chats, isSuccess]);
  console.log("specialties: ", specialties);
  return (
    <BgContainer>
      <TopHeader
        onPress={() => {
          setDrawerVisible(true);
        }}
        onPressImg={() => {
          navigation.navigate("Profile");
        }}
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
              navigation.navigate("Questions", { screen: "MainQuestion" });
              setDrawerVisible(false);
            }}
            icon={<Ionicons name="earth" size={24} color={colors.secondary} />}
            title="Questions"
          />
          <ItemRow
            onPress={() => {
              navigation.navigate("Blogs");
              setDrawerVisible(false);
            }}
            icon={<Entypo name="book" size={24} color={colors.secondary} />}
            title="Blogs"
          />
          <ItemRow
            onPress={() => {
              navigation.navigate("Profile");
              setDrawerVisible(false);
            }}
            icon={
              <Ionicons name="settings" size={24} color={colors.secondary} />
            }
            title="Settings"
          />
          <ItemRow
            onPress={() => {
              navigation.navigate("Messages", { screen: "MainChat" });
              setDrawerVisible(false);
            }}
            icon={
              <Ionicons
                name="chatbox-sharp"
                size={24}
                color={colors.secondary}
              />
            }
            title="Chats"
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
            onPress={logoutHandler}
          >
            Logout
          </Button>
        </View>
      </Modal>
      <ScrollView contentContainerStyle={{}}>
        {specialtyIsLoading ||
        blogsIsLoading ||
        trendQuestionsLoading ||
        popularDoctorsIsLoading ? (
          <ActivityIndicator
            animating={
              specialtyIsLoading ||
              blogsIsLoading ||
              trendQuestionsLoading ||
              popularDoctorsIsLoading
            }
            color={theme.colors.primary}
            style={{
              flex: 1,
              justifyContent: "center",
              alignItems: "center",
              height: "100%",
            }}
          />
        ) : (
          <>
            <HeaderContainer>
              <Hello>Hi, {user.fullName.split(" ")[0]}</Hello>
              <Emoji source={require("../../../../assets/helpers/emoji.png")} />
            </HeaderContainer>
            {specialties?.length > 0 && (
              <CategoriesSection>
                <TitleSeeAll title="Specialties 📖" showSeeAll={false} />
                <CardsSection>
                  {specialtyIsLoading ? (
                    <ActivityIndicator
                      animating={specialtyIsLoading}
                      color={theme.colors.primary}
                      style={{
                        flex: 1,
                        justifyContent: "center",
                        alignItems: "center",
                      }}
                    />
                  ) : (
                    specialties?.map(({ key, value, src }) => (
                      <ServiceCard
                        pressFunction={() => specialtyHandler(value)}
                        total={specialties?.length}
                        key={key}
                        title={value}
                        img={xSpecialties.find((e) => e.value === value)?.src}
                        index={key}
                      />
                    ))
                  )}
                </CardsSection>
              </CategoriesSection>
            )}
            <DoctorsSection>
              <TitleSeeAll
                pressFunction={seeAllDoctorsHandler}
                title="Popular Doctors 🌟"
              />
              <CardsSection>
                {popularDoctorsIsLoading ? (
                  <ActivityIndicator
                    animating={popularDoctorsIsLoading}
                    color={theme.colors.primary}
                    style={{
                      flex: 1,
                      justifyContent: "center",
                      alignItems: "center",
                    }}
                  />
                ) : (
                  popularDoctors?.map((doctor) => (
                    <DoctorCard
                      key={doctor.id}
                      doctor={doctor}
                      index={doctor.id}
                      total={
                        popularDoctors?.length < 10
                          ? popularDoctors?.length
                          : 10
                      }
                    />
                  ))
                )}
              </CardsSection>
            </DoctorsSection>
            <CategoriesSection>
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
            </CategoriesSection>
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
                    {blogsIsLoading || blogsIsFetching ? (
                      <ActivityIndicator
                        animating={trendQuestionsLoading}
                        color={theme.colors.primary}
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
          </>
        )}
      </ScrollView>
    </BgContainer>
  );
};
export default Home;
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
