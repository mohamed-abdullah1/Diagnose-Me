import React from "react";
import { Text, View } from "react-native";
import { BgContainer } from "../../home/styles/Global.styles";
import AgoraUIKit from "agora-rn-uikit";
import { useState } from "react";
import { selectToken } from "../../../services/slices/auth.slice";
import { useSelector } from "react-redux";

const VideoCall = () => {
  const [videoCall, setVideoCall] = useState(true);
  const token = useSelector(selectToken);
  const connectionData = {
    appId: "6e93ffe7c1e94df5b7982605172a18c5",
    channel: "<channel-name>",
    token,
  };
  const rtcCallbacks = {
    EndCall: () => setVideoCall(false),
  };
  return (
    <BgContainer>
      <View>
        <Text>Video Call</Text>
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
