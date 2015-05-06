using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ocelot.Agent
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Ocelot Base Directory: {Config.OcelotAgentBaseDirectory}");
            Console.WriteLine($"Sqlite Path: {Config.SqlitePath}");
            Console.WriteLine($"App Install Path: {Config.DefaultAppInstallDirectory}");
            Core.Nuget.GetPackage();
            Core.Nuget.InstallLatestPackage(Config.DefaultAppInstallDirectory);
            Console.WriteLine("Done installing");
            Console.ReadKey();
        }
    }
}
