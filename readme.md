# Cyrus Process Launcher

**Cyrus Process Launcher目前尚处于开发阶段，如果您发现任何BUG请立即反馈给作者，我们将尽快进行跟进和修复。**

![主界面截图](https://github.com/Cyrus-Vance/Cyrus-Process-Launcher/blob/master/images/MainForm_Screenshot.png?raw=1 "主界面截图")

Cyrus Process Launcher(以下简称CPL）是由Cyrus Vance开发的用于Windows系统的易用型批量进程自动启动隐藏系统，可以用于个人电脑或服务器中。

## 使用说明
CPL的使用方法十分简单，您只需要一些微不足道的时间即可了解该系统的使用方法。在首次启动时，系统将弹出路径配置界面（如下图）供您选择。

![路径配置界面](https://github.com/Cyrus-Vance/Cyrus-Process-Launcher/blob/master/images/PathConfig_Screenshot.png?raw=1 "路径配置界面")

在该界面中，您将从默认的1号程序开始配置。在填入您需要启动的程序的路径和参数之后，依据情况选择是否启用该项以及是否在启动后自动隐藏该项。（需要在设置中启用全局自动隐藏）

之后，您可以根据实际情况选择是否添加新的启动项或是删除已有的启动项，当一切就绪后，按“保存”按钮即可。

## 待改进的部分（TODO）

### 功能方面
+ 准备加入程序退出后的进程保存机制，用于显示之前隐藏过的进程。
+ 准备加入隐藏进程界面的进程选择器面板，便于用户选择手动模式需要指定的进程。
+ 准备加入新手使用向导，便于初次使用CPL的用户快速上手。

### 程序方面
+ 尚不清楚使用Win32API和System.Diagnostics.Process.MainWindowHandle获取进程主窗口句柄的优缺点
+ 准备使用SQLite对启动过的进程进行储存，储存内容包括PID和启动时间（由Process的StartTime属性确认）。重新打开工具时进行校验，当二者相同时则算作历史打开文件，不相同的项则直接舍弃。