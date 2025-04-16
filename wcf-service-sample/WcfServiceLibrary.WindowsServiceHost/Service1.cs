using System.ServiceProcess;
using System.Diagnostics;
using System;
using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace WcfServiceLibrary.WindowsServiceHost
{
    public partial class Service1 : System.ServiceProcess.ServiceBase
    {
        private IWebHost _host;

        public Service1()
        {
            InitializeComponent();
        }

        internal void StartInDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                _host = new WebHostBuilder()
                    .UseKestrel()
                    .UseUrls("http://localhost:8080") // Adjust the URL as needed
                    .ConfigureServices(services =>
                    {
                        services.AddServiceModelServices();
                    })
                    .Configure(app =>
                    {
                        app.UseServiceModel(serviceBuilder =>
                        {
                            serviceBuilder.AddService<WcfServiceLibrary.Service1>();
                            serviceBuilder.AddServiceEndpoint<WcfServiceLibrary.Service1, WcfServiceLibrary.IService1>(new BasicHttpBinding(), "/Service1");
                        });
                    })
                    .Build();

                _host.Start();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error starting service, {ex.Message}";
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", errorMessage, EventLogEntryType.Error);
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }

        protected override void OnStop()
        {
            try
            {
                _host?.StopAsync().GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error stopping service, {ex.Message}";
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", errorMessage, EventLogEntryType.Error);
                EventLog.WriteEntry("WcfServiceLibraryServiceHost", ex.ToString(), EventLogEntryType.Error);
                throw;
            }
        }
    }
}