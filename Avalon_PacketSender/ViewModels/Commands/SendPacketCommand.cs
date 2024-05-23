using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;
using Avalon_PacketSender.Views;

namespace Avalon_PacketSender.ViewModels.Commands;

public class SendPacketCommand(MainWindowViewModel vm) : ICommand
{
    private readonly MainWindowViewModel? Vm = vm;


    public bool CanExecute(object? parameter)
    {
        
        
        if (string.IsNullOrWhiteSpace(Vm?.StringToSendBox))
        {
            return false;
        }
        
        return true;
    }

    public void Execute(object? parameter)
    {
        //testwindow.Show();
        
        UdpSender.UdpSendMessage(Vm?.StringToSendBox, Vm?.RemoteIpAdressBox, Vm?.RemotePortBox);
    }

    public event EventHandler? CanExecuteChanged;

  
}