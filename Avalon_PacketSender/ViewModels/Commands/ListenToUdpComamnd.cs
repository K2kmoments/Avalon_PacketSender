using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Avalon_PacketSender.ViewModels.Commands;

public class ListenToUdpComamnd : ICommand
{
    public MainWindowViewModel _vm;
    private string? _receivedUdpString;
    public ListenToUdpComamnd(MainWindowViewModel vm)
    {
        _vm = vm;
    }
    
    public bool CanExecute(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(_vm.ListeningPort)) return false;
        
        return true;
    }

    public void Execute(object? parameter)
    {
        _vm.LogAndReceiveTextBox = "";
        using (UdpReceiver receiver = new UdpReceiver(_vm.ListeningPort))
        {
            receiver.PacketReceived += UdpReceiveMessage_PacketReceived;
            receiver.Dispose();
        }
    }
    public void UdpReceiveMessage_PacketReceived(object? sender, string eventMessage)
    {
        //if (eventMessage != null)
        _vm.LogAndReceiveTextBox += $"{eventMessage}; ";

    }
    
    public event EventHandler? CanExecuteChanged;
}