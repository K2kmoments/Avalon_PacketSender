using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Avalon_PacketSender.ViewModels.Helpers;

public class UdpReceiver : IDisposable
{
    public string? ListeningPort { get; set; }
    public UdpReceiver(string? listeningPort)
    {
        ListeningPort = listeningPort;
        Task.Run(UdpReceiveAsync);
    }



    private string? _udpReceived = "";
    
  
    //Neuer EVENTHANDLER mit String Rückgabe
    public event EventHandler<string>? PacketReceived;


    public async Task UdpReceiveAsync()
    {
        if (ListeningPort != null)
        {
            int portForListener = int.Parse(ListeningPort);
            //Creates a UdpClient for reading incoming data.
            UdpClient receivingUdpClient = new UdpClient(portForListener);
            

            while (true)
            {
                try
                {

                    //Blocks until a message returns on this socket from a remote host.
                    var rxResult = await receivingUdpClient.ReceiveAsync();

                    _udpReceived = Encoding.ASCII.GetString(rxResult.Buffer);

                    var allInfosData = $"FROM: {rxResult.RemoteEndPoint.Address} PORT: {rxResult.RemoteEndPoint.Port.ToString()} MESSAGE: {_udpReceived} \n";

                    PacketReceived?.Invoke(this, allInfosData);

                
                }
                catch (Exception e) { Console.WriteLine(e.ToString()); }
            }
        }
    }
  

public void Dispose()
{
    // TODO release managed resources here
    
}
}