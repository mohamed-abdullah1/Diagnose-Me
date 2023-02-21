import { useState } from "react";
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
import { ScrollView, View } from "react-native";
import Spacer from "../../../infrastructure/components/Spacer";
import Card from "../../components/Card.component";
import QuestionCard from "../../components/QuestionCard.component";
import BlogCard from "../../components/BlogCard.component";

const Home = () => {
    const [userFirstName, setUserFirstName] = useState("Mohamed");
    return (
        <BgContainer>
            <TopHeader />
            <ScrollView>
                <HeaderContainer>
                    <Hello>Hi, {userFirstName}</Hello>
                    <Emoji
                        source={require("../../../../assets/helpers/emoji.png")}
                    />
                </HeaderContainer>
                <CategoriesSection>
                    <TitleSeeAll title="Categories" />
                    <CardsSection>
                        {specialties.map(({ key, value, src }) => (
                            <ServiceCard
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
                    <TitleSeeAll title="Popular Doctors" />
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
                    <TitleSeeAll title="Services" />
                    <CardsSection>
                        {services.map(({ id, title, src }) => (
                            <ServiceCard
                                total={services.length}
                                key={id}
                                title={title}
                                img={src}
                                index={id}
                            />
                        ))}
                    </CardsSection>
                </CategoriesSection>
                <TrendQuestionsSection>
                    <CategoriesSection>
                        <TitleSeeAll title="Trend Questions" />
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
                            <TitleSeeAll title="Blogs" />
                            <CardsSection>
                                {blogs.map((blog) => (
                                    <BlogCard
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
