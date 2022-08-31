// дз с расписанием с битами, переделать используя перечисления с флагами
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

            // создание расписание
            CustomFunctions.CreateSchedule(ref preferedSchedule, ref currentSchedule, zero, plus);
            
            // показываем пользователю варианты выбора того, что делать после сохранения расписания
            Console.SetCursorPosition(0,9);
            
            // чё дальше
            CustomFunctions.ShowWhatToDoNext();

            // очистка текущей строки
            CustomFunctions.ClearCurrentConsoleLine();

            char usersAnswer;

            do
	        {
                usersAnswer = Console.ReadKey().KeyChar;
                if (usersAnswer == '-')
                {
                    // оичстка текуще строки
                    CustomFunctions.ClearCurrentConsoleLine();

                    // сброс расписания используя побитовые НЕ и И
                    currentSchedule = (byte)(~currentSchedule & currentSchedule);

                    // отображение расписания
                    CustomFunctions.DisplayCurrentSchedule(currentSchedule);
                
                    Console.SetCursorPosition(0,8);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Schedule reseted");
                    Console.ForegroundColor = ConsoleColor.Gray;

                    // чё дальше
                    CustomFunctions.ShowWhatToDoNext();
                }
                else
                {
                    if (usersAnswer == '/')
                    {
                        // изменение расписания
                        Console.Clear();

                        // повторный вызов функции на создание расписания
                        CustomFunctions.CreateSchedule(ref preferedSchedule, ref currentSchedule, zero, plus);
                    }
                }            
	        } while (usersAnswer != zero);
            
            Console.ReadKey();

            #endregion task 1

        }      
    }
}
