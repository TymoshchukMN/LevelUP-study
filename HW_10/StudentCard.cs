////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 25/10/2022
// Last Modified On : 
// Description: struct for containing student card
// Project: WH_10
////////////////////////////////////////////

using System;


namespace HW_10
{
    /// <summary>
    /// Studenst card
    /// </summary>
    internal struct StudentCard
    {
        private string _firstName;    // имя
        private string _middleName;   // отчество
        private string _lastName;     // фамилия
        private string _recordBook;   // номер зачетки

        /// <summary>
        /// конструктор создания карточки
        /// </summary>
        public StudentCard(string firstName, string middleName, 
            string lastName, string recordBook)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _recordBook = recordBook;
        }

        /// <summary>
        /// Получение имени студента
        /// </summary>
        public void PrintFullName()
        {
            Console.Write($"Full name:\t{_lastName} {_middleName} {_firstName}" +
                $"\nRecordBook:\t");
            UI.PrintStritgOtherColor(_recordBook, ConsoleColor.Green);
            Console.WriteLine("\n");

        }

        public string GetRB()
        {
            return _recordBook;
        }
    }
}
