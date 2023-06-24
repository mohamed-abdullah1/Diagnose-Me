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
  specialties,
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
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { useGetTrendQuestionsQuery } from "../../../services/apis/questions.api";
import { ActivityIndicator } from "react-native-paper";
import theme from "../../../infrastructure/theme";
import { useGetBlogsQuery } from "../../../services/apis/blogs.api";
// import { selectChat } from "../../../services/slices/chat.slice";
// import { useGetChatsQuery } from "../../../services/apis/chat.api";

const Home = ({ navigation }) => {
  const [userFirstName, setUserFirstName] = useState("Mohamed");
  const [drawerVisible, setDrawerVisible] = useState(false);
  const user = useSelector(selectUser);
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
  // useEffect(() => {
  //     if (chatInfo) {
  //         getChats(chatInfo.token);
  //     }
  // }, [chatInfo]);
  // useEffect(() => {
  //     console.log("👉CHATS LENGTH: ", chats);
  //     console.log("🔥CHATS Errors: ", chatsError);
  // }, [chats, isSuccess]);
  return (
    <BgContainer>
      <TopHeader
        onPress={() => {
          setDrawerVisible(true);
        }}
        onPressImg={() => {
          navigation.navigate("Profile");
        }}
        userImg={
          user?.profilePictureUrl
            ? user?.profilePictureUrl
            : require("../../../../assets/characters/male.png")
        }
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
          <Hello>Hi, {user.fullName.split(" ")[0]}</Hello>
          <Emoji source={require("../../../../assets/helpers/emoji.png")} />
        </HeaderContainer>
        <CategoriesSection>
          <TitleSeeAll title="Specialties 📖" showSeeAll={false} />
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
          <TrendQuestionsSection>
            <CategoriesSection>
              <TitleSeeAll
                title="Blogs 📓"
                pressFunction={() => navigation.navigate("Blogs")}
              />
              <CardsSection>
                {blogs?.objects.map((blog) => (
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
                ))}
              </CardsSection>
            </CategoriesSection>
          </TrendQuestionsSection>
        </Spacer>
      </ScrollView>
    </BgContainer>
  );
};
export default Home;
