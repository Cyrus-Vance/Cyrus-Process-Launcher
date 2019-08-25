# Cyrus Process Launcher

**Cyrus Process Launcher目前尚处于开发阶段，如果您发现任何BUG请立即反馈给作者，我们将尽快进行跟进和修复。**

Cyrus Process Launcher是由Cyrus Vance开发的用于Windows系统的易用型批量进程自动启动隐藏系统，可以用于个人电脑或服务器中。


## 待改进的部分（TODO）

###功能方面
###程序方面
+ 大量数据变量数组诸如*pathData, cmdLineData, enableData, hideData*可用List< T >而不是多个数组（T为自定义类型），在容量方面也更灵活
+ foreach遍历可以取代大量传统的for遍历
+ 尚不清楚使用Win32API和System.Diagnostics.Process.MainWindowHandle获取进程主窗口句柄的优缺点
+ 准备使用SQLite对启动过的进程进行储存，储存内容包括PID和启动时间（由Process的StartTime属性确认）。重新打开工具时进行校验，当二者相同时则算作历史打开文件，不相同的项则直接舍弃。