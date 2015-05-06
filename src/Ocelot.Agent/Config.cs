using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ocelot.Agent
{
    public class Config
    {
        public static string SqlitePath { get; }
        public static string OcelotAgentBaseDirectory { get; }
        public static string DefaultAppInstallDirectory { get;  }
        static Config()
        {
            OcelotAgentBaseDirectory = InitPath("OcelotAgentBaseDirectory");
            SqlitePath = InitPath("SqlitePath");
            DefaultAppInstallDirectory = InitPath("DefaultAppInstallDirectory");
        }
        private static string InitPath(string appSettingsKey)
        {
            var path = ConfigurationManager.AppSettings[appSettingsKey];
            if (path == null)
            {
                throw new ConfigurationErrorsException($"Couldn't find an appSettings key by the name of {appSettingsKey}");
            }
            path = MakeFolderReplacements(path);
            MakeFolderIfNotExists(path);
            return path;
        }
        private static string MakeFolderReplacements(string folder)
        {
            folder = folder.Replace("${CommonApplicationData}", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData));
            folder = folder.Replace("${OcelotAgentBaseDirectory}", OcelotAgentBaseDirectory);
            return folder;
        }
        private static void MakeFolderIfNotExists(string path)
        {
            var dir = Path.GetDirectoryName(path);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }
    }
}
