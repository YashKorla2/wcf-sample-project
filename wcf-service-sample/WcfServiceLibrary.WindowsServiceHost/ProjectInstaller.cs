using System;
using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WcfServiceLibrary.WindowsServiceHost
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller serviceProcessInstaller;
        private ServiceInstaller serviceInstaller;

        public ProjectInstaller()
        {
            InitializeComponent();

            serviceProcessInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            serviceProcessInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.ServiceName = "WcfServiceLibraryHost";
            serviceInstaller.DisplayName = "WCF Service Library Host";
            serviceInstaller.Description = "Hosts the WCF Service Library";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            Installers.Add(serviceProcessInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}