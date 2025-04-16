using System.ServiceProcess;
using System.Diagnostics;
using System;
using CoreWCF;
using CoreWCF.Configuration;


namespace WcfServiceLibrary.WindowsServiceHost
{
    public partial class Service1 : System.ServiceProcess.ServiceBase
    {

        CoreWCF.ServiceHost serviceHost;

        public Service1()
        {
            InitializeComponent();
            serviceHost = new CoreWCF.ServiceHost(typeof(WcfServiceLibrary.Service1));
        }

        internal void StartInDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                serviceHost.Open();
            }
            catch (Exception ex)
            {
                string erroMessage = $"Error starting service, {ex.Message}";
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", erroMessage, EventLogEntryType.Error);
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                serviceHost.Close();
            }
            catch (Exception ex)
            {
                string erroMessage = $"Error stopping service, {ex.Message}";
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", erroMessage, EventLogEntryType.Error);
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }
    }
}