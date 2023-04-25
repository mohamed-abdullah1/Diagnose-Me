import { SocketIoEndPoint } from "../infrastructure/Constants";
import { io } from "socket.io-client";

const useSocketSetup = () => {
    const socket = io(SocketIoEndPoint);
    return socket;
};

export default useSocketSetup;
