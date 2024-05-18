namespace Avalon_PacketSender.Models;

public class DataPacket(string remotePort, string remoteIpAdress, string stringToSend)
{
    public string StringToSend { get; set; } = stringToSend;
    public string RemoteIpAdress { get; set; } = remoteIpAdress;
    public string RemotePort { get; set; } = remotePort;
}