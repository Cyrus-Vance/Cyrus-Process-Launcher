using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ServerStarter
{

    public class IniFile
    {
        //文件INI名称
        //public string Path;

        /**/////声明读写INI文件的API函数
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        //类的构造函数，传递INI文件名
        //public IniFile(string inipath)
        //{
        //    //
        //    // TODO: Add constructor logic here
        //    //
        //    Path = inipath;
        //}

        //写INI文件
        public static void IniWriteValue(string Section, string Key, string Value, string Path)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        /// <summary>
        /// 读取INI文件指定的文件数据
        /// </summary>
        /// <param name="Section"></param>
        /// <param name="Key"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        public static string IniReadValue(string Section, string Key, string Path)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, Path);
            return temp.ToString();
        }
        /**//// <summary>
        /// 验证文件是否存在
        /// </summary>
        /// <returns>布尔值 </returns>
        //public bool ExistINIFile()
        //{
        //    return File.Exists(this.Path);
        //}

    }
}
