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
        public static void FillStudentsAuto(StudentCard[] students, 
            ushort countStudnts)
        {
            string RB;
            for (ushort i = 0; i < countStudnts; i++)
            {
                RB = GetRBRandom();

                StudentCard tmpCard = new StudentCard(
                    Faker.Name.First(),
                    Faker.Name.Middle(),
                    Faker.Name.Last(),
                    Faker.Phone.Number(),
                    Faker.Address.StreetName(),
                    Faker.Internet.Email(),
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

            string letters = string.Concat((char)random.Next(FIRST_RAND_CHAR
                    , LAST_RAND_CHAR)
                    , (char)random.Next(FIRST_RAND_CHAR, LAST_RAND_CHAR));

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

            int numbers = random.Next(START_RAND_RB_RANGE,
                    LAST_RAND_RB_RANGE);

            recordBook = string.Concat(letters, numbers);

            return recordBook;
        }

        /// <summary>
        /// Get group index from users input
        /// </summary>
        /// <param name="groupNum">
        /// choised numver
        /// </param>
        /// <returns>
        /// index or error 
        /// </returns>
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

        /// <summary>
        /// Check if RB correct
        /// </summary>
        /// <param name="recordBook">
        /// RB for cheking
        /// </param>
        /// <returns>
        /// 1 - успех 
        /// 1603 - УЗ не корректна
        /// </returns>
        public static ResultCodes IsRecordBookCorrect(string recordBook,
                out ResultCodes resultCode)
        {

            const ushort START_CHAR_NUM = 65;
            const ushort STOP_CHAR_NUM = 90;
            const ushort RB_LENTH = 8;

            resultCode = ResultCodes.success;

            if (recordBook.Length != RB_LENTH)
            {
                resultCode = ResultCodes.error;
            }
            else
            {
                for (int i = 0; i < recordBook.Length; i++)
                {
                    // 2 - это количество букв в начале зачетки
                    if (i < 2)
                    {
                        // в диапазоне от 65 до 90 содержаться
                        // коды символов букв от A до Z
                        if (!((int)(char)recordBook[i] >= START_CHAR_NUM
                            && (int)(char)recordBook[i] <= STOP_CHAR_NUM))
                        {
                            resultCode = ResultCodes.error;
                            break;
                        }
                    }
                    else
                    {
                        // проверка является ли символ числом
                        if (!char.IsDigit(recordBook[i]))
                        {
                            resultCode = ResultCodes.error;
                            break;
                        }
                    }
                }
            }

            return resultCode;
        }


        /// <summary>
        /// запрос имени пользователя в виде строки
        /// </summary>
        /// <param name="firtsName">
        /// имя студента
        /// </param>
        /// <returns>
        /// код выполнения
        /// 1 - все ок
        /// 1603 - ошибка, имя состоит не только из букв
        /// </returns>
        public static ResultCodes ProcessingFirstName(out string firtsName)
        {
            ResultCodes resultCode = ResultCodes.success;

            firtsName = Console.ReadLine();

            for (int i = 0; i < firtsName.Length; i++)
            {
                if (!char.IsLetter((char)firtsName[i]))
                {
                    resultCode = ResultCodes.error;
                    break;
                }
            }

            return resultCode;
        }

        /// <summary>
        /// запрос отчетства пользователя в виде строки
        /// </summary>
        /// <param name="middleName">
        /// имя студента
        /// </param>
        /// <returns>
        /// код выполнения
        /// 1 - все ок
        /// 1603 - ошибка, имя состоит не только из букв
        /// </returns>
        public static ResultCodes ProcessingMiddleName(out string middleName)
        {
            ResultCodes resultCode = ResultCodes.success;

            middleName = Console.ReadLine();

            for (int i = 0; i < middleName.Length; i++)
            {
                if (!char.IsLetter((char)middleName[i]))
                {
                    resultCode = ResultCodes.error;
                    break;
                }
            }

            return resultCode;
        }


        /// <summary>
        /// запрос отчетства пользователя в виде строки
        /// </summary>
        /// <param name="lastName">
        /// имя студента
        /// </param>
        /// <returns>
        /// код выполнения
        /// 1 - все ок
        /// 1603 - ошибка, фамилия состоит не только из букв
        /// </returns>
        public static ResultCodes ProcessingLastName(out string lastName)
        {
            ResultCodes resultCode = ResultCodes.success;

            lastName = Console.ReadLine();

            for (int i = 0; i < lastName.Length; i++)
            {
                if (!char.IsLetter((char)lastName[i]))
                {
                    resultCode = ResultCodes.error;
                    break;
                }
            }

            return resultCode;
        }

        /// <summary>
        /// запрос номера телефона
        /// </summary>
        /// <param name="phoneNumber">
        /// имя студента
        /// </param>
        /// <returns>
        /// код выполнения
        /// 1 - все ок
        /// 1603 - ошибка, фамилия состоит не только из букв
        /// </returns>
        public static ResultCodes ProcessingPhoneNumber(out string phoneNumber)
        {
            ResultCodes resultCode = ResultCodes.success;

            phoneNumber = Console.ReadLine();

            for (int i = 0; i < phoneNumber.Length; i++)
            {
                if (!char.IsDigit((char)phoneNumber[i]))
                {
                    resultCode = ResultCodes.error;
                    break;
                }
            }

            return resultCode;
        }

        /// <summary>
        /// обработка адреса студента
        /// </summary>
        public static void ProcessingAddress(out string address)
        {
            address = Console.ReadLine();
        }


        /// <summary>
        /// обработка адреса почты
        /// </summary>
        public static void ProcessingEmail(out string email)
        {
            email = Console.ReadLine();
        }

        /// <summary>
        /// Обработка не существующей учетки
        /// </summary>
        /// <param name="groups">
        /// Выбранная группа студентов
        /// </param>
        /// <param name="choisedGroup">
        /// индекс выбранной группы
        /// </param>
        /// <param name="recordBook">
        /// номер учетки
        /// </param>
        /// <param name="isCorrect">
        /// код корректности учетки
        /// </param>
        /// <param name="isRBexist">
        /// код существующей учетки
        /// </param>
        /// <returns>
        /// номер учетки
        /// </returns>
        public static string ProcessingNonexistentRB(ref StudentsGroup[] groups,
                ushort choisedGroup, string recordBook, out ResultCodes isCorrect,
                out ResultCodes isRBexist)
        {
            do
            {
                UI.PrintErrorRBnotExist(recordBook);

                recordBook = Console.ReadLine();

                do
                {
                    UI.PrintErrorRBnotExist(recordBook);
                    recordBook = Console.ReadLine();
                    CustomFunctions.IsRecordBookCorrect(recordBook,
                        out isCorrect);

                } while (isCorrect != ResultCodes.success);

                isRBexist = groups[choisedGroup][recordBook].IsContainRB(recordBook);
            } while (isRBexist != ResultCodes.success);
            return recordBook;
        }

        /// <summary>
        /// обработка не верно введенного номера УЗ
        /// </summary>
        /// <param name="recordBook">
        /// номер учетки
        /// </param>
        /// <param name="isCorrect">
        /// код корректности УЗ
        /// </param>
        public static void ProcessingWrongRB(ref string recordBook, ref ResultCodes isCorrect)
        {
            if (isCorrect != ResultCodes.success)
            {
                do
                {
                    UI.PrintErrorRBWrong(recordBook);
                    recordBook = Console.ReadLine();
                    CustomFunctions.IsRecordBookCorrect(recordBook,
                        out isCorrect);

                } while (isCorrect != ResultCodes.success);

            }
        }


        public static ResultCodes IsFieldExist(FieldForChange field,
                out ResultCodes operationResult)
        {
            operationResult = ResultCodes.fieldNotExist;

            //FieldForChange userInput = (FieldForChange)Console.ReadKey().Key;

            if (Enum.IsDefined(typeof(FieldForChange), field))
            {
                operationResult = ResultCodes.success;
            }
           
            return operationResult;
        }

        /// <summary>
        /// Изменение поля студента
        /// </summary>
        /// <param name="student">
        /// студент для изменения
        /// </param>
        /// <param name="field">
        /// поле для изменения
        /// </param>
        /// <param name="newVol">
        /// новое значение
        /// </param>
        /// <returns>
        /// код резульатат
        /// </returns>
        public static ResultCodes ChangeField(ref StudentsGroup [] group, 
                ushort choisedGroup, string recordBook,
                FieldForChange field, string newVol, out ResultCodes operationResult)
        {
            operationResult = ResultCodes.none;

            StudentCard temCard = group[choisedGroup][recordBook];

            switch (field)
            {
                case FieldForChange.firstName:
                    
                    temCard.firstName = newVol;
                    group[choisedGroup][recordBook] = temCard;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.middleName:

                    temCard.middleName = newVol;
                    group[choisedGroup][recordBook] = temCard;
                    operationResult = ResultCodes.success;
                    break;

                case FieldForChange.lastName:

                    temCard.lastName = newVol;
                    group[choisedGroup][recordBook] = temCard;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.phoneNumber:

                    temCard.phoneNumber = newVol;
                    group[choisedGroup][recordBook] = temCard;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.address:

                    temCard.address = newVol;
                    group[choisedGroup][recordBook] = temCard;
                    operationResult = ResultCodes.success;

                    break;
                case FieldForChange.email:

                    temCard.email = newVol;
                    group[choisedGroup][recordBook] = temCard;
                    operationResult = ResultCodes.success;

                    break;
                default:

                    operationResult = ResultCodes.error;

                    break;
            }

            return operationResult;
        }


        public static ResultCodes DeleteStudent(ref StudentsGroup[] group,
               ushort choisedGroup, string recordBook,
               out ResultCodes operationResult)
        {
            operationResult = ResultCodes.none;

            ushort lastIndex = group[choisedGroup].GetCountStudents();
            
            // получаем индекс карточки студениа к удалению
            group[choisedGroup].GetStudentIndex(recordBook);

            // сохраняем последнюю в массиве карточку
            StudentCard temCard = group[choisedGroup][lastIndex];

            group[choisedGroup][recordBook] = temCard;

            //var a = group[choisedGroup];

            //Array.Resize(ref group[choisedGroup], group[choisedGroup].GetCountStudents() - 1);

            return operationResult;
        }
    }

}
