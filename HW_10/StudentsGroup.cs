////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 25/10/2022
// Last Modified On : 
// Description: struct for containing students groups
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
    /// Структура групп студентов
    /// </summary>
    internal struct StudentsGroup
    {
        private string _groupName;
        private StudentCard[] _studentCards;

        const ushort DEFAULT_COUNT_STUDENTS = 30;

        /// <summary>
        /// Конструктор создания группы
        /// </summary>
        /// <param name="groupName">
        /// имя группы, передается через Enum GroupNames
        /// </param>
        /// <param name="isManualFill">
        /// true - заполнение руками
        /// false - заполнение автоматически
        /// </param>
        public StudentsGroup(GroupNames groupName, bool isManualFill)
        {
            if (!isManualFill)
            {
                StudentCard[] cards = new StudentCard[DEFAULT_COUNT_STUDENTS];
                CustomFunctions.FillStudentsAuto(cards, DEFAULT_COUNT_STUDENTS);

                _groupName = groupName.ToString();
                _studentCards = cards;
            }
            else
            {
                StudentCard[] cards = new StudentCard[DEFAULT_COUNT_STUDENTS];
                _groupName = groupName.ToString();
                _studentCards = cards;
            }
            
        }

        public StudentsGroup(GroupNames groupName, StudentCard [] card)
        {
            _groupName = groupName.ToString();
            _studentCards = card;
        }

        /// <summary>
        /// выводим список студентов в группк
        /// </summary>
        /// <param name="group">
        /// группа для отображения
        /// </param>
        public void ListStudentsInGroup(/*GroupNames group*/)
        {
            Console.Write("Group:\t");
            UI.PrintStritgOtherColor(_groupName, ConsoleColor.Yellow);
            Console.WriteLine("\n\n");
            for (ushort i = 0; i < _studentCards.Count(); ++i)
            {
                _studentCards[i].PrintFullName();
            }          
        }

        //public string PrintStudentInGroup(string recordBook)
        //{

        //    for (int i = 0; i < _studentCards.Count(); i++)
        //    {
        //        if (_studentCards[i].GetRB().Contains(recordBook))
        //        {
        //            return _studentCards[i].PrintFullName;
        //        }
        //    }
        //}
    }
}
