import { useEffect, useState } from "react";
import { FlatList, TouchableOpacity } from "react-native";
import { Appbar, Badge, Searchbar } from "react-native-paper";
import colors from "../../../infrastructure/theme/colors";
import { BgContainer } from "../../home/styles/Global.styles";
import {
    medicines as loadedMedicines,
    medicineCategories as loadedCategories,
} from "../../../helpers/consts";
import {
    AddBtn,
    CategoriesContainer,
    CategoryItem,
    Img,
    MedicineCard,
    Title,
} from "../styles/MedicineMain.styles";

const MedicineMain = ({ navigation }) => {
    const [searchQuery, setSearchQuery] = useState("");
    const [medicines, setMedicines] = useState([]);
    const [category, setCategory] = useState("All");
    useEffect(() => {
        setMedicines(loadedMedicines);
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
                    title="Medicine 💊"
                    titleStyle={{
                        color: colors.primary,
                        fontFamily: "PoppinsBold",
                    }}
                />
                <Badge
                    size={20}
                    style={{
                        position: "absolute",
                        top: 10,
                        right: 10,
                        backgroundColor: colors.secondary,
                        color: colors.light,
                    }}
                >
                    {2}
                </Badge>
                <Appbar.Action
                    icon="cart-outline"
                    size={30}
                    color={colors.secondary}
                    onPress={() => {
                        navigation.navigate("Cart");
                    }}
                />
            </Appbar.Header>
            <Searchbar
                placeholder="Search for Medicine you need"
                value={searchQuery}
                style={{
                    width: "90%",
                    alignSelf: "center",
                    borderRadius: 32,
                    backgroundColor: colors.light,
                    fontFamily: "Poppins",
                }}
            />
            <CategoriesContainer>
                {loadedCategories?.map((cat) => (
                    <TouchableOpacity
                        key={cat.id}
                        onPress={() => setCategory(cat.title)}
                    >
                        <CategoryItem category={category} current={cat.title}>
                            {cat.title}
                        </CategoryItem>
                    </TouchableOpacity>
                ))}
            </CategoriesContainer>
            <FlatList
                style={{
                    width: "90%",
                    alignSelf: "center",
                    marginTop: 16,
                    justifyContents: "space-around",
                }}
                data={medicines}
                renderItem={({ item }) => (
                    <MedicineCard
                        onPress={() =>
                            navigation.navigate("Home", {
                                screen: "MedicinePage",
                                params: { item },
                            })
                        }
                        style={{ elevation: 5 }}
                    >
                        <Img source={item.medicineImg} />
                        <Title>{item.title}</Title>
                        <AddBtn>Add to Cart</AddBtn>
                    </MedicineCard>
                )}
                numColumns={2}
                keyExtractor={(item) => item.id}
            />
        </BgContainer>
    );
};

export default MedicineMain;
