using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodyProject.Installer
{
    public interface IInstaller
    {
        void InstallServicesAssembly(IServiceCollection services, IConfiguration configuration);
    }
}