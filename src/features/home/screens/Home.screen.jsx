import { useCallback, useState } from "react";
import TopHeader from "../../components/TopHeader.component";
import TitleSeeAll from "../components/TitleSeeAll.component";
import {
    BgContainer,
    CardsSection,
    CategoriesSection,
    DoctorsSection,
    Emoji,
    HeaderContainer,
    Hello,
    TrendQuestionsSection,
} from "../styles/Global.styles";
import {
    blogs,
    doctors,
    services,
    specialties,
    trendQuestions,
} from "../../../helpers/consts";
import ServiceCard from "../../components/ServiceCard.component";
import DoctorCard from "../../components/DoctorCard.component";
import {
    Dimensions,
    ScrollView,
    Text,
    TouchableOpacity,
    View,
} from "react-native";
import Spacer from "../../../infrastructure/components/Spacer";
import Card from "../../components/Card.component";
import QuestionCard from "../../components/QuestionCard.component";
import BlogCard from "../../components/BlogCard.component";
import colors from "../../../infrastructure/theme/colors";
import { useFocusEffect } from "@react-navigation/native";
import Modal from "react-native-modal";

const Home = ({ navigation }) => {
    const [userFirstName, setUserFirstName] = useState("Mohamed");
    const [drawerVisible, setDrawerVisible] = useState(false);

    useFocusEffect(
        useCallback(() => {
            navigation.getParent().setOptions({
                tabBarStyle: {
                    backgroundColor: colors.light,
                    height: 58,
                    alignItems: "center",
                    paddingBottom: 0,
                    paddingTop: 4,
                },
            });
        }, [])
    );
    const seeAllDoctorsHandler = () => {
        navigation.navigate({
            name: "Doctors",
            params: {
                category: "all",
            },
        });
    };
    const specialtyHandler = (value) =>
        navigation.navigate({
            name: "Doctors",
            params: {
                category: value,
            },
        });
    return (
        <BgContainer>
            <TopHeader
                onPress={() => {
                    setDrawerVisible(true);
                }}
                onPressImg={() => {
                    navigation.navigate("Profile");
                }}
            />
            <Modal
                coverScreen={false}
                backdropColor={"#000"}
                style={{
                    maxWidth: "70%",
                    backgroundColor: colors.light,
                    margin: 0,
                    padding: 0,
                }}
                animationIn="slideInLeft"
                animationOut="slideOutLeft"
                // hasBackdrop={false}
                onBackdropPress={() => setDrawerVisible(false)}
                isVisible={drawerVisible}
            >
                <TouchableOpacity
                    onPress={() => {
                        navigation.navigate("Blogs");
                        setDrawerVisible(false);
                    }}
                >
                    <Text>⭐ Blog</Text>
                </TouchableOpacity>
            </Modal>
            <ScrollView>
                <HeaderContainer>
                    <Hello>Hi, {userFirstName}</Hello>
                    <Emoji
                        source={require("../../../../assets/helpers/emoji.png")}
                    />
                </HeaderContainer>
                <CategoriesSection>
                    <TitleSeeAll title="Categories 📖" showSeeAll={false} />
                    <CardsSection>
                        {specialties.map(({ key, value, src }) => (
                            <ServiceCard
                                pressFunction={() => specialtyHandler(value)}
                                total={specialties.length}
                                key={key}
                                title={value}
                                img={src}
                                index={key}
                            />
                        ))}
                    </CardsSection>
                </CategoriesSection>
                <DoctorsSection>
                    <TitleSeeAll
                        pressFunction={seeAllDoctorsHandler}
                        title="Popular Doctors 🌟"
                    />
                    <CardsSection>
                        {doctors.map((doctor) => (
                            <DoctorCard
                                key={doctor.id}
                                doctor={doctor}
                                index={doctor.id}
                                total={doctors.length}
                            />
                        ))}
                    </CardsSection>
                </DoctorsSection>
                <CategoriesSection>
                    <TitleSeeAll title="Services 👨‍🔧" showSeeAll={false} />
                    <CardsSection>
                        {services.map(({ id, title, src }) => (
                            <ServiceCard
                                total={services.length}
                                key={id}
                                title={title}
                                img={src}
                                index={id}
                                pressFunction={() => navigation.navigate(title)}
                            />
                        ))}
                    </CardsSection>
                </CategoriesSection>
                <TrendQuestionsSection>
                    <CategoriesSection>
                        <TitleSeeAll
                            title="Trend Questions❓"
                            pressFunction={() =>
                                navigation.navigate("Questions")
                            }
                        />
                        <CardsSection>
                            {trendQuestions.map((q) => (
                                <QuestionCard question={q} />
                            ))}
                        </CardsSection>
                    </CategoriesSection>
                </TrendQuestionsSection>
                <Spacer position="bottom" size={16}>
                    <TrendQuestionsSection>
                        <CategoriesSection>
                            <TitleSeeAll
                                title="Blogs 📓"
                                pressFunction={() =>
                                    navigation.navigate("Blogs")
                                }
                            />
                            <CardsSection>
                                {blogs.map((blog) => (
                                    <BlogCard
                                        onPress={() =>
                                            navigation.navigate("Home", {
                                                screen: "BlogPage",
                                                params: { blog },
                                            })
                                        }
                                        key={blog.id}
                                        blog={blog}
                                        total={blogs.length}
                                        index={blog.id}
                                    />
                                ))}
                            </CardsSection>
                        </CategoriesSection>
                    </TrendQuestionsSection>
                </Spacer>
            </ScrollView>
        </BgContainer>
    );
};
export default Home;
