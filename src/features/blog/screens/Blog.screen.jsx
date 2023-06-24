import { Appbar } from "react-native-paper";
import { Alert, View } from "react-native";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import { useEffect, useState } from "react";
import { useGetBlogQuery } from "../../../services/apis/blogs.api";
import { useSelector } from "react-redux";
import { selectToken } from "../../../services/slices/auth.slice";
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
const Blog = ({ navigation, route }) => {
  const { blogId } = route.params;
  console.log("💔inside blog screen ", blogId);
  const token = useSelector(selectToken);
  const {
    data: blog,
    isLoading,
    isError,
    error,
  } = useGetBlogQuery({ token, blogId });
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
  return (
    <BgContainer>
      <Appbar.Header>
        <Appbar.BackAction
          color={colors.primary}
          onPress={() => {
            navigation.goBack();
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
                    ? blog?.author.profilePictureUrl
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

            <BlogImg
              source={
                blog?.postImages[0]
                  ? blog?.postImages[0]
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
              <LikesContainer>
                <Likes>{blog?.averageRate}</Likes>

                <View
                  style={{
                    justifyContent: "center",
                  }}
                >
                  <Rating
                    stars={blog.averageRate}
                    maxStars={5}
                    size={32}
                    rating={rating}
                    setRating={setRating}
                  />
                </View>
              </LikesContainer>
              <SocialIcons>
                <Facebook />
                <Twitter />
                <LinkedIn />
              </SocialIcons>
            </Wrapper>
            <View
              style={{
                width: "90%",
                marginTop: 8,
              }}
            >
              <CategoryList>
                {blog?.tags?.map((cat, i) => (
                  <CategoryItem key={i}>{cat}</CategoryItem>
                ))}
              </CategoryList>
            </View>
          </Container>
        )}
      </View>
    </BgContainer>
  );
};
export default Blog;
