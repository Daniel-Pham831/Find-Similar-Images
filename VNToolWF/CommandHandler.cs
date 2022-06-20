using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNToolWF
{
    public class CommandHandler
    {
        public static string winMergePath = @"C:\Program Files (x86)\WinMerge\WinMergeU.exe";

        public static void ExecuteWinMergeCommand(List<string> arguments)
        {
            string winMerge = FormatToExcutableStringPath(winMergePath);
            string paths = "";
            foreach (var argument in arguments)
            {
                paths += FormatToExcutableStringPath(argument) + " ";
            }

            string command = winMerge + " " + paths;

            ExecuteCommand(command);
        }

        public static void ExecuteCommand(string argument)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";


            string command = "/C " + FormatToExcutableStringPath(argument);
            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();
        }

        public static string FormatToExcutableStringPath(string cmd)
        {
            return "\"" + cmd + "\"";
        }
    }
}
