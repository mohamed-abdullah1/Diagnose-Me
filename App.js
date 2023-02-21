import React from "react";
import { useFonts } from "expo-font";
import poppinsFonts from "./src/helpers/poppinsFonts";
import SafeArea from "./src/infrastructure/components/SafeArea";
import { ThemeProvider } from "styled-components/native";
import theme from "./src/infrastructure/theme/index";
import { AuthProvider } from "./src/services/auth/auth.context";
import MainNavigator from "./src/navigation";
import "react-native-gesture-handler";

export default () => {
    const [fontLoaded] = useFonts(poppinsFonts);
    if (!fontLoaded) {
        return null;
    }
    return (
        <SafeArea>
            <ThemeProvider theme={theme}>
                <AuthProvider>
                    <MainNavigator />
                </AuthProvider>
            </ThemeProvider>
        </SafeArea>
    );
};
