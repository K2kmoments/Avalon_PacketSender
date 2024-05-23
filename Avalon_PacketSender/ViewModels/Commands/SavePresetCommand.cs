using System;
using System.Windows.Input;
using Avalon_PacketSender.Models;
using Avalon_PacketSender.ViewModels.Helpers;

namespace Avalon_PacketSender.ViewModels.Commands;

public class SavePresetCommand(MainWindowViewModel vm) : ICommand
{
    private MainWindowViewModel Vm {
        get;
        set;
    } = vm;

    public bool CanExecute(object? parameter)
    {
        if (string.IsNullOrWhiteSpace(Vm.StringToSendBox)) return false;
        return true;
    }
    public void Execute(object? parameter)
    {
        SqLiteHelper.SavePacketInSql(Vm.StringToSendBox,Vm.RemoteIpAdressBox,Vm.RemotePortBox);
        Vm.PresetListBoxList = SqLiteHelper.ReadPacketDatabase();
        
    }
    public event EventHandler? CanExecuteChanged;
}