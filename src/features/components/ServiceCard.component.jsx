import { Img, Title, Wrapper } from "../styles/ServiceCard.styles";

const ServiceCard = ({ title, img, total = 10, index }) => {
    return (
        <Wrapper index={index} total={total}>
            <Img source={img} />
            <Title>{title}</Title>
        </Wrapper>
    );
};

export default ServiceCard;
