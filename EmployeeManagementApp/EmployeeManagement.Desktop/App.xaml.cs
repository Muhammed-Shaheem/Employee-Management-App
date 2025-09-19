using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Windows;
using EmployeeManagementLibrary;
using EmployeeManagementLibrary.Data;
using EmployeeManagementLibrary.Database;

namespace EmployeeManagement.Desktop;


public partial class App : Application
{
    public static ServiceProvider serviceProvider;
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var services = new ServiceCollection();
        services.AddTransient<IDatabaseDb, SqlDb>();
        services.AddTransient<MainWindow>();
        services.AddTransient<IDatabaseData, SqlData>();

        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
        IConfiguration builder = config.Build();
        services.AddSingleton(builder);

        serviceProvider = services.BuildServiceProvider();
        var mainWindow = serviceProvider.GetService<MainWindow>();

        mainWindow?.Show();

    }
}

