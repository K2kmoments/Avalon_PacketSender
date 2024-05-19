using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;

namespace Avalon_PacketSender.ViewModels.Commands;

public class SendPresetCommand(MainWindowViewModel vm) : ICommand
{
    private MainWindowViewModel? _vm;
    public MainWindowViewModel Vm {
        get;
        set;
    } = vm;

    public bool CanExecute(object? parameter)
    {
        return true; 
    }

    public void Execute(object? parameter)
    {
        string? ipAddress = Vm.selectedPresetInViewer.RemoteIpAdress;
        string? port = Vm.selectedPresetInViewer.RemotePort;
        string? message = _vm.selectedPresetInViewer.StringToSend;
        UdpSender.UdpsendMessage(message, ipAddress, port);
    }

    public event EventHandler? CanExecuteChanged;
}