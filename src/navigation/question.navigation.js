import { createStackNavigator } from "@react-navigation/stack";
import MainQuestions from "../features/questions/screens/MainQuestions.screen";
import Question from "../features/questions/screens/Question.screen";

const QuestionStack = createStackNavigator();

const QuestionNavigator = () => {
    return (
        <QuestionStack.Navigator screenOptions={{ headerShown: false }}>
            <QuestionStack.Screen
                name="MainQuestion"
                component={MainQuestions}
            />
            <QuestionStack.Screen name="QuestionPage" component={Question} />
        </QuestionStack.Navigator>
    );
};
export default QuestionNavigator;
