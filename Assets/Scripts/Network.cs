using System;
using System.Net;
using System.Net.Sockets;

public static class Network {
    static string IpAddress = "127.0.0.1";
    static int Port = 3000;

    public static void Connect() {
        //byte[] PacketData = System.Text.Encoding.ASCII.GetBytes("Hello");
        byte[] PacketData = new byte[2];
        PacketData[0] = 1;
        PacketData[1] = 5;
        //byte[] PacketData = BitConverter.GetBytes(Convert.ToByte(3));
        SendPacket(PacketData);
    }

    static void SendPacket(byte[] packetData) {
        IPEndPoint EndPoint = new IPEndPoint(IPAddress.Parse(IpAddress), Port);
        Socket Socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        Socket.SendTo(packetData, EndPoint);
    }

    public static void UpdateMovement() {
        byte[] PacketData = new byte[4];
        PacketData[0] = 1;
        PacketData[1] = State.CurrentPlayer.Id;
        PacketData[2] = (byte)State.CurrentPlayer.Movement.InputX;
        PacketData[3] = (byte)State.CurrentPlayer.Movement.InputZ;
        SendPacket(PacketData);
    }
}
