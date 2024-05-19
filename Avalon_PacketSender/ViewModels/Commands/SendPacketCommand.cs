using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;
using Avalon_PacketSender.Views;

namespace Avalon_PacketSender.ViewModels.Commands;

public class SendPacketCommand(MainWindowViewModel vm) : ICommand
{
    private readonly MainWindowViewModel? _vm = vm;


    public bool CanExecute(object? parameter)
    {
        var isCorrectIp = _vm != null && UdpSender.ValidateIPv4(_vm.RemoteIpAdressBox ?? throw new InvalidOperationException());
        
        
        if (string.IsNullOrWhiteSpace(vm.StringToSendBox) && (isCorrectIp = false))
        {
            return false;
        }
        
        return true;
    }

    public void Execute(object? parameter)
    {
        //testwindow.Show();
        
        UdpSender.UdpsendMessage(_vm.StringToSendBox, _vm.RemoteIpAdressBox, _vm.RemotePortBox);
    }

    public event EventHandler? CanExecuteChanged;

  
}