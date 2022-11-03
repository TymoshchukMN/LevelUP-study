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

        const ushort DEFAULT_COUNT_STUDENTS = 10;
        const ushort MAX_COUNT_STUDENT = 12;

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

        public StudentsGroup(GroupNames groupName, StudentCard[] card)
        {
            _groupName = groupName.ToString();
            _studentCards = card;
        }

        #region INDEXATOR

        /// <summary>
        /// indexator
        /// </summary>
        /// <param name="index"></param>
        /// <returns>
        /// card by RBnumber
        /// </returns>
        public StudentCard this[string index]
        {
            get
            {
                StudentCard Card = new StudentCard();

                for (int i = 0; i < _studentCards.Count(); i++)
                {
                    Card = _studentCards[i];

                    if (Card.IsContainRB(index) == ResultCodes.success)
                    {
                        Card = _studentCards[i];
                        break;
                    }

                }

                return Card;
            }
            set
            {
                StudentCard Card = new StudentCard();

                for (int i = 0; i < _studentCards.Count(); i++)
                {
                    if (_studentCards[i].IsContainRB(index) == ResultCodes.success)
                    {
                        _studentCards[i] = value;
                        break;
                    }                  
                }
            }
        }

        /// <summary>
        /// возвра карточки по индексц
        /// </summary>
        /// <param name="index">
        /// индекс возвращаемой карточки
        /// </param>
        /// <returns>
        /// карточка
        /// </returns>
        public StudentCard this[ushort index]
        {
            get
            {
                return _studentCards[index];
            }
            set 
            {
                /* set the specified index to value here */ 
            
            }
        }
        
        #endregion INDEXATOR

        /// <summary>
        /// получение индекса карточки студента в группе
        /// </summary>
        /// <param name="recordBook">
        /// номер зачетки
        /// </param>
        /// <returns>
        /// индекс карточки
        /// </returns>
        public ushort GetStudentIndex(string recordBook)
        {
            ushort studentIndex = 0;
            for (ushort i = 0; i < _studentCards.Count(); i++)
            {
                if (_studentCards[i].recordBook == recordBook)
                {
                    studentIndex = i;
                    break;
                }
            }
            return studentIndex;
        }



        /// <summary>
        /// Добавление нового студента в группу
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="middleName"></param>
        /// <param name="lastName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="address"></param>
        /// <param name="email"></param>
        /// <param name="recordBook"></param>
        /// <returns>
        /// код выполнения
        /// </returns>
        public ResultCodes AddStudent(string firstName, string middleName,
            string lastName, string phoneNumber, string address, string email,
            string recordBook, out ResultCodes operationResult)
        {
            operationResult = ResultCodes.none;

            if (_studentCards.Length + 1 >= MAX_COUNT_STUDENT)
            {
                operationResult = ResultCodes.exeptionStudentGroup;
            }
            else
            {
                Array.Resize(ref _studentCards, _studentCards.Length + 1);

                ushort indexNewStudent = (ushort)(_studentCards.Length - 1);

                _studentCards[indexNewStudent].firstName = firstName;
                _studentCards[indexNewStudent].middleName = middleName;
                _studentCards[indexNewStudent].lastName = lastName;
                _studentCards[indexNewStudent].phoneNumber = phoneNumber;
                _studentCards[indexNewStudent].address = address;
                _studentCards[indexNewStudent].email = email;
                _studentCards[indexNewStudent].recordBook = recordBook;

                operationResult = ResultCodes.success;
            }            

            return operationResult;
        }

        public ResultCodes DeleteStudent(string recordBook, out ResultCodes operationResult)
        {
            operationResult = ResultCodes.none;

            ushort lastIndex = (ushort)(_studentCards.Count() - 1);
            
            // сохраняем последнюю в массиве карточку
            StudentCard temCard = _studentCards[lastIndex];
            
            // получаем индекс карточки студениа к удалению
            ushort indexStudetForChange = GetStudentIndex(recordBook);

            _studentCards[indexStudetForChange] = temCard;
            Array.Resize(ref _studentCards, _studentCards.Count() - 1);
            IsContainRB(recordBook, out operationResult);
            
               

            return operationResult;
        }

        /// <summary>
        /// Проверка содержит ли карточки студентов номер зачетки
        /// </summary>
        /// <param name="recordBook">
        /// номер учетки
        /// </param>
        /// <param name="operationResult">
        /// код операции
        /// </param>
        /// <returns>
        /// код операции
        /// </returns>
        private ResultCodes IsContainRB(string recordBook, 
                out ResultCodes operationResult)
        {
            operationResult = ResultCodes.success;

            for (ushort i = 0; i < _studentCards.Count(); i++)
            {
                if (_studentCards[i].recordBook == recordBook)
                {
                    operationResult = ResultCodes.error;
                    break;
                }
            }

            return operationResult;
        }

        /// <summary>
        /// выводим список студентов в группк
        /// </summary>
        /// <param name="group">
        /// группа для отображения
        /// </param>
        public void ListStudentsInGroup()
        {
            Console.Clear();
            Console.Write("List students in group:\t");

            UI.PrintStritgOtherColor(_groupName, ConsoleColor.Yellow);

            Console.WriteLine("\n\n");
            for (ushort i = 0; i < _studentCards.Count(); ++i)
            {
                //_studentCards[i].PrintStudentInfo();

                Console.Write($"Full name:\t{_studentCards[i].firstName} " +
                    $"{_studentCards[i].middleName} " +
                $"{_studentCards[i].lastName}" +
                $"\nRecordBook:\t");
                
                UI.PrintStritgOtherColor(_studentCards[i].recordBook, ConsoleColor.Green);
                
                Console.WriteLine("\n");


            }
        }

        /// <summary>
        /// Получаем количество студентов в группе
        /// </summary>
        /// <returns></returns>
        public ushort GetCountStudents()
        {
            return (ushort)_studentCards.Count();
        
        }

    }
}
