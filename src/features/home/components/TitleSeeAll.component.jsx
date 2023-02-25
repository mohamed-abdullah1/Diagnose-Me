import { Btn, Content, Title, Wrapper } from "../styles/TitleSeeAll.styles";

const TitleSeeAll = ({ pressFunction, title }) => {
    return (
        <Wrapper>
            <Title>{title}</Title>
            <Btn onPress={pressFunction}>
                <Content>See All</Content>
            </Btn>
        </Wrapper>
    );
};
export default TitleSeeAll;
