using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW7
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Выберите задачу для запуска:\n\n" +
                "1. min, max в массиве поменять местами\n" +
                "2. Смещение внутри массива\n" +
                "3. Сортировка массива\n");

            // получаем от пользователя ответ по замуску задач и преобразуем его в Enum
            EnumTasks userChoise = (EnumTasks)Console.ReadKey().Key;

            Console.Clear();

            switch (userChoise)
            {
                case EnumTasks.first:
                    
                    // min, max в массиве поменять местами
                    CustomFunctions.ReplaceArrayElenents();
                    break;
                case EnumTasks.second:

                                       // вызов задачи на смещение
                    CustomFunctions.LaunchTask2();
                    break;
                case EnumTasks.third:

                    CustomFunctions.LaunchTask3();
                    // вызов задачи на сортировку

                    break;

            }


            


            Console.ReadKey();
        }

       
    }
}
