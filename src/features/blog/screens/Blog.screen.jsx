import { Appbar, Button } from "react-native-paper";
import { Alert, Text, View } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { useEffect, useState } from "react";
import {
  useGetBlogQuery,
  useMakeRateBlogMutation,
} from "../../../services/apis/blogs.api";
import { useSelector } from "react-redux";
import { selectToken, selectUser } from "../../../services/slices/auth.slice";
import { ActivityIndicator, Divider } from "react-native-paper";
import {
  BlogImg,
  Container,
  Content,
  Date,
  DocData,
  Facebook,
  Img,
  Info,
  LikeIcon,
  Likes,
  LikesContainer,
  LinkedIn,
  Name,
  SocialIcons,
  Specialty,
  Title,
  Twitter,
  UnLikeIcon,
  Wrapper,
} from "../../styles/BlogContent.styles";
import { CategoryItem, CategoryList } from "../../styles/BlogSection.styles";
import { Rating, RatingInput } from "react-native-stock-star-rating";
import theme from "../../../infrastructure/theme";
import Modal from "react-native-modal";
import { StyleSheet } from "react-native";
import { imgUrl } from "../../../services/apiEndPoint";

const Blog = ({ navigation, route }) => {
  const [showRateModal, setShowRateModal] = useState(false);
  const { blogId } = route.params;
  const user = useSelector(selectUser);
  const token = useSelector(selectToken);
  const {
    data: blog,
    isLoading,
    isError,
    error,
  } = useGetBlogQuery({ token, blogId });
  const [
    makeRate,
    {
      isSuccess: makeRateIsSuccess,
      isLoading: makeRateIsLoading,
      isError: makeRateIsError,
    },
  ] = useMakeRateBlogMutation();
  // const [makeRate, { isLoading: isRatingLoading }] = use();
  const [rating, setRating] = useState(0);
  useEffect(() => {
    if (isError) {
      Alert.alert(
        "error",
        "Something wrong" + error.message,
        { text: "ok" },
        { cancelable: false }
      );
    }
  }, [isError]);
  useEffect(() => {
    if (makeRateIsSuccess) {
      setShowRateModal(false);

      navigation.goBack();
    }
  }, [makeRateIsSuccess]);
  useEffect(() => {
    if (makeRateIsError) {
      Alert.alert("try again");
    }
  }, [makeRateIsError]);
  console.log(blog);
  return (
    <>
      <Modal
        isVisible={showRateModal}
        style={styles.modal}
        coverScreen={false}
        backdropColor={"#0000007b"}
        animationIn="slideInLeft"
        animationOut="slideOutLeft"
        onBackdropPress={() => setShowRateModal(false)}
      >
        <Text style={styles.header}>Leave A Rate for the blog</Text>
        <RatingInput
          setRating={setRating}
          onRating={() => console.log("rate")}
          rating={rating}
        />
        <Button
          mode="contained"
          buttonColor={colors.secondary}
          textColor={colors.light}
          style={styles.btn}
          onPress={() => {
            //TODO: makeRate post request here
            //TODO: if success navigateBack to main blogs screen
            //TODO: if error show error message
            //TODO: disallow this model for the doctor who make the blog
            makeRate({ token, postId: blog.id, rating });
          }}
          labelStyle={{ fontFamily: "Poppins" }}
          loading={makeRateIsLoading}
          disabled={makeRateIsLoading}
        >
          OK
        </Button>
      </Modal>
      <BgContainer>
        <Appbar.Header>
          <Appbar.BackAction
            color={colors.primary}
            onPress={() => {
              if (user.id === blog?.author?.id) {
                navigation.goBack();
              } else {
                setShowRateModal(true);
              }
            }}
          />
        </Appbar.Header>
        <View>
          {isLoading ? (
            <ActivityIndicator
              animating={isLoading}
              color={theme.colors.primary}
            />
          ) : (
            <Container>
              <Title>{blog?.title}</Title>
              <DocData>
                <Img
                  source={
                    blog?.author.profilePictureUrl
                      ? { uri: imgUrl + blog?.author.profilePictureUrl }
                      : require("../../../../assets/characters/doctor_male_1.png")
                  }
                />
                <Info>
                  <Name>{"Dr. " + blog?.author.fullName}</Name>
                  <Specialty>{blog?.author.specialization}</Specialty>
                  <Date>
                    {blog?.modifiedOn ? blog?.modifiedOn : blog?.createdOn}
                  </Date>
                </Info>
              </DocData>
              <LikesContainer>
                <View
                  style={{
                    flexDirection: "row",
                    alignItems: "center",
                    justifyContent: "center",
                  }}
                >
                  <Likes
                    style={{ marginTop: 8, color: colors.primary }}
                  >{`(${blog?.averageRate})`}</Likes>
                  <Rating
                    stars={blog.averageRate}
                    maxStars={5}
                    size={32}
                    rating={rating}
                    setRating={setRating}
                    color={colors.secondary}
                  />
                </View>
              </LikesContainer>
              <BlogImg
                source={
                  blog?.postImages[0]
                    ? { uri: imgUrl + blog?.postImages[0] }
                    : require("../../../../assets/helpers/blog_1.png")
                }
              />
              <Content>{blog?.content}</Content>
              <Wrapper
                style={{
                  borderTopWidth: 1,
                  borderTopColor: colors.primary,
                }}
              >
                <View
                  style={
                    {
                      // width: "90%",
                      // marginTop: 8,
                    }
                  }
                >
                  <CategoryList>
                    {blog?.tags?.map((cat, i) => (
                      <CategoryItem key={i}>{cat}</CategoryItem>
                    ))}
                  </CategoryList>
                </View>
                {/* <SocialIcons>
                  <Facebook />
                  <Twitter />
                  <LinkedIn />
                </SocialIcons> */}
              </Wrapper>
            </Container>
          )}
        </View>
      </BgContainer>
    </>
  );
};
export default Blog;
const styles = StyleSheet.create({
  modal: {
    backgroundColor: "white",
    maxHeight: 250,
    width: "80%",
    alignSelf: "center",
    padding: 16,
    borderRadius: 8,
    alignItems: "center",
  },
  header: {
    fontSize: 20,
    fontFamily: "Poppins",
    color: colors.primary,
  },
  btn: {
    marginTop: 16,
    width: "50%",
    alignSelf: "center",
  },
});
