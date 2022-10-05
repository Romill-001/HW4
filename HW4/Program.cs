using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HW4
{
    enum LvlAnge
    {
        добрый = 1, ворчит = 2,чутка_злой = 3, злой_шо_капец = 4
    }
    struct Ded
    {
        public string name;
        public byte lvlanger;
        public string[] phrases;
        public byte hits;
        public Ded(string Name,byte LvlAnger, string[] Phrases,byte Hits )
        {
            this.name = Name;
            this.lvlanger = LvlAnger;   
            this.phrases = Phrases;
            this.hits = Hits;
        }
    }
    internal class Program
    {
        static byte Task6(Ded ded, params string[] array)
        {
            foreach(string i in ded.phrases )
            {
                if(array.Contains(i))
                {
                    ded.hits += 1;
                }
            }
            return ded.hits;
        }
        static void Task1()
        {
            Console.WriteLine("введите значения коэффицентов по очереди");
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            double d = b * b - 4 * a * c;
            if (d < 0)
            {
                Console.WriteLine("корней нет");
            }
            else if(d > 0)
            {
                double x1 = (-b + Math.Sqrt(d))/2*a;
                double x2 = (-b + Math.Sqrt(d)) / 2 * a;
                Console.WriteLine("корни квадратного уравнения: {0} , {1}", x1,x2);
            }
            else if( d == 0)
            {
                double x3 = -b / (2 * a);
                Console.WriteLine("единственный корень: {0}", x3);
            }
        }
        static void Task2()
        {
            Random rnd = new Random();
            int[] a = new int[20];
            a[0] = rnd.Next(0, 101);
            for (int i = 1; i < 20;)
            {
                int num = rnd.Next(0, 101);
                int j;
                for (j = 0; j < i; j++)
                {
                    if (num == a[j])
                        break; 
                }
                if (j == i)
                { 
                    a[i] = num; 
                    i++; 
                }
            }
                Console.WriteLine(String.Join(" ", a));
            Console.WriteLine("введите 2 числа которые хотите поменять");
            int ind1 = Array.IndexOf(a,int.Parse(Console.ReadLine()));
            int ind2 = Array.IndexOf(a,int.Parse(Console.ReadLine()));
            (a[ind1], a[ind2]) = (a[ind2], a[ind1]);
            Console.WriteLine(string.Join(" ", a));
        }
        static int[] Task3(int[] mas)
        {
            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }
            }
            return mas;
        }
        static int Task4(ref int n1,out double n2, params int[] array)
        {

            for(int i = 0;i < array.Length; i++)
            {
                n1*= array[i];  
            }
            Console.WriteLine("произведение массива: {0}", n1);
            n2 = array.Sum() / array.Length;
            Console.WriteLine("ср арифметическое массива: {0}", n2);
            int n4  = array.Sum();
            Console.WriteLine("сумма массива");
            return n4;
        }
        //static int[] Task7(int[] a, int first, int last)
        //{
        //    int i = first;
        //    int j = last;
        //    int pivot = a[last];
        //    while (i <= j)
        //    {
        //        while (a[i] < pivot)
        //        {
        //            i++;
        //        }
        //        while (a[j] > pivot)
        //        {
        //            j--;
        //        }
        //    }
        //    if (i <= j)
        //    {

        //        (a[i], a[j]) = (a[j], a[i]);
        //        i ++;
        //        j --;
        //    }
        //    return a;
        //}
        static void Task5()
        {

            var numbers = new Dictionary<int, string>()
            {
                [0] = "###" + "\n" + "# #" + "\n" + "# #" + "\n" + "# #" + "\n" + "###",
                [1] = " # " + "\n" + "## " + "\n" + " # " + "\n" + " # " + "\n" + "###",
                [2] = " # " + "\n" + "# #" + "\n" + "  #" + "\n" + " # " + "\n" + "###",
                [3] = "## " + "\n" + "  #" + "\n" + " # " + "\n" + "  #" + "\n" + "## ",
                [4] = "# #" + "\n" + "# #" + "\n" + "###" + "\n" + "  #" + "\n" + "###",
                [5] = "###" + "\n" + "#  " + "\n" + "###" + "\n" + "  #" + "\n" + "## ",
                [6] = " ##" + "\n" + "#  " + "\n" + "###" + "\n" + "# #" + "\n" + "###",
                [7] = "###" + "\n" + "  #" + "\n" + "  #" + "\n" + " # " + "\n" + " # ",
                [8] = "###" + "\n" + "# #" + "\n" + " # " + "\n" + "# #" + "\n" + "###",
                [9] = "###" + "\n" + "# #" + "\n" + "###" + "\n" + "  #" + "\n" + "###",
            };
            Console.WriteLine("ввести число либо завершить работу. нажмите: (0 // 1)");
            int input = int.Parse(Console.ReadLine());
            if (input == 0)
            {
                try
                {
                    Console.WriteLine("введите число");
                    int vvod = int.Parse(Console.ReadLine());
                    if (vvod>= 0 && vvod <= 9)
                    {
                        Console.WriteLine(numbers[vvod]);
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Ошибка!!!");
                        System.Threading.Thread.Sleep(3000);
                        Console.ResetColor();
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("напишите закрыть или exit...");
                string exit = Console.ReadLine();
                if (exit == "exit" || exit == "Exit" || exit == "закрыть" || exit == "Закрыть")
                {
                    Environment.Exit(0);
                }
            }
        }
        static int[] Task7(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                Task7(array, leftIndex, j);
            if (i < rightIndex)
                Task7(array, i, rightIndex);
            return array;
        }

        static void Main(string[] args)
        {
            string[] d1 = { "проституки!", "гады" };
            Ded ded1 = new Ded("Михал Иваныч", 1,d1,0);
            string[] d2 = { "проститутки!","тимоплеер","гандон" };
            Ded ded2 = new Ded("Азат Залялетдинов", 2, d2, 0);
            string[] d3 = { "проституки!", "гады", "сын бляди!", "тимоплеер", "юмиплеер" };
            Ded ded3 = new Ded("Камиль Ахметзянов", 3, d3, 0);
            string[] d4 = { "проституки!","хорошая работа олег" };
            Ded ded4 = new Ded("Халиль Зиганшин", 1, d4, 0);
            string[] d5 = { "проституки!", "камень я не дам._." };
            Ded ded5 = new Ded("Степан Борисов", 4, d5, 0);
            string[] slova = { "проституки!", "гады", "отлично", "водка", "пиво", "самогон", "михалыч", "сын бляди!","тимоплеер","юмиплеер","ТЫ ЖЕ ЗНАЕШЬ ЧТО Я ВОЕВАЛ,СЫНОК ТЫ ГРЁБАНЫЙ" };
            int n1 = 1;
            double n2 = 1;
            Console.WriteLine("Task1" + "\n");
            Task1();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Task2" + "\n");
            Task2();
            Console.ReadKey();
            Console.Clear();
            int[] n3 = { 1, 4, 3, 2, 5, 7, 10, 9, 6 ,8};
            Console.WriteLine("Task3" +"\t"+ string.Join(" ",Task3(n3)));
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("Task4");
            Console.WriteLine(Task4(ref n1,out n2, n3));
            Console.ReadKey();
            Console.Clear();
            Task5();
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine("количество синяков от бабки: " + Task6(ded1,slova));
            Console.WriteLine("количество синяков от бабки: " + Task6(ded2, slova));
            Console.WriteLine("количество синяков от бабки: " + Task6(ded3, slova));
            Console.WriteLine("количество синяков от бабки: " + Task6(ded4, slova));
            Console.WriteLine("количество синяков от бабки: " + Task6(ded5, slova));
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(string.Join(" ",Task7(n3, 0, n3.Length-1)));
            Console.ReadKey();
        }
    }
}
