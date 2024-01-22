using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PR10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Нажмите: Y чтобы продолжить \n\t N чтобы прекратить");
                string select_key = Console.ReadLine();

                switch (select_key)
                {
                    case "Y":

                        try
                        {
                            Console.Title = "Практическая работа №10";
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = ConsoleColor.Black;

                            string div = " ";
                             Console.WriteLine("Здравствуйте!");
                            Console.WriteLine("1 - Ввод матрицы");
                            Console.WriteLine("2 - Случайная матрица");
                            Console.Write("-> ");
                            int menu = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            if (menu != 1 && menu != 2) 
                            {
                                Console.WriteLine("Вы вводите недопустимое значение!");
                                Console.ReadKey();
                                Environment.Exit(0);
                            }

                            Console.Write("Введите размер квадратной матрицы: ");
                            int matrix = Convert.ToInt32(Console.ReadLine());
                            if (matrix <= 0)
                            {
                                throw new Exception("Размер матрицы меньше или равно нулю!");
                            }
                            Console.WriteLine();

                            // Объявление матрицы
                            int[,] m = new int[matrix, matrix];

                            switch (menu)
                            {
                                case 1:
                                    Console.WriteLine("Заполнение матрицы: ");
                                    for (int y = 0; y < matrix; y++)
                                    {
                                        for (int x = 0; x < matrix; x++)
                                        {
                                            Console.Write("Введите матрицу [" + x + ", " + y + "]: ");
                                            m[x, y] = Convert.ToInt32(Console.ReadLine());
                                        }
                                    }
                                    Console.WriteLine();
                                    break;
                                case 2:
                                    Console.Write("Введите левую границу случайных чисел = ");
                                    int left = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("Введите правую границу случайных чисел = ");
                                    int right = Convert.ToInt32(Console.ReadLine());
                                    if (left == right)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("Конечное и начальное значения одинаковы");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Clear();
                                    }
                                    m[0, 0] = left;
                                    Random rand = new Random();
                                   
                                    for (int y = 1; y < matrix; y++)
                                        for (int x = 1; x < matrix; x++)
                                            m[x, y] = rand.Next(1, 10);
                                    m[matrix - 1,matrix - 1] = right;

                                    break;
                            }

                            Console.WriteLine("Матрица:");
                            for (int y = 0; y < matrix; y++)
                            {
                                for (int x = 0; x < matrix; x++)
                                {
                                    if (x == y)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                    }
                                    Console.Write(m[x, y] + div);
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                Console.WriteLine();
                            }

                            // Поиск минимального по модулю диагональный элемент
                            int min = Math.Abs(m[0, 0]);
                            for (int y = 0; y < matrix; y++)
                            {
                                for (int x = 0; x < matrix; x++)
                                {
                                    if (x == y && Math.Abs(m[x, y]) < min)
                                    {
                                        min = Math.Abs(m[x, y]);
                                    }
                                }
                            }
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("\nМинимальный по модулю диагональный элемент = " + min + "\n");
                            Console.ForegroundColor = ConsoleColor.White;

                            Console.WriteLine("Вывод новой матрицы:");
                            for (int y = 0; y < matrix; y++)
                            {
                                bool flag = false;
                                for (int x = 0; x < matrix; x++)
                                {
                                    if (x == y)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        m[x, y] = min;
                                        Console.Write(m[x, y] + div);
                                        flag = true;
                                    }
                                    else
                                    {
                                        m[x, y] = (flag) ? 1 : 2;
                                        Console.Write(m[x, y] + div);
                                    }
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                Console.WriteLine();
                            }
                            Console.ReadKey();
                        }

                        catch (IndexOutOfRangeException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Размер матрицы не может равняться нулю!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        catch (FormatException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Вы вводите недопустимое значение!");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        catch (Exception e)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Ошибка: что-то пошло не так: " + e.Message);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "N":
                        Console.WriteLine();
                        Environment.Exit(0);
                        break;
                }

            }    
        }
    }
}
