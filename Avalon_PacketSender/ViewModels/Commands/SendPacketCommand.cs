using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;
using Avalon_PacketSender.Views;

namespace Avalon_PacketSender.ViewModels.Commands;

public class SendPacketCommand : ICommand
{
    private readonly MainWindowViewModel? _vm;
   
   
    public SendPacketCommand(MainWindowViewModel vm)
    {
        _vm = vm;
        
    }


    public bool CanExecute(object? parameter)
    {
        bool isCorrectIp = UdpHelper.ValidateIPv4(_vm.RemoteIpAdressBox);
        if (_vm != null && string.IsNullOrWhiteSpace(_vm.StringToSendBox)){return false;}
        else if (_vm != null && string.IsNullOrWhiteSpace(_vm.RemoteIpAdressBox )&& isCorrectIp == false){return false;}
        else if(_vm != null && string.IsNullOrWhiteSpace(_vm.RemotePortBox)){return false;}
        
        return true;
    }

    public void Execute(object? parameter)
    {
        //testwindow.Show();
        
        UdpHelper.UdpsendMessage(_vm.StringToSendBox, _vm.RemoteIpAdressBox, _vm.RemotePortBox);
    }

    public event EventHandler? CanExecuteChanged;

  
}