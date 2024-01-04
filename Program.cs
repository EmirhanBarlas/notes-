using System;
using System.IO;
using System.Collections.Generic;

class CalendarNotesProgram
{
    static void Main()
    {
        Console.WriteLine("Tarih Formatı: yyyy-MM-dd");
        Console.Write("Not Eklemek İstediğiniz Tarihi Girin: ");
        string inputDate = Console.ReadLine();

        if (DateTime.TryParse(inputDate, out DateTime selectedDate))
        {
            Console.Write("Notunuzu Girin: ");
            string note = Console.ReadLine();

            // Notları dosyaya kaydet
            SaveNoteToFile(selectedDate, note);

            Console.WriteLine("Notunuz Başarıyla Kaydedildi!");
        }
        else
        {
            Console.WriteLine("Geçersiz Tarih Formatı!");
        }

        Console.ReadLine(); // Konsol penceresinin kapanmaması için bekle
    }

    static void SaveNoteToFile(DateTime date, string note)
    {
        // Notların kaydedileceği dosya adını oluştur
        string fileName = $"Notes_{date.Year}_{date.Month}.txt";

        // Notları dosyaya ekleyerek kaydet
        using (StreamWriter writer = File.AppendText(fileName))
        {
            writer.WriteLine($"[{date.ToShortDateString()}] {note}");
        }
    }
}
