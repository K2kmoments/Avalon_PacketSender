using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;

namespace Avalon_PacketSender.ViewModels.Helpers;

public static class UdpSender
{ 
    
    public static bool ValidateIPv4(string ipString)
    {
        if (String.IsNullOrWhiteSpace(ipString))
        {
            return false;
        }

        string[] splitValues = ipString.Split('.');
        if (splitValues.Length != 4)
        {
            return false;
        }

        byte tempForParsing;

        return splitValues.All(r => byte.TryParse(r, out tempForParsing));
    }
    
    public static async void UdpsendMessage(string? message, string? ipAddress, string? portString)
    {
        int port = int.Parse(portString);
        using (var udpClient = new UdpClient(ipAddress, port))
        {
            Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
            await udpClient.SendAsync(sendBytes, sendBytes.Length);
        }
    }
    
    
}