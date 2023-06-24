import { useState } from "react";
import { View } from "react-native";
import { TouchableOpacity } from "react-native-gesture-handler";
import { ActivityIndicator, Divider } from "react-native-paper";
import colors from "../../infrastructure/theme/colors";
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
} from "../styles/BlogContent.styles";
import { CategoryItem, CategoryList } from "../styles/BlogSection.styles";
import { Rating, RatingInput } from "react-native-stock-star-rating";
import theme from "../../infrastructure/theme";
import { useEffect } from "react";
import { useGetSingleBlogQuery } from "../../services/apis/blogs.api";
import { useSelector } from "react-redux";
import { selectToken } from "../../services/slices/auth.slice";

const BlogContent = ({ blogId }) => {
  const token = useSelector(selectToken);
  const {
    data: blog,
    isLoading,
    isError,
    error,
  } = useGetSingleBlogQuery({ token, blogId });
  const [rating, setRating] = useState(0);
  console.log("👁️🦺", blog);
  useEffect(() => {
    if (isError) {
      console.log("🍎🦺", error.message);
    }
  }, [isError]);
  return (
    <View>
      {isLoading ? (
        <ActivityIndicator animating={isLoading} color={theme.colors.primary} />
      ) : (
        <Container>
          <Title>{blog?.title}</Title>
          <DocData>
            <Img
              source={
                blog?.author.profilePictureUrl
                  ? blog?.author.profilePictureUrl
                  : require("../../../assets/characters/doctor_male_1.png")
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
                : require("../../../assets/helpers/blog_1.png")
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
                <RatingInput
                  stars={blog?.averageRate}
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
  );
};
export default BlogContent;
