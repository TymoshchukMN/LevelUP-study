// дз с расписанием с битпми, переделать используя перечисления с флагами
// рефакторинг используя функции
// функция swap, которая меняет занчения между собой a → b, b → a, количество аргументов может быть произвольной + произвольный вид передачи параметров


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region task 1

            // предпочитаемое расписание
            byte preferedSchedule = 0b00000000;

            // фактическое расписание
            byte currentSchedule = 0b00000000;  
            
            char zero = '0';
            char plus = '+';

            // вывод текущего расписания
            CustomFunctions.DisplayCurrentSchedule(currentSchedule);

            // отображение предпочитаемого расписания
            CustomFunctions.DisplayPreferedSchedule(preferedSchedule);

            // всоздание расписание
            CustomFunctions.CreateSchedule(ref preferedSchedule, ref currentSchedule, zero, plus);
            Console.SetCursorPosition(0,9);
            Console.WriteLine("For reseting pass, press '-', for changing, press '/', or any another symbol for finish");
            CustomFunctions.ClearCurrentConsoleLine();

            char usersAnswer = Console.ReadKey().KeyChar;

            if (usersAnswer == '-')
            {
                // оичстка текуще строки
                CustomFunctions.ClearCurrentConsoleLine();

                // сброс расписания используя побитовые НЕ и И
                currentSchedule = (byte)(~currentSchedule & currentSchedule);

                // отображение расписания
                CustomFunctions.DisplayCurrentSchedule(currentSchedule);

            }
            else
            {
                if (usersAnswer == '/')
                {
                    // изменение расписания
                    Console.Clear();
                    CustomFunctions.CreateSchedule(ref preferedSchedule, ref currentSchedule, zero, plus);
                }
            }

            Console.ReadKey();

            #endregion task 1

        }

       
    }
}
