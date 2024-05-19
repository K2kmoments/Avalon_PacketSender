using Avalon_PacketSender.ViewModels;
using Avalon_PacketSender.ViewModels.Helpers;
using Avalonia.Remote.Protocol.Input;
using SQLite;


namespace Avalon_PacketSender.Models;

public class DataPacketPreset
{
  

    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? StringToSend { get; set; }
    public string? RemoteIpAdress { get; set; }
    public string? RemotePort { get; set; }
    

   
    
/*
    public override string ToString()
    {
        // Original: return base.ToString();
        //Override:

        return $"{StringToSend}, {RemoteIpAdress} {RemotePort}";
    }
*/
}