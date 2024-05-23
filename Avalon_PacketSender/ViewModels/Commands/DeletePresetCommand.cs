using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;

namespace Avalon_PacketSender.ViewModels.Commands;

public class DeletePresetCommand(MainWindowViewModel vm) : ICommand
{
    private MainWindowViewModel Vm {
        get;
        set;
    } = vm;

    public bool CanExecute(object? parameter)
    {
        if (Vm.SelectedPresetInViewer == null) return false;
        return true;
    }

    public void Execute(object? parameter)
    {
            _ = SqLiteHelper.DeletePacketPresetInDatabase(Vm.SelectedPresetInViewer);
            Vm.PresetListBoxList = SqLiteHelper.ReadPacketDatabase();
    }

    public event EventHandler? CanExecuteChanged;
}