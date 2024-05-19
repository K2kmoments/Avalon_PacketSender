using Avalon_PacketSender.ViewModels.Commands;
using Avalon_PacketSender.Views;

namespace Avalon_PacketSender.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    
    public SendPacketCommand SendCommand {get;set;}
    public ListenToUdpComamnd ListenToUdpComamnd { get; set; }
    public string ListeningPort
    {
        get => _listeningPort;
        set
        {
            if (value == _listeningPort) return;
            _listeningPort = value;
            OnPropertyChanged();
        }
    }

    public string? LogAndReceiveTextBox
    {
        get => _logAndReceiveTextBox;
        set
        {
            if (value == _logAndReceiveTextBox) return;
            _logAndReceiveTextBox = value;
            OnPropertyChanged();
        }
    }

    private string? _stringToSendBox;
    private string? _remoteIpAdressBox;
    private string? _remotePortBox;
    private string? _listeningPort;
    private string? _logAndReceiveTextBox;

    public string? StringToSendBox
    {
        get => _stringToSendBox;
        set
        {
            if (value == _stringToSendBox) return;
            _stringToSendBox = value;
            OnPropertyChanged();
          
        }
    }

    public string? RemoteIpAdressBox
    {
        get => _remoteIpAdressBox;
        set
        {
            if (value == _remoteIpAdressBox) return;
            _remoteIpAdressBox = value;
            OnPropertyChanged();
            
        }
    }

    public string? RemotePortBox
    {
        get => _remotePortBox;
        set
        {
            if (value == _remotePortBox) return;
            _remotePortBox = value;
            OnPropertyChanged();
            
        }
    }

    public MainWindowViewModel()
    {
        SendCommand = new SendPacketCommand(this);
        ListenToUdpComamnd = new ListenToUdpComamnd(this);
        
    }
    
   
    
}