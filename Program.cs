using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Введення шляху до файлу
        string filePath = "path_to_your_file.txt";

        try
        {
            // Зчитування всього тексту з файлу
            string text = File.ReadAllText(filePath);

            // Пошук слів "LINQ" та "мова запитів"
            var linqCount = text.Split(new[] { ' ', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                .Count(word => word.Equals("LINQ", StringComparison.OrdinalIgnoreCase));

            var phraseCount = text.Split(new[] { ' ', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Where(word => word.Equals("мова", StringComparison.OrdinalIgnoreCase))
                                  .Zip(text.Split(new[] { ' ', '\n', '\r', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Where(word => word.Equals("запитів", StringComparison.OrdinalIgnoreCase)),
                                  (first, second) => 1).Count();

            // Виведення результатів
            Console.WriteLine($"Кількість повторень слова 'LINQ': {linqCount}");
            Console.WriteLine($"Кількість повторень фрази 'мова запитів': {phraseCount}");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не знайдений.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
