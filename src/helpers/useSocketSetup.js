// import { SocketIoEndPoint } from "../infrastructure/Constants";
import { io } from "socket.io-client";
import { chat_url } from "../services/apiEndPoint";

const useSocketSetup = () => {
  const socket = io("https://chat-appointment-service-api.onrender.com/");
  return socket;
};

export default useSocketSetup;
