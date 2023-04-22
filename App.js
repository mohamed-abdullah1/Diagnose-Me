import React from "react";
import { useFonts } from "expo-font";
import poppinsFonts from "./src/helpers/poppinsFonts";
import SafeArea from "./src/infrastructure/components/SafeArea";
import { ThemeProvider } from "styled-components/native";
import theme from "./src/infrastructure/theme/index";
import { AuthProvider } from "./src/services/auth/auth.context";
import MainNavigator from "./src/navigation";
import "react-native-gesture-handler";
import { Provider, useSelector } from "react-redux";
import store from "./src/services/store";
import { selectToken, selectUser } from "./src/services/slices/auth.slice";

export default () => {
    const [fontLoaded] = useFonts(poppinsFonts);
    if (!fontLoaded) {
        return null;
    }

    return (
        <SafeArea>
            <ThemeProvider theme={theme}>
                <Provider store={store}>
                    <AuthProvider>
                        <MainNavigator />
                    </AuthProvider>
                </Provider>
            </ThemeProvider>
        </SafeArea>
    );
};
