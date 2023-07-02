import React from "react";
import { Text, View } from "react-native";
import { BgContainer } from "../../home/styles/Global.styles";
import AgoraUIKit from "agora-rn-uikit";
import { useState } from "react";
import { selectToken } from "../../../services/slices/auth.slice";
import { useSelector } from "react-redux";
import { APPID_AGORA } from "../../../../secret";

const VideoCall = ({ navigation, route }) => {
  const [videoCall, setVideoCall] = useState(true);
  const token = useSelector(selectToken);
  const connectionData = {
    appId: APPID_AGORA,
    channel: `${route.chatId}`,
    // token: null, // enter your channel token as a string
  };
  console.log(videoCall);
  const rtcCallbacks = {
    EndCall: () => {
      navigation.goBack();
    },
    onJoinChannelSuccess: () => {
      console.log(`User ${"uid"} joined the channel🍭🍭🍭`);
    },
  };

  return (
    <BgContainer>
      <View style={{ height: "100%" }}>
        {videoCall ? (
          <AgoraUIKit
            connectionData={connectionData}
            rtcCallbacks={rtcCallbacks}
          />
        ) : (
          <Text onPress={() => setVideoCall(true)}>Start Call</Text>
        )}
      </View>
    </BgContainer>
  );
};

export default VideoCall;
