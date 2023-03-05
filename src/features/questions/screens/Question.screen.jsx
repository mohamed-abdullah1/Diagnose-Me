import { useEffect, useState } from "react";
import { Image, View } from "react-native";
import { ActivityIndicator, Appbar, MD2Colors } from "react-native-paper";
import QuestionCard from "../../components/QuestionCard.component";
import Rate from "../../components/Rate.Component";
import { BgContainer } from "../../home/styles/Global.styles";
import {
    Bottom,
    CommentCard,
    CommentsContainer,
    CommentTitle,
    Container,
    Date,
    Img,
    Info,
    InfoWrapper,
    LowerIcon,
    Middle,
    Name,
    Specialty,
    SpecialtyContainer,
    Total,
    UpIcon,
    Upper,
} from "../styles/Question.styles";
const Question = ({ route, navigation }) => {
    const { question } = route.params;
    return (
        <BgContainer>
            <Appbar.Header>
                <Appbar.BackAction onPress={() => navigation.goBack()} />
            </Appbar.Header>
            <Container>
                {question ? (
                    <QuestionCard
                        question={question}
                        styles={{
                            maxHeight: 192,
                            alignSelf: "center",
                            // justifySelf: "center",
                            width: "90%",
                            marginRight: 0,
                        }}
                    />
                ) : (
                    <ActivityIndicator
                        animating={!!question}
                        color={MD2Colors.red800}
                    />
                )}
                <CommentTitle>Replies 🗣️</CommentTitle>
                <CommentsContainer>
                    {question.comments.length > 0 ? (
                        question.comments.map((c) => (
                            <CommentCard
                                style={{
                                    elevation: 8,
                                    shadowColor: "#000000bb",
                                    shadowOffset: { width: -2, height: 4 },
                                    shadowOpacity: 0.82,
                                    shadowRadius: 3,
                                }}
                                key={c.id}
                            >
                                <Upper>
                                    <InfoWrapper>
                                        <Img source={c.doctorImg} />
                                        <Info>
                                            <Name>{"Dr. " + c.name}</Name>
                                            <SpecialtyContainer>
                                                <Specialty>
                                                    {c.specialty}
                                                </Specialty>
                                                <Rate rate={c.rate} />
                                            </SpecialtyContainer>
                                        </Info>
                                    </InfoWrapper>
                                    <Date>{c.date}</Date>
                                </Upper>
                                <Middle>{c.content}</Middle>
                                <Bottom>
                                    <UpIcon />
                                    <LowerIcon />
                                    <Total>{c.ups - c.downs}</Total>
                                </Bottom>
                            </CommentCard>
                        ))
                    ) : (
                        <View
                            style={{
                                alignSelf: "center",
                                justifySelf: "center",
                                // borderColor: "red",
                                // borderWidth: 1,
                                flex: 1,
                                width: "100%",
                                height: "100%",
                                padding: 16,
                            }}
                        >
                            <Image
                                source={require("../../../../assets/helpers/comment.png")}
                                style={{
                                    width: "100%",
                                    height: 250,
                                }}
                            />
                        </View>
                    )}
                </CommentsContainer>
            </Container>
        </BgContainer>
    );
};
export default Question;
