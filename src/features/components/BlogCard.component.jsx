import { AntDesign } from "@expo/vector-icons";
import { useState } from "react";
import { TouchableOpacity } from "react-native";
import styled from "styled-components/native";
import Card from "./Card.component";

const Content = styled.Text`
  font-size: 13px;
  font-family: "Poppins";
  color: ${(props) => props.theme.colors.blue};
`;
const LeftWrapper = styled.View`
  flex-direction: row;
  margin-left: 5px;
`;
const Icon = styled(AntDesign).attrs((props) => ({
  name: props.liked ? "heart" : "hearto",
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
  return (
    <Card
      onPress={onPress}
      total={total}
      index={index}
      img={blog.author.profilePictureUrl}
      name={blog.author.fullName}
      date={blog.modifiedOn ? blog.modifiedOn : blog.createdOn}
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
