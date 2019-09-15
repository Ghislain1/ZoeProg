using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZoeProg.Core
{
    /// <summary>
    /// How to find WMI information with PowerShell
    /// </summary>
    public class Cmds
    {
        public static string InstalledPackCmd = @"Get-ItemProperty HKLM:\Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall\*";
        public static string ListInstalledPackCmd = "Get-WmiObject -Class Win32_Product";

        //You can search for the keyword "product":
        //get-wmiobject -list | where {$_.Name -match "product"}

        // You can search for the keyword "software":
        //get-wmiobject -list | where {$_.Name -match "software"}
    }
}