import {
  Bottom,
  Content,
  ContentText,
  Date,
  Img,
  Name,
  Upper,
  Wrapper,
} from "../styles/Card.styles";

const Card = ({
  styles,
  total,
  index,
  width = 325,
  height = 192,
  BottomLeft = null,
  BottomRight = null,
  img,
  name,
  date = 10,
  content,
  contentTextSize,
  nameTextSize,
  imgSize,
  onPress,
  viewAllQuestion,
}) => {
  return (
    <Wrapper
      onPress={onPress}
      style={styles}
      total={total}
      index={index}
      width={width}
      height={height}
      viewAllQuestion={viewAllQuestion}
    >
      <Upper>
        <Img
          source={img ? img : require("../../../assets/characters/male.png")}
          imgSize={imgSize}
        />
        <Name nameTextSize={nameTextSize}>{name}</Name>
        <Date dateTextSize={nameTextSize}>{date}</Date>
      </Upper>
      <Content>
        <ContentText contentTextSize={contentTextSize}>
          {content?.length < 85 || viewAllQuestion
            ? content
            : content?.substring(0, 80) + "..."}
        </ContentText>
      </Content>
      <Bottom>
        <BottomLeft />
        <BottomRight />
      </Bottom>
    </Wrapper>
  );
};

export default Card;
