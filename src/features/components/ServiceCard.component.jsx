import { Img, Title, Wrapper } from "../styles/ServiceCard.styles";

const ServiceCard = ({ title, img, total = 10, index, pressFunction }) => {
  return (
    <Wrapper
      onPress={pressFunction}
      style={{
        shadowColor: "#0000006e",
        // shadowOffset: {
        //     width: -10,
        //     height: 10,
        // },
        // shadowOpacity: 0.25,
        // shadowRadius: 16,

        elevation: 5,
        // shadowColor: "#171717f",
        shadowOffset: { width: 0, height: 1 },
        shadowOpacity: 0.2,
        shadowRadius: 16,
      }}
      index={index}
      total={total}
    >
      {/* //TODO: delete false */}
      <Img source={img !== "" ? img : { uri: img }} />
      <Title>{title}</Title>
    </Wrapper>
  );
};

export default ServiceCard;
