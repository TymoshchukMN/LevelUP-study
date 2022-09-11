using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW6_03092022
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите функцию для выполнения: \n" +
                "1. Палендром\n" +
                "2. Берем свою функцию и реализуем ее рекурсивно\n" +
                "3. Реку-я функция, которая выводит содержимое исходной строки\n" +
                "4. Ханойские башни");

            int userChoise = (int)Console.ReadKey().Key;


            switch ((TaskNumber)userChoise)
            {
                case TaskNumber.Firts:

                    Console.Clear();
                    CustomFunctions.LaunchTask1();

                    break;

                case TaskNumber.Second:

                    Console.Clear();
                    CustomFunctions.LaunchTask2();

                    break;

                case TaskNumber.Third:

                    Console.Clear();
                    CustomFunctions.LaunchTask3();

                    break;
            }

            Console.ReadKey();

        }


    }
}
