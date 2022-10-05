using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov
{
    internal class Program
    {
        static int Task51(int a, int b)
        {
            return a > b ? a : b;
        }
        static void Task52(ref string a, ref string b)
        {
            (a, b) = (b, a);
            Console.WriteLine(a +" "+ b);
        }
        public static bool Task53(ref int num)
        {
            int nomer = num;
            num = 1;
            for (int i = 1; i <= nomer; i++)
                try
                {
                    checked
                    {
                        num *= i;
                    }
                }
                catch
                {
                    return false;
                }
            return true;
        }
        static int Task54(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * Task54(n-1);
        }
        static void Task511dz()
        {
            int nod;
            Console.WriteLine("введите первое число");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("введите второе число");
            int m = int.Parse(Console.ReadLine());
            while (m != n)
            {
                if (m > n)
                {
                    m = m - n;
                }
                else
                {
                    n = n - m;
                }
            }

            nod = n;
            Console.WriteLine("НОД: " + nod);

        }
        static void Task512dz()
        {
            Console.WriteLine("введите по очереди 3 числа");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int Nod = Math.Min(a, Math.Min(b, c));
            for (; Nod > 1; Nod--)
            {
                if (a % Nod == 0 && b % Nod == 0 && c % Nod == 0)
                    break;
            }
            Console.WriteLine("NOD: " + Nod);
        }
        static void Task52dz()
        {
            Console.WriteLine("введите порядковый номер числа ряда фиббоначи");
            int num = int.Parse(Console.ReadLine());
            if (num > 48)
                Console.WriteLine("извините программа на такие вычисление не способна");
            else if (num < 0) Console.WriteLine("числа под таким номером не существует");
            else
            {
                int perv = 1;
                int vtor = 1;
                int sum;

                int j = 2;
                while (j <= num)
                {
                    sum = perv + vtor;
                    perv = vtor;
                    vtor = sum;
                    j++;
                }
                Console.WriteLine("Под номером " + num + " в ряде Фибоначчи стоит число " + perv);
            }
        }
        static void Main(string[] args)
        {
            string s1 = "a";
            string s2 = "b";
            int a = 10;
            int b = 9;
            Console.WriteLine(Task51(a, b));
            Task52(ref s1, ref s2);
            Console.WriteLine("введите число факториал которого хотите получить");
            Console.WriteLine("Task53");
            Console.Write("dведите число, факториал которого нужно вычислить: ");
            int chislo = int.Parse(Console.ReadLine());
            bool result = Task53(ref chislo);
            Console.WriteLine($"{Convert.ToString(result)}, Факториал введенного вами числа равен {chislo}");
            Console.WriteLine();
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Join("", Task54(n)));
            Task511dz();
            Task512dz();
            Task52dz();
            Console.ReadKey();
        }
    }
}
