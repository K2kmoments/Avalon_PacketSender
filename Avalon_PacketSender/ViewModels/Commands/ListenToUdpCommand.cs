using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Avalon_PacketSender.ViewModels.Commands;

public class ListenToUdpCommand(MainWindowViewModel vm) : ICommand
{
    public bool CanExecute(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(vm.ListeningPort)) return false;
        
        return true;
    }

    public void Execute(object? parameter)
    {
            vm.LogAndReceiveTextBox = "";
            using (UdpReceiver receiver = new UdpReceiver(vm.ListeningPort))
            {
                receiver.PacketReceived += UdpReceiveMessage_PacketReceived;
            } 
    }
    public void UdpReceiveMessage_PacketReceived(object? sender, string eventMessage)
    {
        //if (eventMessage != null)
        vm.LogAndReceiveTextBox += $"{eventMessage}; ";
    }
    
    public event EventHandler? CanExecuteChanged;
}