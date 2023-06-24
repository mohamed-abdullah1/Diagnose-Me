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
import store, { persister } from "./src/services/store";
import { selectToken, selectUser } from "./src/services/slices/auth.slice";
import { PersistGate } from "redux-persist/integration/react";

export default () => {
  const [fontLoaded] = useFonts(poppinsFonts);
  if (!fontLoaded) {
    return null;
  }

  return (
    <SafeArea>
      <ThemeProvider theme={theme}>
        <Provider store={store}>
          <PersistGate loading={null} persistor={persister}>
            <MainNavigator />
          </PersistGate>
          {/* <AuthProvider>
                    </AuthProvider> */}
        </Provider>
      </ThemeProvider>
    </SafeArea>
  );
};
