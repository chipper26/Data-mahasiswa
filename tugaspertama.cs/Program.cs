using System;
using System.Collections.Generic;

class Mahasiswa
{
    public string Nama { get; set; }
    public string NIM { get; set; }
}

class PembimbingAkademik
{
    private List<Mahasiswa> mahasiswaList = new List<Mahasiswa>();

    public void TambahMahasiswa(string nama, string nim)
    {
        Mahasiswa mahasiswaBaru = new Mahasiswa { Nama = nama, NIM = nim };
        mahasiswaList.Add(mahasiswaBaru);
        Console.WriteLine($"Mahasiswa atas nama {nama} dengan NIM {nim} berhasil ditambahkan.");
    }

    public void TampilkanDaftarMahasiswa()
    {
        Console.WriteLine("Daftar Mahasiswa:");
        foreach (Mahasiswa mahasiswa in mahasiswaList)
        {
            Console.WriteLine($"Nama: {mahasiswa.Nama}, NIM: {mahasiswa.NIM}");
        }
    }

    public void CariMahasiswa(string nama)
    {
        bool found = false;
        foreach (Mahasiswa mahasiswa in mahasiswaList)
        {
            if (mahasiswa.Nama.ToLower() == nama.ToLower())
            {
                Console.WriteLine($"Mahasiswa atas nama {nama} ditemukan dengan NIM {mahasiswa.NIM}.");
                found = true;
                break;
            }
        }
        if (!found)
        {
            Console.WriteLine($"Mahasiswa atas nama {nama} tidak ditemukan.");
        }
    }

    public void HapusMahasiswa(string nama)
    {
        Mahasiswa mahasiswaDihapus = null;
        foreach (Mahasiswa mahasiswa in mahasiswaList)
        {
            if (mahasiswa.Nama.ToLower() == nama.ToLower())
            {
                mahasiswaDihapus = mahasiswa;
                break;
            }
        }
        if (mahasiswaDihapus != null)
        {
            mahasiswaList.Remove(mahasiswaDihapus);
            Console.WriteLine($"Mahasiswa atas nama {nama} berhasil dihapus.");
        }
        else
        {
            Console.WriteLine($"Tidak dapat menemukan mahasiswa atas nama {nama}.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        PembimbingAkademik pembimbing = new PembimbingAkademik();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Tambahkan Mahasiswa Baru");
            Console.WriteLine("2. Tampilkan Daftar Mahasiswa");
            Console.WriteLine("3. Cari Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");

            Console.Write("Pilih menu: ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    Console.Write("Masukkan nama mahasiswa: ");
                    string nama = Console.ReadLine();
                    Console.Write("Masukkan NIM mahasiswa: ");
                    string nim = Console.ReadLine();
                    pembimbing.TambahMahasiswa(nama, nim);
                    break;
                case "2":
                    pembimbing.TampilkanDaftarMahasiswa();
                    break;
                case "3":
                    Console.Write("Masukkan nama mahasiswa yang ingin dicari: ");
                    string namaCari = Console.ReadLine();
                    pembimbing.CariMahasiswa(namaCari);
                    break;
                case "4":
                    Console.Write("Masukkan nama mahasiswa yang ingin dihapus: ");
                    string namaHapus = Console.ReadLine();
                    pembimbing.HapusMahasiswa(namaHapus);
                    break;
                case "5":
                    Console.WriteLine("Terima kasih! Keluar dari program.");
                    return;
                default:
                    Console.WriteLine("Pilihan tidak valid. Silakan pilih lagi.");
                    break;
            }
        }
    }
}
