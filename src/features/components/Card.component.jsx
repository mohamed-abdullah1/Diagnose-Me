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
}) => {
    return (
        <Wrapper
            onPress={onPress}
            style={styles}
            total={total}
            index={index}
            width={width}
            height={height}
        >
            <Upper>
                <Img source={img} imgSize={imgSize} />
                <Name nameTextSize={nameTextSize}>{name}</Name>
                <Date dateTextSize={nameTextSize}>{date}</Date>
            </Upper>
            <Content>
                <ContentText contentTextSize={contentTextSize}>
                    {content?.substring(0, 100)}
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
