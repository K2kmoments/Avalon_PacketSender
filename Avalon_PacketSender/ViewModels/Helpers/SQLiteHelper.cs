using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Avalon_PacketSender.Models;
using SQLite;

namespace Avalon_PacketSender.ViewModels.Helpers;

public static class SqLiteHelper
{
    private static readonly string DatabaseName = "UdpMachineSavedPresets.db";
    private static readonly string DatabasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); //optional change Path to Environment.CurrentDirectory
    private static readonly string DatabasePathName = System.IO.Path.Combine(DatabasePath, DatabaseName);

    public static void SavePacketInSql(string? stringToSend,string? remoteIpAddress, string? remotePort)
    {
        DataPacketPreset newPreset = new DataPacketPreset()
        {
            StringToSend = stringToSend,
            RemoteIpAddress = remoteIpAddress,
            RemotePort = remotePort
        };
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePathName))
        {
            connection.CreateTable<DataPacketPreset>();
            connection.Insert(newPreset);
        }
    }

    public static List<DataPacketPreset>? ReadPacketDatabase()
    {
        List<DataPacketPreset>? presetInTable;

        using (SQLiteConnection connection = new SQLiteConnection(DatabasePathName))
        {
            connection.CreateTable<DataPacketPreset>();
            presetInTable = connection.Table<DataPacketPreset>().ToList();
        }

        return presetInTable;
    }
    public static Task DeletePacketPresetInDatabase(DataPacketPreset? selectedPreset)
    {
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePathName))
        {
            connection.CreateTable<DataPacketPreset>();
            connection.Delete(selectedPreset);
            
        }

        return Task.CompletedTask;
    }
}