import { useNavigation } from "@react-navigation/native";
import {
  BlogCard,
  BlogTitle,
  CategoryItem,
  CategoryList,
  Container,
  Date as DateComponent,
  DocData,
  DocImg,
  DocInfo,
  Img,
  Info,
  Name,
  ReadMoreBtn,
  Specialty,
} from "../styles/BlogSection.styles";
import { ActivityIndicator, Button, Searchbar } from "react-native-paper";
import { useEffect, useState } from "react";
import { useGetBlogsQuery } from "../../services/apis/blogs.api";
import { useSelector } from "react-redux";
import { selectToken } from "../../services/slices/auth.slice";
import { Alert, View } from "react-native";
import colors from "../../infrastructure/theme/colors";
import theme from "../../infrastructure/theme";
import { formatDistanceToNow } from "date-fns";
import { imgUrl } from "../../services/apiEndPoint";
import { Text } from "react-native";
const BlogSection = () => {
  const navigation = useNavigation();
  const [searchQuery, setQuery] = useState("");
  const token = useSelector(selectToken);
  const [page, setPage] = useState(1);
  const [loading, setLoading] = useState(true);
  const {
    data: blogs,
    isError: blogsIsError,
    error: blogsError,
    isLoading: blogsIsLoading,
    isSuccess,
  } = useGetBlogsQuery({ token, page });
  useEffect(() => {
    if (blogsIsError) {
      Alert.alert("Error", "Something Went Wrong" + blogsError?.message, [
        {
          text: "Cancel",
          onPress: () => console.log("Cancel Pressed"),
          style: "cancel",
        },
        { text: "OK", onPress: () => console.log("OK Pressed") },
      ]);
    }
  }, [blogsIsError]);
  useEffect(() => {
    console.log("🤯🤯", blogs.objects[0]);
  }, [isSuccess]);
  const handlePagination = (type) => {
    setPage((prev) => (type === "add" ? prev + 1 : prev - 1));
  };
  return (
    <View>
      <Searchbar
        placeholder="Search for Blogs you need"
        value={searchQuery}
        style={{
          width: "90%",
          alignSelf: "center",
          borderRadius: 32,
          backgroundColor: colors.light,
          fontFamily: "Poppins",
        }}
      />
      <Container>
        {blogsIsLoading ? (
          <ActivityIndicator
            animating={blogsIsLoading}
            color={theme.colors.primary}
          />
        ) : (
          <>
            {blogs?.objects.map((b) => (
              <BlogCard
                style={{
                  elevation: 2,
                }}
                key={b.id}
              >
                {loading && <Text>loading....</Text>}
                <Img
                  style={{ borderColor: colors.secondary, borderWidth: 2 }}
                  source={
                    b?.postImages[0]
                      ? { uri: imgUrl + b.postImages[0] }
                      : require("../../../assets/helpers/blog_1.png")
                  }
                  onLoad={() => setLoading(false)}
                />
                <Info>
                  <CategoryList>
                    {b?.tags.slice(0, 2).map((cat, i) => (
                      <CategoryItem key={i}>{cat}</CategoryItem>
                    ))}
                  </CategoryList>
                  <DateComponent>
                    {
                      b.modifiedOn
                        ? formatDistanceToNow(new Date(b.modifiedOn), {
                            addSuffix: true,
                          })
                        : // ?.split("about")[1]
                          // ?.trim()
                          b?.createdOn &&
                          formatDistanceToNow(new Date(b.createdOn), {
                            addSuffix: true,
                          })
                      // ?.split("about")[1]
                      // ?.trim()
                    }
                  </DateComponent>
                </Info>
                <BlogTitle>{b?.title}</BlogTitle>
                <DocInfo>
                  <DocImg
                    source={
                      b?.author?.profilePictureUrl
                        ? { uri: imgUrl + b?.author?.profilePictureUrl }
                        : require("../../../assets/characters/doctor_4.png")
                    }
                  />
                  <DocData>
                    <Name>{"Dr. " + b?.author.fullName}</Name>
                    <Specialty>
                      {b?.author.specialization
                        ? b?.author.specialization
                        : "specialty"}
                    </Specialty>
                  </DocData>
                  <ReadMoreBtn
                    onPress={() =>
                      navigation.navigate("Home", {
                        screen: "BlogPage",
                        params: { blogId: b.id },
                      })
                    }
                  >
                    Read More
                  </ReadMoreBtn>
                </DocInfo>
              </BlogCard>
            ))}
            {
              <View
                style={{
                  flexDirection: "row",
                  // width: "50%",
                  justifyContent: "center",
                  marginBottom: 6,
                }}
              >
                <Button
                  mode="outlined"
                  onPress={() => handlePagination("minus")}
                  textColor={colors.secondary}
                  disabled={page === 1}
                  style={{ marginRight: 8 }}
                >
                  Prev
                </Button>
                <Button
                  mode="outlined"
                  onPress={() => handlePagination("add")}
                  textColor={colors.secondary}
                  loading={blogsIsLoading}
                  disabled={!blogs?.isNextPage}
                >
                  next
                </Button>
              </View>
            }
          </>
        )}
      </Container>
    </View>
  );
};
export default BlogSection;
