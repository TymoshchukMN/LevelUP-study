////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 17/11/2022
// Last Modified On : 
// Description: Student card
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
    /// Класс информации студентов
    /// </summary>
    internal class StudentCard
    {
        static Random random = new Random();

        #region FIELDS_PRORERTIES

        private string _firstName;

        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
            }
        }

        private string _middleName;

        /// <summary>
        /// отчество пользователя
        /// </summary>
        public string middleName
        {
            get
            {
                return _middleName;
            }
            set
            {
                _middleName = value;
            }
        }

        private string _lastName;

        /// <summary>
        /// фамилия
        /// </summary>
        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
            }
        }

        private string _recordBook;

        /// <summary>
        /// номер учетки
        /// </summary>
        public string recordBook
        {
            get
            {
                return _recordBook;
            }
            private set // запрещаем редактировать номер учетки из вне
            {
                _recordBook = value;
            }
        }


        private string _addressResidential;
        
        /// <summary>
        /// Адрес проживания
        /// </summary>
        public string addressResidential
        {
            get { return _addressResidential; }
            set { _addressResidential = value; }
        }


        private string _addressRegistration;


        /// <summary>
        /// адрес прописки
        /// </summary>
        public string addressRegistration
        {
            get 
            {
                return _addressRegistration; 
            }
            set 
            {
                _addressRegistration = value;
            }
        }

        #endregion FIELDS_PRORERTIES

        #region Конструкторы


        public StudentCard(string firstName, string middleName, string lastName)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;

            _recordBook = GenerateRB();
        }

        /// <summary>
        /// конструктор по умолчанию на создание карточки студента
        /// </summary>
        /// <param name="firstName">
        /// Имя
        /// </param>
        /// <param name="middleName">
        /// Отчество
        /// </param>
        /// <param name="lastName">
        /// Фамилия
        /// </param>
        public StudentCard()
        {
            _firstName = Faker.Name.First();
            _middleName = Faker.Name.Middle();
            _lastName = Faker.Name.Last();
            _addressRegistration = Faker.Address.StreetAddress();
            _addressResidential = Faker.Address.StreetAddress();
            _recordBook = GenerateRB();
        }

        public StudentCard(string firstName, string middleName, string lastName, string RB
            , string addressRegistration, string addressResidential)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _addressRegistration = addressRegistration;
            _addressResidential = addressResidential;
            _recordBook = RB;
        }

        public StudentCard(StudentCard card)
        {
            _firstName = card.firstName;
            _middleName = card.middleName;
            _lastName = card.lastName;
            _recordBook = card.recordBook;
            _addressRegistration = card._addressRegistration;
            _addressResidential = card._addressResidential;
        }

        #endregion Конструкторы

        #region МЕТОДЫ

        /// <summary>
        /// Генерируем номер учетки
        /// </summary>
        /// <returns>
        /// Номер учетной книги
        /// </returns>
        private string GenerateRB()
        {
            
            // берем рандом в диапазоне 65 - 90
            // в них содержаться коды символов букв от A до Z

            const ushort FIRST_RAND_CHAR = 65;
            const ushort LAST_RAND_CHAR = 90;
            const ushort COUNT_NUMBERS = 6;

            string recordBook = string.Concat((char)random.Next(FIRST_RAND_CHAR
                    , LAST_RAND_CHAR)
                    , (char)random.Next(FIRST_RAND_CHAR, LAST_RAND_CHAR));

            for (ushort i = 0; i < COUNT_NUMBERS; i++)
            {

                recordBook = String.Concat(recordBook, random.Next(0, 9));
            }


            return recordBook;
        }

        /// <summary>
        /// Прверяем соответствеие учетки студента запрашиваемой
        /// </summary>
        /// <param name="recordBook">
        /// учетка для проверки
        /// </param>
        /// <returns>
        /// true - соотвествует
        /// false - не соотвутствует
        /// </returns>
        public ResultCodes IsContainRB(string recordBook, out ResultCodes operationResult)
        {
            operationResult = ResultCodes.error;

            if (_recordBook == recordBook)
            {
                operationResult = ResultCodes.success;
            }

            return operationResult;
        }

        /// <summary>
        /// Получение полной информации о студенте
        /// </summary>
        public void PrintFullStudentInfo()
        {
            UI.ClearPreviousConsoleLine();
            UI.ChangeColor(ConsoleColor.Magenta, "\n\nПолная информация о студенте:");
            //Console.WriteLine(");
            string BOARD = new string('=', 50);
            Console.WriteLine("\n{0}", BOARD);
            Console.Write($"Имя:\t\t\t{_firstName}\n" +
                $"Отчество:\t\t{_middleName}\n" +
                $"Фамилия:\t\t{_lastName}\n" +
                $"Адрес проживания:\t{_addressResidential}\n" +
                $"Адрес регистрации:\t{_addressRegistration}\n" +
                $"\nномер учетки:\t\t");
            UI.ChangeColor(ConsoleColor.Green,_recordBook);
            Console.WriteLine("\n{0}\n", BOARD);

        }


        public ResultCodes ChangeFild(FieldForChange field, string newVol, out  ResultCodes operationResult)
        {
            switch (field)
            {
                case FieldForChange.firstName:

                    _firstName = newVol;
                    operationResult = ResultCodes.success;
                    break;

                case FieldForChange.middleName:

                    _middleName = newVol;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.lastName:

                    _lastName = newVol;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.addressRegistration:

                    _addressRegistration = newVol;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.addressResidential:

                    _addressResidential = newVol;
                    operationResult = ResultCodes.success;

                    break;
                default:
                    operationResult = ResultCodes.error;
                    break;
            }

            return operationResult;
        }
        #endregion МЕТОДЫ


    }
}
