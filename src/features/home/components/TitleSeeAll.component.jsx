import { Btn, Content, Title, Wrapper } from "../styles/TitleSeeAll.styles";

const TitleSeeAll = ({ pressFunction, title, showSeeAll = true }) => {
    return (
        <Wrapper>
            <Title>{title}</Title>
            {showSeeAll ? (
                <Btn onPress={pressFunction}>
                    <Content>See All</Content>
                </Btn>
            ) : null}
        </Wrapper>
    );
};
export default TitleSeeAll;
