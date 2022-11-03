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
        #region DATA

        private string _firstName;    // имя
        private string _middleName;   // отчество
        private string _lastName;     // фамилия
        private string _phoneNumber;
        private string _address;
        private string _email;
        private string _recordBook;   // номер зачетки

        #endregion DATA


        /// <summary>
        /// конструктор создания карточки
        /// </summary>
        public StudentCard(string firstName, string middleName,
            string lastName, string phoneNumber,
            string address, string email, string recordBook)
        {
            _firstName = firstName;
            _middleName = middleName;
            _lastName = lastName;
            _phoneNumber = phoneNumber;
            _address = address;
            _email = email;
            _recordBook = recordBook;
        }

      
        /// <summary>
        /// Свойство "зачетная книжка"
        /// </summary>
        public string recordBook
        {
            get
            {
                return _recordBook;
            }
            set
            {
                _recordBook = value;
            }
        }
        
        /// <summary>
        /// имя пользователя
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

        /// <summary>
        /// отчество
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
        public string phoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
            }
        }
        public string address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
            }
        }
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }

        /// <summary>
        /// Получение полной информации о студенте
        /// </summary>
        public void PrintFullStudentInfo()
        {
            UI.ClearPreviousConsoleLine();
            Console.WriteLine("\nFull student information:");
            string BOARD = new string('=', 50);
            Console.WriteLine("\n{0}", BOARD);
            Console.Write($"FirstName:\t{_firstName}\n" +
                $"middle name:\t{_middleName}\n" +
                $"last name:\t{_lastName}\n" +
                $"phone number:\t{_phoneNumber}\n" +
                $"address:\t{_address}\n" +
                $"email:\t\t{_email}\n" +
                $"RecordBook:\t");
            UI.PrintStritgOtherColor(_recordBook, ConsoleColor.Green);
            Console.WriteLine("\n{0}\n",BOARD);

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
        public ResultCodes IsContainRB(string recordBook)
        {
            ResultCodes isContainRB = ResultCodes.error;

            if (_recordBook == recordBook)
            {
                isContainRB = ResultCodes.success;
            }

            return isContainRB;
        }


    }

}
