using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;

namespace Avalon_PacketSender.ViewModels.Commands;

public class SendPresetCommand(MainWindowViewModel vm) : ICommand
{
    private MainWindowViewModel Vm {
        get;
        set;
    } = vm;

    public bool CanExecute(object? parameter)
    {
        return true; 
    }

    public void Execute(object? parameter)
    {
        string? ipAddress = Vm.SelectedPresetInViewer?.RemoteIpAddress;
        string? port = Vm.SelectedPresetInViewer?.RemotePort;
        string? message = Vm.SelectedPresetInViewer?.StringToSend;
        UdpSender.UdpSendMessage(message, ipAddress, port);
    }

    public event EventHandler? CanExecuteChanged;
}