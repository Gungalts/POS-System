using Microsoft.Extensions.DependencyInjection;
using POS.Infrastructure.Data;
using POS.WinForms.Data;
using POS.WinForms.Forms;

namespace POS.WinForms;

internal static class Program
{
    public static IServiceProvider ServiceProvider { get; private set; } = null!;

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var services = new ServiceCollection();
        services.AddPosServices("Data Source=pos.db");
        ServiceProvider = services.BuildServiceProvider();

        // Migrasi
        var factory = ServiceProvider.GetRequiredService<IDbConnectionFactory>();
        new Migration(factory).Run();

        var mainForm = ServiceProvider.GetRequiredService<MainForm>();
        System.Windows.Forms.Application.Run(mainForm);
    }
}