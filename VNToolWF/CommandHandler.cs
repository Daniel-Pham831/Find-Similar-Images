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
        public static string WinMerge = "WinMergeU.exe";

        public static void ExecuteWinMergeCommand(List<string> arguments)
        {
            string paths = "";
            foreach (var argument in arguments)
            {
                paths += FormatToExcutableStringPath(argument) + " ";
            }

            ExecuteCommand(paths);
        }

        public static void ExecuteCommand(string argument)
        {
            using (Process process = new Process())
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = WinMerge;
                startInfo.Arguments = argument;
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        public static string FormatToExcutableStringPath(string cmd)
        {
            return "\"" + cmd + "\"";
        }
    }
}
