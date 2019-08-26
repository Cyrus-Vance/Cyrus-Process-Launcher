using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessStarter.GlobalSets
{
    class GlobalVariable
    {
        public static string ApplicationData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string ConfigPathData = ApplicationData + @"\CV Software\CPL\";
        public static string ConfigPath = ApplicationData + @"\CV Software\CPL\systemSettings.ini";
        public static string PathDBPath = ApplicationData + @"\CV Software\CPL\pathInfo.db";

        public static int HideCountdown = 2;
        public static int Default_ShutdownCountdown = 5;
        public static int ShutdownCountdown = 5;
        public static bool EnableHideWindow = true;
        public static bool EnableAutoExit = true;
        public static bool EnableAutoUpdater = false;
        public static bool EnableDirectLaunch = true;
        public static bool EnableMinToNotify = false;
        public static bool AutorunWhenBoot = false;
        public static bool FirstSystemCfg = false;

        public static int PathAmount = 0;
        public static int SelectPathNum = 1;

        public const int MAX_PATH = 20;

        public static bool Authorized = false;

        public static List<int> Started_PID = new List<int>();
        public static List<int> Hid_PID = new List<int>();

        //API 常数定义
        public const int SW_HIDE = 0;
        public const int SW_NORMAL = 1;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
    }
}
