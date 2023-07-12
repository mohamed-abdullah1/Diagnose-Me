import { AntDesign, FontAwesome } from "@expo/vector-icons";
import { useState } from "react";
import { TouchableOpacity } from "react-native";
import styled from "styled-components/native";
import Card from "./Card.component";
import { formatDistanceToNow } from "date-fns";

const Content = styled.Text`
  font-size: 13px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.blue};
`;
const LeftWrapper = styled.View`
  flex-direction: row;
  margin-left: 5px;
`;
const Icon = styled(FontAwesome).attrs((props) => ({
  name: props.liked ? "star" : "star",
  size: 24,
  color: props.liked ? "red" : props.theme.colors.primary,
}))``;
const Value = styled.Text`
  font-size: 15px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.primary};
  margin-left: 5px;
`;

const BottomLeft = ({ value, liked, setLiked }) => (
  <LeftWrapper>
    <TouchableOpacity onPress={() => setLiked((prev) => !prev)}>
      <Icon liked={liked} />
    </TouchableOpacity>
    <Value>{value}</Value>
  </LeftWrapper>
);
const BlogCard = ({ blog, index, total, onPress }) => {
  const [liked, setLiked] = useState(false);
  console.log("blog.author.profilePictureUrl", blog.author.profilePictureUrl);
  return (
    <Card
      onPress={onPress}
      total={total}
      index={index}
      img={blog.author.profilePictureUrl}
      name={blog.author.fullName}
      // date={blog.modifiedOn ? blog.modifiedOn : blog.createdOn}
      date={
        blog.modifiedOn
          ? formatDistanceToNow(new Date(blog.modifiedOn), {
              addSuffix: true,
            })
          : // ?.split("about")[1]
            // ?.trim()
            formatDistanceToNow(new Date(blog.createdOn), {
              addSuffix: true,
            })
      }
      content={blog.content}
      height={200}
      BottomLeft={() => (
        <BottomLeft
          liked={liked}
          setLiked={setLiked}
          value={blog.averageRate}
        />
      )}
      BottomRight={() => null}
    />
  );
};
export default BlogCard;
