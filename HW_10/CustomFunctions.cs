////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 25/10/2022
// Last Modified On : 
// Description: custom functions
// Project: HW_10
////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    /// <summary>
    /// Прользовательские функции для обработки
    /// </summary>
    internal class CustomFunctions
    {
        /*public static StudentCard RequestCart(StudentCard card)
        { 
        
        }*/
        static Random random = new Random();
        /// <summary>
        /// Автозаполнение карточек студентов
        /// </summary>
        /// <param name="students">
        /// структура студентов к заполнению
        /// </param>
        /// <param name="countStudnts">
        /// количество студентов в группе по умолчанию
        /// </param>
        public static void FillStudentsAuto(StudentCard[] students, ushort countStudnts)
        {
            string RB;
            for (ushort i = 0; i < countStudnts; i++)
            {
                RB = GetRBRandom();

                StudentCard tmpCard = new StudentCard(
                    Faker.Name.First(),
                    Faker.Name.Middle(),
                    Faker.Name.Last(),
                    RB
                );
                students[i] = tmpCard;
            }
        }

        /// <summary>
        /// Генерация первых 2-х букв в номере зачетки
        /// </summary>
        /// <returns>
        /// 2 буквы, например, AD, AS, KD
        /// </returns>
        public static string GetRandomLetterts()
        {
           // Random random = new Random();
            
            const ushort FIRST_RAND_CHAR = 65;
            const ushort LAST_RAND_CHAR = 90;

            // берем рандом в диапазоне 65 - 90
            // в них содержаться коды символов букв от A до Z

            string letters;
            letters = string.Concat((char)random.Next(FIRST_RAND_CHAR, LAST_RAND_CHAR),
                    (char)random.Next(FIRST_RAND_CHAR, LAST_RAND_CHAR));

            return letters;
        }

        
        /// <summary>
        /// получаем рандомный номер зачетки 
        /// </summary>
        /// <returns>
        /// номер зачетки
        /// </returns>
        public static string GetRBRandom()
        {
            const int START_RAND_RB_RANGE = 100000;
            const int LAST_RAND_RB_RANGE = 999999;

            
            string recordBook = string.Empty;

            string letters = GetRandomLetterts();
            
            // задержку стафим, т.к. рандом возвращает одинаковые значения 
            //System.Threading.Thread.Sleep(5);
            int numbers = random.Next(START_RAND_RB_RANGE, 
                    LAST_RAND_RB_RANGE);

            recordBook = string.Concat(letters, numbers);

            return recordBook;
        }

        public static ushort GetGroupIndex(ConsoleKey groupNum)
        {
            ushort gourpNum = 0;

            switch (groupNum)
            {
                case ConsoleKey.NumPad1:
                    gourpNum = 0;
                    break;
                case ConsoleKey.NumPad2:
                    gourpNum = 1;
                    break;                    
                default:
                    gourpNum = 1603;
                    break;

             
            }
            return gourpNum;
        }

        public static void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}
