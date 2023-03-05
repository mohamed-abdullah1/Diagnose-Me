import { useState } from "react";
import { View } from "react-native";
import { TouchableOpacity } from "react-native-gesture-handler";
import { Divider } from "react-native-paper";
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

const BlogContent = ({ blog }) => {
    const [liked, setLiked] = useState(false);
    const {
        doctorImg,
        title,
        doctorName,
        specialty,
        date,
        content,
        likes,
        imgBlog,
        categoryList,
    } = blog;
    return (
        <Container>
            <Title>{title}</Title>
            <DocData>
                <Img source={doctorImg} />
                <Info>
                    <Name>{"Dr. " + doctorName}</Name>
                    <Specialty>{specialty}</Specialty>
                    <Date>{date + " ago"}</Date>
                </Info>
            </DocData>

            <BlogImg source={imgBlog} />
            <Content>{content}</Content>
            <Wrapper
                style={{
                    borderTopWidth: 1,
                    borderTopColor: colors.primary,
                }}
            >
                <LikesContainer>
                    <Likes>{likes}</Likes>
                    <TouchableOpacity onPress={() => setLiked((prev) => !prev)}>
                        {liked ? <LikeIcon /> : <UnLikeIcon />}
                    </TouchableOpacity>
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
                    {categoryList.map((cat, i) => (
                        <CategoryItem key={i}>{cat}</CategoryItem>
                    ))}
                </CategoryList>
            </View>
        </Container>
    );
};
export default BlogContent;
