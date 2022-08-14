using System;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Avalonia;

namespace SteamCMD_GUI2.Models;

using System.IO;

public class MainModel
{
    public static async Task Init()
    {
        try
        {
            //Get the current directory and create SteamCMD directory if nonexistent 
            string curDir = Directory.GetCurrentDirectory();
            string steamCmdDir = curDir + @"\SteamCMD";
            Console.WriteLine("The current directory is {0}", curDir);
            if (!Directory.Exists(steamCmdDir))
            {
                Directory.CreateDirectory(steamCmdDir);
                Console.WriteLine("Created {0}", steamCmdDir);
            }
            else
            {
                Console.WriteLine("{0} already exists", steamCmdDir);
            }
            //Check for SteamCMD binary
            string steamCmdExe = steamCmdDir + @"\SteamCMD.exe";
            string steamCmdUrl = "https://steamcdn-a.akamaihd.net/client/installer/steamcmd.zip";
            string tempZip = curDir + @"\steamcmd.zip";
            async Task SaveFile(string fileUrl, string pathToSave)
            {
                var httpClient = new HttpClient();
                var httpResult = await httpClient.GetAsync(fileUrl);
                await using var resultStream = await httpResult.Content.ReadAsStreamAsync();
                await using var fileStream = File.Create(pathToSave);
                await resultStream.CopyToAsync(fileStream);
            }
            if (!File.Exists(steamCmdExe))
            {
                Console.WriteLine("{0} Doest not exist. Downloading {1} from {2}", steamCmdExe, tempZip, steamCmdUrl);
                //Download SteamCMD
                await SaveFile(steamCmdUrl, tempZip);
                Console.WriteLine("");
            }

        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
        }
    }
}