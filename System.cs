using System;
using System.Collections.Generic;
using System.Management;
using System.Text;


namespace SystemManagement
{
    public static class Devices
    {
        // 硬件 
        public const string Win32_Processor = "Win32_Processor"; // CPU 处理器 
        public const string Win32_PhysicalMemory = "Win32_PhysicalMemory";//物理内存条 
        public const string Win32_Keyboard = "Win32_Keyboard";//键盘 
        public const string Win32_PointingDevice = "Win32_PointingDevice";//点输入设备，包括鼠标。 
        public const string Win32_FloppyDrive = "Win32_FloppyDrive";//软盘驱动器 
        public const string Win32_DiskDrive = "Win32_FloppyDrive";//硬盘驱动器 
        public const string Win32_CDROMDrive = "Win32_CDROMDrive";//光盘驱动器 
        public const string Win32_BaseBoard = "Win32_BaseBoard";//主板 
        public const string Win32_BIOS = "Win32_BIOS";//BIOS 芯片 
        public const string Win32_ParallelPort = "Win32_ParallelPort";//并口 
        public const string Win32_SerialPort = "Win32_SerialPort";//串口 
        public const string Win32_SerialPortConfiguration = "Win32_SerialPortConfiguration";//串口配置 
        public const string Win32_SoundDevice = "Win32_SoundDevice";//多媒体设置，一般指声卡。 
        public const string Win32_SystemSlot = "Win32_SystemSlot";//主板插槽 (ISA & PCI & AGP) 
        public const string Win32_USBController = "Win32_USBController";//USB 控制器 
        public const string Win32_NetworkAdapter = "Win32_NetworkAdapter";//网络适配器 
        public const string Win32_NetworkAdapterConfiguration = "Win32_NetworkAdapterConfiguration";//网络适配器设置 
        public const string Win32_Printer = "Win32_Printer";//打印机 
        public const string Win32_PrinterConfiguration = "Win32_PrinterConfiguration";//打印机设置 
        public const string Win32_PrintJob = "Win32_PrintJob";//打印机任务 
        public const string Win32_TCPIPPrinterPort = "Win32_TCPIPPrinterPort";//打印机端口 
        public const string Win32_POTSModem = "Win32_POTSModem";//MODEM 
        public const string Win32_POTSModemToSerialPort = "Win32_POTSModemToSerialPort";//MODEM 端口 
        public const string Win32_DesktopMonitor = "Win32_DesktopMonitor";//显示器 
        public const string Win32_DisplayConfiguration = "Win32_DisplayConfiguration";//显卡 
        public const string Win32_DisplayControllerConfiguration = "Win32_DisplayControllerConfiguration";//显卡设置 
        public const string Win32_VideoController = "Win32_VideoController";//显卡细节。 
        public const string Win32_VideoSettings = "Win32_VideoSettings";//显卡支持的显示模式。 
    }
    public static class Systems
    {
        // 操作系统 
        public const string Win32_TimeZone = "Win32_TimeZone";//时区 
        public const string Win32_SystemDriver = "Win32_SystemDriver";//驱动程序 
        public const string Win32_DiskPartition = "Win32_DiskPartition";//磁盘分区 
        public const string Win32_LogicalDisk = "Win32_LogicalDisk";//逻辑磁盘 
        public const string Win32_LogicalDiskToPartition = "Win32_LogicalDiskToPartition";//逻辑磁盘所在分区及始末位置。 
        public const string Win32_LogicalMemoryConfiguration = "Win32_LogicalMemoryConfiguration";//逻辑内存配置 
        public const string Win32_PageFile = "Win32_PageFile";//系统页文件信息 
        public const string Win32_PageFileSetting = "Win32_PageFileSetting";//页文件设置 
        public const string Win32_BootConfiguration = "Win32_BootConfiguration";//系统启动配置 
        public const string Win32_ComputerSystem = "Win32_ComputerSystem";//计算机信息简要 
        public const string Win32_OperatingSystem = "Win32_OperatingSystem";//操作系统信息 
        public const string Win32_StartupCommand = "Win32_StartupCommand";//系统自动启动程序 
        public const string Win32_Service = "Win32_Service";//系统安装的服务 
        public const string Win32_Group = "Win32_Group";//系统管理组 
        public const string Win32_GroupUser = "Win32_GroupUser";//系统组帐号 
        public const string Win32_UserAccount = "Win32_UserAccount";//用户帐号 
        public const string Win32_Process = "Win32_Process";//系统进程 
        public const string Win32_Thread = "Win32_Thread";//系统线程 
        public const string Win32_Share = "Win32_Share";//共享 
    }


    /*   
    显卡: Win32_VideoController , PNPDeviceID
    声卡: Win32_SoundDevice ,PNPDeviceID
    CPU: Win32_Processor- 版本信息 Version, 名称信息Name, 制造厂商Manufacturer
    主板: Win32_BaseBoar-型号 Produc, 编号 SerialNumber, 制造厂商 Manufacturer
    */

    //WQL查询语句：
    public static class WIMSQL
    {
        // 网卡原生MAC地址
        public const string PNPDeviceID = "SELECT * FROM Win32_NetworkAdapter WHERE (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%'))";
        // 硬盘序列号
        public const string DiskDrive_SerialNumber = "SELECT * FROM Win32_DiskDrive WHERE (SerialNumber IS NOT NULL) AND (MediaType LIKE 'Fixed hard disk%')";
        // 主板序列号
        public const string BaseBoard_SerialNumber = "SELECT * FROM Win32_BaseBoard WHERE (SerialNumber IS NOT NULL)";
        // 处理器ID
        public const string Processor_ProcessorId = "SELECT * FROM Win32_Processor WHERE (ProcessorId IS NOT NULL)";
        // BIOS序列号
        public const string BIOS_SerialNumber = "SELECT * FROM Win32_BIOS WHERE (SerialNumber IS NOT NULL)";
        // 主板型号
        public const string BaseBoard_Product = "SELECT * FROM Win32_BaseBoard WHERE (Product IS NOT NULL)";
        // 网卡当前MAC地址
        //public const MACAddress= "SELECT * FROM Win32_NetworkAdapter WHERE (MACAddress IS NOT NULL) AND (NOT (PNPDeviceID LIKE 'ROOT%'))",
    }
    public static class SysManagement
    {
        public static string Query(string Key)
        {
            ManagementObjectSearcher mc = new ManagementObjectSearcher("select * from " + Key);
            //foreach (ManagementObject share in searcher.Get()){// Some Codes ...}
            //ManagementClass
            string key = string.Empty;
            foreach (var a in mc.Get())
            {
               // Console.WriteLine(a.GetText(TextFormat.CimDtd20));
            }
            return key;
        }

        /// 
        /// 获得CPU编号
        /// 
        /// 
        public static string GetCPUID()
        {
            string cpuid = "";
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                cpuid = mo.Properties["ProcessorId"].Value.ToString();
            }
            return cpuid;
        }
        /// 
        /// 获取硬盘序列号
        /// 
        /// 
        public static string GetDiskSerialNumber()
        {
            //这种模式在插入一个U盘后可能会有不同的结果，如插入我的手机时
            String HDid = "";
            ManagementClass mc = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                HDid = (string)mo.Properties["SerialNumber"].Value;//SerialNumber在Win7以上系统有效
                break;//这名话解决有多个物理盘时产生的问题，只取第一个物理硬盘，也可查wmi_HD["MediaType"].ToString() == "Fixed hard disk media")//固定硬盘，在Win7以上系统上，XP上"Fixed hard disk ”
            }
            return HDid;


        }
        /// 
        /// 获取网卡硬件地址
        /// 
        /// 
        public static string GetMacAddress()
        {
            string mac = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    mac = mo["MacAddress"].ToString();
                    break;
                }
            }
            return mac;
        }
        /// 
        /// 获取IP地址
        /// 
        /// 
        public static string GetIPAddress()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    //st=mo["IpAddress"].ToString(); 
                    System.Array ar;
                    ar = (System.Array)(mo.Properties["IpAddress"].Value);
                    st = ar.GetValue(0).ToString();
                    break;
                }
            }
            return st;
        }
        /// 
        /// 操作系统的登录用户名
        /// 
        /// 
        public static string GetUserName()
        {
            return Environment.UserName;
        }

        /// 
        /// 获取计算机名
        /// 
        /// 
        public static string GetComputerName()
        {
            return Environment.MachineName;
        }
        /// 
        /// 操作系统类型
        /// 
        /// 
        public static string GetSystemType()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["SystemType"].ToString();
            }
            return st;
        }
        /// 
        /// 物理内存
        /// 
        /// 
        public static string GetPhysicalMemory()
        {
            string st = "";
            ManagementClass mc = new ManagementClass("Win32_ComputerSystem");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                st = mo["TotalPhysicalMemory"].ToString();
            }
            return st;
        }

    }
}
