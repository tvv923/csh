using System;
using les2_2;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        MusicalInstrument vio = new Violin("Скрипка", "Інструмент з чотирма струнами.", "Скрипка виникла у XVI столітті.");        
        MusicalInstrument tro = new Trombone("Тромбон", "Духовий музичний інструмент.", "Тромбон з'явився у XV столітті."); 
        MusicalInstrument uku = new Ukulele("Укулеле", "Різновид гітари з чотирма струнами.", "Укулеле з'явилась у ХІХ столітті.");
        MusicalInstrument cel = new Cello("Віолончель", "Смичковий інструмент з чотирма струнами.", "Віолончель з'явилася у XVI столітті.");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Музичні інструменти.");
            Console.WriteLine("1. Скрипка.");
            Console.WriteLine("2. Тромбон.");
            Console.WriteLine("3. Укулеле.");
            Console.WriteLine("4. Віолончель.");
            Console.WriteLine("5. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    vio.Show();
                    vio.Desc();
                    vio.HistoryInfo();
                    vio.Sound();
                    vio.AfterShow();
                    break;
                case "D2":
                    tro.Show();
                    tro.Desc();
                    tro.HistoryInfo();
                    tro.Sound();
                    tro.AfterShow();
                    break;
                case "D3":
                    uku.Show();
                    uku.Desc();
                    uku.HistoryInfo();
                    uku.Sound();
                    uku.AfterShow();
                    break;
                case "D4":
                    cel.Show();
                    cel.Desc();
                    cel.HistoryInfo();
                    cel.Sound();
                    cel.AfterShow();
                    break;
                case "D5":
                    return;
            }

        }
    }
}
