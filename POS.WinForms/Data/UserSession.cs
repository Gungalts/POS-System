using POS.Domain.Entities;

namespace POS.WinForms.Data;

// Menyimpan user yang sedang login (singleton). Diisi LoginForm, dibaca form lain.
public class UserSession
{
    public UserAccount? CurrentUser { get; set; }

    public bool IsManajer => CurrentUser?.Role == UserRole.Manajer;
    public bool IsStocker => CurrentUser?.Role == UserRole.Stocker;
    public bool IsKasir => CurrentUser?.Role == UserRole.Kasir;
}
