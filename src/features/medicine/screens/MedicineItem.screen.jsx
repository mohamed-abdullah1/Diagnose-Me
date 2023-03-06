import { Appbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import {
    AddBtn,
    Container,
    Content,
    Delivery,
    DeliveryContent,
    DeliveryIcon,
    Img,
    InfoTitle,
    Price,
    ProductInfo,
    SoldBy,
    SoldByContent,
    SoldByIcon,
    Title,
} from "../styles/MedicineItem.styles";

const MedicineItem = ({ navigation, route }) => {
    // console.log("👉", route.params);
    const { item: product } = route.params;
    // console.log("👉", route.params.params);
    console.log("👉", product);
    return (
        <BgContainer>
            <Appbar.Header>
                <Appbar.BackAction
                    color={colors.primary}
                    onPress={() => {
                        navigation.goBack();
                    }}
                />
            </Appbar.Header>
            <Container>
                <Img source={product?.medicineImg} />
                <Title>{product.title}</Title>
                <Price>{product.price + ".00 LE"}</Price>
                <SoldBy>
                    <SoldByIcon />
                    <SoldByContent>
                        {"Sold By: " + product.soldBy}
                    </SoldByContent>
                </SoldBy>
                <Delivery>
                    <DeliveryIcon />
                    <DeliveryContent>
                        {"Delivered Within " + product.deliveryTime + " Hour"}
                    </DeliveryContent>
                </Delivery>
                <AddBtn>Add To Cart</AddBtn>
                <ProductInfo
                    style={{
                        borderTopColor: colors.primary,
                        borderTopWidth: 1,
                    }}
                >
                    <InfoTitle>Product Details</InfoTitle>
                    <Content>{product.details}</Content>
                </ProductInfo>
            </Container>
        </BgContainer>
    );
};
export default MedicineItem;
