using System;
using System.Windows.Input;
using Avalon_PacketSender.ViewModels.Helpers;

namespace Avalon_PacketSender.ViewModels.Commands;

public class DeletePresetCommand : ICommand
{
    public MainWindowViewModel Vm {
        get;
        set;
    }

    public DeletePresetCommand(MainWindowViewModel vm)
    {
        Vm = vm;
    }

    public bool CanExecute(object? parameter)
    {
        if (Vm.selectedPresetInViewer == null) return false;
        return true;
    }

    public void Execute(object? parameter)
    {
            SqLiteHelper.DeletePacketPresetInDatabase(Vm.selectedPresetInViewer);
            Vm.PresetListBoxList = SqLiteHelper.ReadPacketDatabase();
    }

    public event EventHandler? CanExecuteChanged;
}