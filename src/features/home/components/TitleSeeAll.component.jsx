import { Btn, Content, Title, Wrapper } from "../styles/TitleSeeAll.styles";

const TitleSeeAll = ({ navigationObj, navigationTo, title }) => {
    return (
        <Wrapper>
            <Title>{title}</Title>
            <Btn onPress={() => console.log("f")}>
                <Content>See All</Content>
            </Btn>
        </Wrapper>
    );
};
export default TitleSeeAll;
