using System;
using les4_2;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Matrix matrix1 = new Matrix(2, 3);
        Matrix matrix2 = new Matrix(2, 3);
        Matrix matrix3 = new Matrix(3, 2);
        for (int i = 0; i < 2; i++)       
            for (int j = 0; j < 3; j++)
            {
                matrix1[i, j] = i + j;
                matrix2[i, j] = i - j;
            }
        for (int i = 0; i < 3; i++)       
            for (int j = 0; j < 2; j++)           
                matrix3[i, j] = i * j;        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Маємо 3 матриці:");
            Console.WriteLine("1:");
            Console.WriteLine(matrix1);
            Console.WriteLine("2:");
            Console.WriteLine(matrix2);
            Console.WriteLine("3:");
            Console.WriteLine(matrix3);
            Console.WriteLine("Що будемо робити:");
            Console.WriteLine("1. Матриця 1 + Матриця 2.");
            Console.WriteLine("2. Матриця 1 - Матриця 2.");
            Console.WriteLine("3. Матриця 1 * Матриця 3.");
            Console.WriteLine("4. Матриця 1 * число 5.");
            Console.WriteLine("5. Матриця 1 == Матриця 2. Матриця 1 == Матриця 1.");
            Console.WriteLine("6. Матриця 1 != Матриця 2. Матриця 1 != Матриця 1.");
            Console.WriteLine("7. Матриця 1 Equals Матриця 2.");
            Console.WriteLine("8. Вихід.");
            Console.WriteLine("Ваш вибір.");
            ConsoleKeyInfo cki = Console.ReadKey(true);
            switch (cki.Key.ToString())
            {
                case "D1":
                    Console.WriteLine("M1 + M2:");
                    Console.WriteLine(matrix1 + matrix2);
                    matrix1.AfterShow();
                    break;
                case "D2":
                    Console.WriteLine("M1 - M2:");
                    Console.WriteLine(matrix1 - matrix2);
                    matrix1.AfterShow();
                    break;
                case "D3":
                    Console.WriteLine("M1 * M3:");
                    Console.WriteLine(matrix1 * matrix3);
                    matrix1.AfterShow();
                    break;
                case "D4":
                    Console.WriteLine("M1 *5:");
                    Console.WriteLine(matrix1 * 5);
                    matrix1.AfterShow();
                    break;
                case "D5":
                    Console.WriteLine($"M1 == M2: {matrix1 == matrix2}");
                    Console.WriteLine($"M1 == M1: {matrix1 == matrix1}");
                    matrix1.AfterShow();
                    break;
                case "D6":
                    Console.WriteLine($"M1 != M2: {matrix1 != matrix2}");
                    Console.WriteLine($"M1 != M1: {matrix1 != matrix1}");
                    matrix1.AfterShow();
                    break;
                case "D7":
                    Console.WriteLine($"M1 Equals M2: {matrix1.Equals(matrix2)}");
                    matrix1.AfterShow();
                    break;
                case "D8":
                    return;
            }
        }
    }
}
