using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class CustomFunctions
    {
        /// <summary>
        /// Получаем количество групп на основе енама GroupNames
        /// </summary>
        /// <returns>
        /// количество групп студентов
        /// </returns>
        public static ushort GetCountGroups()
        {
            ushort countGroups = (ushort)Enum.GetNames(typeof(GroupNames)).Count();

            return countGroups;
        }

        /// <summary>
        /// Автозаполнение группы студентов 
        /// </summary>
        /// <param name="group">
        /// Группа к заполнению
        /// </param>
        /// <param name="card">
        /// карточка студента для добавлени я вгруппу
        /// </param>
        /// <param name="resultCode"></param>
        /// <returns>
        /// код операции
        /// </returns>
        public static ResultCodes AutoFiillGroups(StudentGroups group, 
                StudentCard card, out ResultCodes resultCode)
        {
            resultCode = ResultCodes.none;

            

            return resultCode;
        }

        /// <summary>
        /// Создание групп студентов с автозаполнением
        /// </summary>
        /// <param name="countGroups">
        /// количество групп
        /// </param>
        /// <param name="groups">
        /// массив групп к заполнению
        /// </param>
        public static ResultCodes CreateGroups(ushort countGroups, 
            StudentGroups[] groups, out ResultCodes resultCode)
        {
            resultCode = ResultCodes.none;

            // инициализация, без нее получаем ошибку
            //System.NullReferenceException: 'Object reference not set to an instance of an object.'

            for (ushort i = 0; i < countGroups; i++)
            {
                string groupName = ((GroupNames)i).ToString();

                groups[i] = new StudentGroups(groupName);
            }

            // автозаполнение групп студентами
            for (ushort i = 0; i < countGroups; i++)
            {
                groups[i].AutoFill();

            }

            resultCode = ResultCodes.success;

            return resultCode;
        }


        /// <summary>
        /// Get group index from users input
        /// </summary>
        /// <param name="groupNum">
        /// choised numver
        /// </param>
        /// <returns>
        /// код операции
        /// </returns>
        public static ResultCodes GetGroupIndex(GroupNames group, ConsoleKey groupNum,
            out ushort choisedGroup, out ResultCodes operationResult)
        {
            choisedGroup = 0;
            operationResult = ResultCodes.none;

            switch (group)
            {
                case GroupNames.Finance:

                    choisedGroup = (ushort)GroupNames.Finance;
                    operationResult = ResultCodes.success;

                    break;
                case GroupNames.Mathematics:

                    choisedGroup = (ushort)GroupNames.Mathematics;
                    operationResult = ResultCodes.success;
                    break;
                case GroupNames.Phylosophy:

                    choisedGroup = (ushort)GroupNames.Phylosophy;                    
                    operationResult = ResultCodes.success;
                    break;
                default:
                    break;
            }

          /*  switch (groupNum)
            {
                case ConsoleKey.NumPad1:

                    choisedGroup = 0;
                    operationResult = ResultCodes.success;

                    break;
                case ConsoleKey.NumPad2:

                    choisedGroup = 1;
                    operationResult = ResultCodes.success;

                    break;
                default:
                    operationResult = ResultCodes.groupNotExist;
                    break;
            }*/

            return operationResult;
        }


        public static void GetGroupNumber(StudentGroups[] groups, string selectedGroup,
            out ResultCodes operationResult, out ushort choisedGroup)
        {
            operationResult = ResultCodes.groupNotExist;
            choisedGroup = 0;

            for (ushort i = 0; i < groups.Count(); i++)
            {
                if (groups[i].groupName == selectedGroup)
                {
                    choisedGroup = i;
                    operationResult = ResultCodes.success;
                    break;
                }
            }
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
                    if (i <= 1)
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
        /// Обработка Учеткной книжки
        /// </summary>
        /// <param name="operationResult">
        /// результат операции
        /// </param>
        /// <param name="groups">
        /// массив групп
        /// </param>
        /// <param name="choisedGroup">
        /// выбранная группа для КРУД
        /// </param>
        /// <param name="recordBook">
        /// номер учетной книжки для проверки/обработки
        /// </param>
        public static void ProcessingRecordBook(out ResultCodes operationResult,
                StudentGroups[] groups, ushort choisedGroup,
                out string recordBook)
        {
            UI.PrintRequestRecordBooh();

            recordBook = Console.ReadLine();

            ResultCodes isCorrect = ResultCodes.none;

            IsRecordBookCorrect(recordBook,
                    out isCorrect);

            if (isCorrect != ResultCodes.success)
            {
                do
                {
                    UI.PrintErrorRBWrong(recordBook);
                    UI.PrintRequestRecordBooh();
                    recordBook = Console.ReadLine();
                    IsRecordBookCorrect(recordBook,
                        out isCorrect);

                } while (isCorrect != ResultCodes.success);

            }

            operationResult = ResultCodes.none;

            //groups[choisedGroup].IsRBExist(recordBook, out operationResult);
        }

        /// <summary>
        /// обработка адреса студента
        /// </summary>
        public static void ProcessingAddress(out string address)
        {
            address = Console.ReadLine();
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
    }
}
