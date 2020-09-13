using Microsoft.Extensions.DependencyInjection;
using SSM.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SSM
{
   

    public partial class App : Application
	{

        private IServiceProvider serviceProvider;

        public App()
        {
            ConfigureServices();
            
        }

        private void ConfigureServices()
        {
            ServiceCollection services = new ServiceCollection();

            // Scope service to existing Groups interface and concrete implementation
            //services.AddScoped<IGroupsRepository, GroupsRepository>();

            // Alternative method using DbContext and Singleton
            //services.AddDbContext<GroupsDbContext>();
            services.AddSingleton<IGroupsRepository, GroupsRepository>();

            serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(serviceProvider.GetService<IGroupsRepository>());
            mainWindow.Show();
        }

    }
}
