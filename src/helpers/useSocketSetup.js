import { useEffect } from "react";
import { SocketIoEndPoint } from "../infrastructure/Constants";
import { io } from "socket.io-client";

const useSocketSetup = ({ chatId }) => {
    const socket = io(SocketIoEndPoint);
    useEffect(() => {
        socket.on("setup", { _id: chatId });
        socket.emit("join chat", chatId);
        return () => {
            socket.emit("leave", { _id: chatId });
        };
    }, []);
    return socket;
};

export default useSocketSetup;
