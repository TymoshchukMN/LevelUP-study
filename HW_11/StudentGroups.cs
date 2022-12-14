////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 17/11/2022
// Last Modified On : 
// Description: Students groups
// Project: HW_11
////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    /// <summary>
    /// Класс группы студентов
    /// </summary>
    internal class StudentGroups
    {
        public const ushort MAX_STUDENT_IN_GROUP = 15;
        public const ushort DEF_STUDENT_IN_GROU = 7;

        #region FIELDS_PRORERTIES

        private StudentCard [] _card;

        //TODO: сделать ГЕТ студента 

        private string _groupName;

        /// <summary>
        /// название группы
        /// </summary>
        public string groupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
            }
        }

        #endregion FIELDS_PRORERTIES

        #region КОНСТРУКТОРЫ

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public StudentGroups(string groupName)
        {

            //     StudentCard[] cards = new StudentCard[DEFAULT_COUNT_STUDENTS];
            _card  = new StudentCard[DEF_STUDENT_IN_GROU];
            _groupName = groupName;
        }

        #endregion КОНСТРУКТОРЫ

        #region МЕТОДЫ

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
                //StudentCard Card = new StudentCard();
                StudentCard Card = _card[0];
                ResultCodes operationResult = ResultCodes.none;

                for (int i = 0; i < _card.Count(); i++)
                {
                    Card = _card[i];
                    Card.IsContainRB(index, out operationResult);
                    //_card[i].IsContainRB(index, out operationResult);

                    if (operationResult == ResultCodes.success)
                    {
                        Card = _card[i];
                        break;
                    }

                }

                return Card;
            }
            set
            {
                ResultCodes operationResult = ResultCodes.none;

                for (int i = 0; i < _card.Count(); i++)
                {
                    _card[i].IsContainRB(index, out operationResult);
                    if (operationResult == ResultCodes.success)
                    {
                        _card[i] = value;
                        break;
                    }
                    else
                    {
                        // добавить в конец
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="card">
        /// 
        /// </param>
        /// <param name="resultCode">
        /// 
        /// </param>
        public void AddStudent(StudentCard card, out ResultCodes resultCode)
        {

            //StudentCard tmpCard = new StudentCard();
            //_card[0] = tmpCard;
            resultCode = ResultCodes.none;

            if (_card.Count() + 1 > MAX_STUDENT_IN_GROUP)
            {
                resultCode = ResultCodes.exeptionStudentGroup;
            }
            else
            {
                Array.Resize(ref _card, _card.Length + 1);
                _card[_card.Count() - 1] = new StudentCard(card);

                resultCode = ResultCodes.success;
            }
            //resultCode = ResultCodes.success;
        }

        /// <summary>
        /// Автозаполнение группы студентов (выполняется разово)
        /// </summary>
        public void AutoFill()
        {
            for (ushort i = 0; i < DEF_STUDENT_IN_GROU; ++i)
            {
                _card[i] = new StudentCard();
            }
        }

        /// <summary>
        /// Проверка существует ли группа
        /// </summary>
        /// <param name="index">
        /// индекс для поиска
        /// </param>
        public void IsRBExist(string chekedRD, out ResultCodes resultCode)
        {
            resultCode = ResultCodes.success;

            for (ushort i = 0; i < _card.Count(); i++)
            {
                if (_card[i].recordBook == chekedRD)
                {
                    resultCode = ResultCodes.RBexist;
                    break;
                }
            }
        }

        /// <summary>
        /// Показываем список студентов в группе
        /// </summary>
        public void ListStudents()
        {
            //Console.Clear();
            Console.Write("\nСтуденты группы ");

            UI.ChangeColor(ConsoleColor.Cyan, groupName);
            Console.WriteLine();

            for (ushort i = 0; i < _card.Count(); i++)
            {
                Console.WriteLine($"\nИмя:\t\t{_card[i].firstName}");
                Console.WriteLine($"Отчество:\t{_card[i].middleName}");
                Console.WriteLine($"Фамилия:\t{_card[i].lastName}");
                Console.Write("Номер учетки:\t");

                UI.ChangeColor(ConsoleColor.Green,_card[i].recordBook);
                Console.WriteLine();
                Console.WriteLine(UI.board);
            }
        }

        public ResultCodes DeleteStudent(string recordBook,
           out ResultCodes operationResult)
        {
            operationResult = ResultCodes.none;

            ushort lastIndex = (ushort)(_card.Count() - 1);


            // получаем индекс карточки студениа к удалению
            ushort indexStudetForChange = GetStudentIndex(recordBook);

            if (indexStudetForChange == _card.Count() - 1)
            {
                Array.Resize(ref _card, _card.Count() - 1);
            }
            else
            {
                // сохраняем последнюю в массиве карточку
                StudentCard temCard = new StudentCard(_card[lastIndex]);

                _card[indexStudetForChange] = new StudentCard(temCard);
                Array.Resize(ref _card, _card.Count() - 1);
            }


            IsContainRB(recordBook, out operationResult);


            return operationResult;
        }

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
            for (ushort i = 0; i < _card.Count(); i++)
            {
                if (_card[i].recordBook == recordBook)
                {
                    studentIndex = i;
                    break;
                }
            }
            return studentIndex;
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

            for (ushort i = 0; i < _card.Count(); i++)
            {
                if (_card[i].recordBook == recordBook)
                {
                    operationResult = ResultCodes.error;
                    break;
                }
            }

            return operationResult;
        }

        #endregion МЕТОДЫ


    }
}
