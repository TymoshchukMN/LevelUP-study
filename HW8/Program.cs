using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomClass;



// МНОГОМЕРНЫЕ МАССИВЫ
namespace HW8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Выберите задачу для запуска:\n\n" +
              "1. Из одномерного массива сделать двумерный с заполнением: \"↑↓\" \"← →\" \n" +
              "2. Найти минимальный и максимальный элемент в двумерном массиве и поменять их местами \n" +
              "   Поменять строки или столбцы местами, содержажщие минимальный и максимальный элементы");

            // получаем от пользователя ответ по запуску задач и преобразуем его в Enum
            EnumTasks userChoise = (EnumTasks)Console.ReadKey().Key;

            Console.Clear();

            switch (userChoise)
            {
                case EnumTasks.first:

                     // Из одномерного массива сделать двумерный с заполнением:
	                 // - ↑↓
	                 // - ← →                     
                    CustomFunctions.LaunchTask1();

                    break;
                case EnumTasks.second:

                    // Найти минимальный и максимальный элемент в двумерном массиве и поменять их местами
                    CustomFunctions.LaunchTask2();

                    break;
                case EnumTasks.third:

                    break;

            }

            
        }
    }
}
