using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Avalon_PacketSender.ViewModels.Helpers;

public class UdpReceiver : IDisposable
{
    public string ListeningPort { get; set; }
    public UdpReceiver(string listeningPort)
    {
        ListeningPort = listeningPort;
        Task.Run(UdpReceiveAsync);
    }



    private string? _udpReceived = "";
    
  
    //Neuer EVENTHANDLER mit String Rückgabe
    public event EventHandler<string> PacketReceived;


    public async Task UdpReceiveAsync()
    {
        int portForListener = int.Parse(ListeningPort);
        //Creates a UdpClient for reading incoming data.
        UdpClient receivingUdpClient = new UdpClient(portForListener);

        //Creates an IPEndPoint to record the IP Address and port number of the sender.
        // The IPEndPoint will allow you to read datagrams sent from any source. 
        IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {
            try
            {

                //Blocks until a message returns on this socket from a remote host.
                var rxResult = await receivingUdpClient.ReceiveAsync();

                _udpReceived = Encoding.ASCII.GetString(rxResult.Buffer);

                string? allInfosData = $"{rxResult.RemoteEndPoint.Address} PORT: {rxResult.RemoteEndPoint.Port.ToString()} SAYS: {_udpReceived}";

                PacketReceived.Invoke(this, allInfosData);

                
            }
            catch (Exception e) { Console.WriteLine(e.ToString()); }
        }
    }
    
/*
    public async Task<string?> UdpReceiveAsync(string ListeningPort)
    {
        int portForListener = int.Parse(ListeningPort);
        
        //Creates a UdpClient for reading incoming data.
        using (UdpClient receivingUdpClient = new UdpClient(portForListener))
        {
            
            //Creates an IPEndPoint to record the IP Address and port number of the sender.
            // The IPEndPoint will allow you to read datagrams sent from any source. 
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, portForListener);

        
            
            //Blocks until a message comes on this socket from a remote host.
            var rxResult = await receivingUdpClient.ReceiveAsync();
            _udpReceived = Encoding.ASCII.GetString(rxResult.Buffer);

                
            //string? allInfosData = $"{rxResult.RemoteEndPoint.Address} PORT: {rxResult.RemoteEndPoint.Port.ToString()} SAYS: {_returnDataString}";
            //PacketReceived.Invoke(this, allInfosData);
        }
return _udpReceived;
        
    }
*/

public void Dispose()
{
    // TODO release managed resources here
}
}