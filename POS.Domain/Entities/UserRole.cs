namespace POS.Domain.Entities;

// Peran pengguna (disimpan sebagai teks di kolom role).
public static class UserRole
{
    public const string Manajer = "Manajer";
    public const string Stocker = "Stocker";
    public const string Kasir = "Kasir";

    public static readonly string[] All = { Manajer, Stocker, Kasir };

    public static bool IsValid(string role) => All.Contains(role);
}
