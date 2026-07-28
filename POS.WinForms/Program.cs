using Microsoft.Extensions.DependencyInjection;
using POS.Application.Interfaces;
using POS.Infrastructure.Data;
using POS.WinForms.Data;
using POS.WinForms.Forms;
using POS.WinForms.Forms.Login;

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

        // Migrasi + seed akun Manajer default (admin/admin) bila belum ada user.
        var factory = ServiceProvider.GetRequiredService<IDbConnectionFactory>();
        new Migration(factory).Run();
        ServiceProvider.GetRequiredService<IUserService>()
            .EnsureSeedAdminAsync().GetAwaiter().GetResult();

        // Login dulu; hanya lanjut ke menu utama bila berhasil.
        using (var login = ServiceProvider.GetRequiredService<LoginForm>())
        {
            if (login.ShowDialog() != DialogResult.OK)
                return;
        }

        var mainForm = ServiceProvider.GetRequiredService<MainForm>();
        System.Windows.Forms.Application.Run(mainForm);
    }
}
