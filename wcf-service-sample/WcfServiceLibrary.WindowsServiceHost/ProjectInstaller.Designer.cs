using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Threading;
using System.Threading.Tasks;

namespace WcfServiceLibrary.WindowsServiceHost
{
    // Keeping the partial class for compatibility
    partial class ProjectInstaller
    {
        // This partial class is kept for compatibility reasons
    }

    public class Worker : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Your service logic here
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}