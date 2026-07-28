namespace POS.WinForms.Data;

// Diimplementasikan form master data agar bisa dibuka mode "lihat saja"
// untuk role non-Manajer (tombol Simpan/Hapus dinonaktifkan).
public interface IReadOnlyForm
{
    void SetReadOnly();
}
