using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Avalon_PacketSender.Models;
using Avalon_PacketSender.ViewModels.Commands;
using Avalon_PacketSender.ViewModels.Helpers;

namespace Avalon_PacketSender.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
  

    private string? _stringToSendBox;
    private string? _remoteIpAdressBox;
    private string? _remotePortBox;
    private string? _listeningPort;
    private string? _logAndReceiveTextBox;
    private List<DataPacketPreset>? _presetListBoxList;
    private DataPacketPreset? _selectedPresetInViewer;
    
    public DataPacketPreset? PresetToDelete { get; set; }

    


    public DataPacketPreset? SelectedPresetInViewer
    {
        get => _selectedPresetInViewer;
        set
        {
            if (Equals(value, _selectedPresetInViewer)) return;
            _selectedPresetInViewer = value;
            OnPropertyChanged();
            SelectPreset();
        }
    }

    public DeletePresetCommand DeletePresetCommand { get; set; }
    public SavePresetCommand SavePresetCommand { get; set; }
    public SendPacketCommand SendCommand {get;set;}
    public ListenToUdpCommand ListenToUdpCommand { get; set; }

    public string? ListeningPort
    {
        get => _listeningPort;
        set
        {
            if (value == _listeningPort) return;
            _listeningPort = value;
            OnPropertyChanged();
        }
    }

    public List<DataPacketPreset>? PresetListBoxList
    {
        get => _presetListBoxList;
        set
        {
            if (Equals(value, _presetListBoxList)) return;
            _presetListBoxList = value;
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
        //Commands
        SendCommand = new SendPacketCommand(this);
        ListenToUdpCommand = new ListenToUdpCommand(this);
        SavePresetCommand = new SavePresetCommand(this);
        DeletePresetCommand = new DeletePresetCommand(this);
        

        // Initialize Preset Database
        var database = SqLiteHelper.ReadPacketDatabase();
        PresetListBoxList = database;
       

       
    }

    private void SelectPreset()
    {
        var selectedViewer = SelectedPresetInViewer;
        StringToSendBox = selectedViewer?.StringToSend;
        RemotePortBox = selectedViewer?.RemotePort;
        RemoteIpAdressBox = selectedViewer?.RemoteIpAddress;
       
        
        selectedViewer = null;
    }

   
   
    
}