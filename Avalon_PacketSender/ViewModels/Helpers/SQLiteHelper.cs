using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Avalon_PacketSender.Models;
using Avalonia.Interactivity;
using SQLite;

namespace Avalon_PacketSender.ViewModels.Helpers;

public class SqLiteHelper
{
    private static string databaseName = "UdpMachineSavedPresets.db";
    static string databasePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    public static string DatabasePathName = System.IO.Path.Combine(databasePath, databaseName);

    public DataPacketPreset PresetToSave {get;set;}

    public SqLiteHelper()
    {
   
    }

    public static void SavePacketInSql(string stringToSend,string remoteIpAdress, string remotePort)
    {
        DataPacketPreset newPreset = new DataPacketPreset()
        {
            StringToSend = stringToSend,
            RemoteIpAdress = remoteIpAdress,
            RemotePort = remotePort
        };
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePathName))
        {
            connection.CreateTable<DataPacketPreset>();
            connection.Insert(newPreset);
        }
    }

    public static List<DataPacketPreset> ReadPacketDatabase()
    {
        List<DataPacketPreset> PresetInTable;

        using (SQLiteConnection connection = new SQLiteConnection(DatabasePathName))
        {
            connection.CreateTable<DataPacketPreset>();
            PresetInTable = connection.Table<DataPacketPreset>().ToList();
        }

        return PresetInTable;
    }
    public static async Task DeletePacketPresetInDatabase(DataPacketPreset selectedPreset)
    {
        using (SQLiteConnection connection = new SQLiteConnection(DatabasePathName))
        {
            connection.CreateTable<DataPacketPreset>();
            connection.Delete(selectedPreset);
            
        }
    }
}