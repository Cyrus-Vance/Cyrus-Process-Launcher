using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProcessStarter.GlobalSets
{
    class GlobalString
    {
        //系统配置文件所用字段名
        public const string cfgSystem = "System";
        public const string cfgFirstConfig = "FirstCfg";
        public const string cfgAutorun = "BootLaunch";
        public const string cfgDirectLaunch = "DirectLaunchProcess";
        public const string cfgAutoUpdater = "AutoUpdate";
        public const string cfgMinToNotify = "MinToNotifyIcon";
        public const string cfgHideWindowEnabled = "HideWindowEnabled";
        public const string cfgHideWindowTime = "HideWindowTime";
        public const string cfgAutoExitEnabled = "AutoExitEnabled";
        public const string cfgAutoExitTime = "AutoExitTime";

        //路径配置文件所用字段名
        public const string cfgPthGlobal = "Global";
        public const string cfgPthAmount = "Amount";
        public const string cfgPthProgram = "Program";
        public const string cfgPthPath = "Path";
        public const string cfgPthCmdLine = "CmdLine";
        public const string cfgPthEnable = "Enable";
        public const string cfgPthHide = "Hide";

        //注册表相关
        public const string bootRegPath = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
        public const string bootKeyName = "CyrusProcessStarter";

        //自动更新相关
        public const string updateXmlLink = @"http://software-update.ipdle.com:88/soft/xml/cpl.xml";
    }
}
