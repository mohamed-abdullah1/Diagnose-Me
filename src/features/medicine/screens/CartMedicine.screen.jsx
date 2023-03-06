import { Appbar, Button } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import {
    Btn,
    Container,
    Count,
    CountContainer,
    DeleteContainer,
    DeleteIcon,
    Img,
    InfoContainer,
    MinusIcon,
    PlusIcon,
    Price,
    ProductCard,
    Title,
} from "../styles/CartMedicine.styles";
import { cart } from "../../../helpers/consts";
import { useEffect, useState } from "react";
import { FontAwesome, Ionicons } from "@expo/vector-icons";

const CartMedicine = ({ navigation }) => {
    const [products, setProducts] = useState([]);
    useEffect(() => {
        setProducts(cart);
    }, []);
    return (
        <BgContainer>
            <Appbar.Header>
                <Appbar.BackAction
                    color={colors.primary}
                    onPress={() => {
                        navigation.goBack();
                    }}
                />
                <Appbar.Content
                    title="Cart 🛒"
                    titleStyle={{
                        color: colors.primary,
                        fontFamily: "PoppinsBold",
                    }}
                />
            </Appbar.Header>
            <Container>
                {products?.map((p) => (
                    <ProductCard key={p.id} style={{ elevation: 8 }}>
                        <Img source={p.medicineImg} />
                        <InfoContainer>
                            <Title>{p.title}</Title>
                            <CountContainer>
                                <Ionicons
                                    name="add-circle-sharp"
                                    size={24}
                                    color={colors.secondary}
                                />
                                <Count>{p.count}</Count>
                                <FontAwesome
                                    name="minus-circle"
                                    size={24}
                                    color={colors.secondary}
                                />
                            </CountContainer>
                        </InfoContainer>
                        <DeleteContainer>
                            <Ionicons
                                name="trash-bin"
                                size={24}
                                color={colors.red}
                            />
                            <Price>{p.price * p.count + ".00 LE"}</Price>
                        </DeleteContainer>
                    </ProductCard>
                ))}
            </Container>
        </BgContainer>
    );
};
export default CartMedicine;
