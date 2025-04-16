
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WcfServiceLibrary.SampleHost
{
   public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            string pathToXml = @"/tmp/tempfspartition/QnetTransformArtifacts/MidTransformCode/sourceCode/wcf-service-sample/WcfServiceLibrary.SampleHost/corewcf_ported.config";
            services.AddServiceModelServices();
            services.AddServiceModelConfigurationManagerFile(pathToXml);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseServiceModel();
        }
    }
}
