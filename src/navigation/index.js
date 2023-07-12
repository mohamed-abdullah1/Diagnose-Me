import { NavigationContainer } from "@react-navigation/native";
import { useDispatch, useSelector } from "react-redux";
import { logout, selectToken, selectUser } from "../services/slices/auth.slice";
import AccountNavigator from "./account.navigation";
import AppNavigator from "./app.navigation";
import AppDocNavigator from "./doctor/appDoc.navigation";
import { useGetChatsQuery } from "../services/apis/chat.api";
import { selectChat } from "../services/slices/chat.slice";
import { useEffect, useState } from "react";
import { setNumOfChats } from "../services/slices/chat.slice";
import { decode, encode } from "base-64";
import AnotherNav from "./another.navigation";
import UpperDoc from "./doctor/upperDoc.navigation";
import {
  selectIsReg,
  selectWantToBeDoctor,
} from "../services/slices/registration.slice";
import ToastManager from "toastify-react-native";

function isTokenExpired(token) {
  const payload = JSON.parse(decode(token.split(".")[1]));
  const expiration = new Date(payload.exp * 1000);
  const now = new Date();
  const threshold = 5 * 60 * 1000; // 5 minutes

  return expiration.getTime() - now.getTime() < threshold;
}
//component for MainNavigator to check if user is logged in or not
const MainNavigator = () => {
  const user = useSelector(selectUser);
  const token = useSelector(selectToken);
  const chatInfo = useSelector(selectChat);
  const [isExpired, setIsExpired] = useState(false);
  const isReg = useSelector(selectIsReg);
  const wantToBeDoctor = useSelector(selectWantToBeDoctor);
  const dispatch = useDispatch();
  const {
    data: chats,
    error: chatsError,
    isSuccess: chatsIsSuccess,
  } = useGetChatsQuery(token);
  useEffect(() => {
    if (chatsIsSuccess) {
      console.log("👉🗣️", chats);
      dispatch(setNumOfChats(chats.length));
    }
  }, [chatsIsSuccess]);
  useEffect(() => {
    if (token && isTokenExpired(token)) {
      // Handle expired token
      setIsExpired(true);
      dispatch(logout());
    }
  }, [token]);
  console.log(isReg, wantToBeDoctor);
  return (
    <NavigationContainer>
      <ToastManager
        style={{ width: "80%", fontFamily: "Poppins", fontSize: 10 }}
      />
      {/* {user ? (
                user.isDoctor ? (
                    <AppDocNavigator />
                ) : (
                    <AppNavigator />
                )
            ) : (
                <AccountNavigator />
            )} */}
      {user && !isExpired ? (
        isReg ? (
          wantToBeDoctor ? (
            <UpperDoc />
          ) : (
            <AnotherNav />
          )
        ) : user.isDoctor ? (
          <UpperDoc />
        ) : (
          <AnotherNav />
        )
      ) : (
        <AnotherNav />
      )}
    </NavigationContainer>
  );
};

export default MainNavigator;
