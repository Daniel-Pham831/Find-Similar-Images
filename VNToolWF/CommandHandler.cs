using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNToolWF
{
    public class CommandHandler
    {
        public static string winMergePath = @"C:\Program Files (x86)\WinMerge\WinMergeU.exe";

        public static void ExecuteCommand(List<string> arguments)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";

            winMergePath = FormatToExcutableString(winMergePath);
            string paths = "";
            foreach (var argument in arguments)
            {
                paths += FormatToExcutableString(argument) + " ";
            }

            string command = "/C " + FormatToExcutableString(winMergePath + " " + paths);

            startInfo.Arguments = command;
            process.StartInfo = startInfo;
            process.Start();

            process.WaitForExit();
        }

        public static string FormatToExcutableString(string cmd)
        {
            return "\"" + cmd + "\"";
        }
    }
}
