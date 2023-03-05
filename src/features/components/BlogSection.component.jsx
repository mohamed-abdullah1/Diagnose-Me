import { useNavigation } from "@react-navigation/native";
import {
    BlogCard,
    BlogTitle,
    CategoryItem,
    CategoryList,
    Container,
    Date,
    DocData,
    DocImg,
    DocInfo,
    Img,
    Info,
    Name,
    ReadMoreBtn,
    Specialty,
} from "../styles/BlogSection.styles";

const BlogSection = ({ blogs }) => {
    const navigation = useNavigation();
    console.log("㊙️", blogs);
    return (
        <Container>
            {blogs?.map((blog) => (
                <BlogCard
                    style={{
                        elevation: 6,
                    }}
                    key={blog.id}
                >
                    <Img source={blog.imgBlog} />
                    <Info>
                        <CategoryList>
                            {blog?.categoryList?.map((cat) => (
                                <CategoryItem>{cat}</CategoryItem>
                            ))}
                        </CategoryList>
                        <Date>{blog.date + " ago"}</Date>
                    </Info>
                    <BlogTitle>{blog.title}</BlogTitle>
                    <DocInfo>
                        <DocImg source={blog.doctorImg} />
                        <DocData>
                            <Name>{"Dr. " + blog.doctorName}</Name>
                            <Specialty>{blog.specialty}</Specialty>
                        </DocData>
                        <ReadMoreBtn
                            onPress={() =>
                                navigation.navigate("Home", {
                                    screen: "BlogPage",
                                    params: { blog },
                                })
                            }
                        >
                            Read More
                        </ReadMoreBtn>
                    </DocInfo>
                </BlogCard>
            ))}
        </Container>
    );
};
export default BlogSection;
