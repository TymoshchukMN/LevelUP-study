using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{

    internal class CustomFunctions
    {
        // МАКСИМАЛЬНО допустимое количество студентов в группе  
        public const ushort MAX_STUDENTS_COUNT = 32;
        public const ushort MARKS_LIST_SIZE = 30;

        /// <summary>
        /// Генерация первых 2-х букв в номере зачетки
        /// </summary>
        /// <returns>
        /// 2 буквы, например, AD, AS, KD
        /// </returns>
        public static string GetRandomLetterts()
        {
            Random random = new Random();
            string letters;
            const ushort firstRandChar = 65;
            const ushort lastRandChar = 90;

            // берем рандом в диапазоне 65 - 90
            // в них содержаться коды символов букв от A до Z

            letters = string.Concat((char)random.Next(firstRandChar, lastRandChar), 
                    (char)random.Next(firstRandChar, lastRandChar));

            return letters;
        }

        /// <summary>
        /// Генерим рандомнуй дату рождения
        /// </summary>
        /// <returns>
        /// дата рождения
        /// </returns>
        public static DateTime GetrandomBirthday()
        {
            Random random = new Random();

            // берем из расчета, что поступить могут люди не старше 50 лет
            DateTime startDate = new DateTime(1970, 1, 1);

            // берем из расчета, что поступить могут люди не младше 18 лет
            DateTime lastDate = new DateTime(2004, 12, 31);

            int range = (lastDate - startDate).Days;

            return startDate.AddDays(random.Next(0, range)).Date;
        }

        /// <summary>
        /// Генерируем номер телефона
        /// </summary>
        /// <returns> номер телефона </returns>
        public static string GetRandomPhoneNumber()
        {
            string PhoneNumber = "+3809";
            Random random = new Random();

            for (int i = 0; i < 8; i++)
            {
                PhoneNumber += random.Next(0, 9);
            }
            return PhoneNumber;
        }

        /// <summary>
        /// заполнение карточки студента
        /// </summary>
        /// <param name="students">
        /// структцра Students
        /// </param>
        /// <param name="countStudnts">
        /// колчество студентов к заполнению
        /// </param>
        public static void FillStudentsAuto(Student [] students, ushort countStudnts)
        {
            Random random = new Random();

            // переменная для временного хранения номера зачетки
            string recordBook;

            // заполнение структуры
            for (int i = 0; i < countStudnts; i++)
            {
                students[i].firstName = Faker.Name.First();
                students[i].middleName = Faker.Name.Middle();
                students[i].lastName = Faker.Name.Last();
                students[i].address = Faker.Address.StreetAddress();
                students[i].email = Faker.Internet.Email();
                students[i].birthday = GetrandomBirthday();
                students[i].phonenumber = GetRandomPhoneNumber();

                // получаем номер зачетки
                recordBook = string.Concat(CustomFunctions.GetRandomLetterts(),
                    random.Next(100000, 999999));

                students[i].recordBook = recordBook;
                students[i].marks = new int[MARKS_LIST_SIZE];

                FillMarksArray(students[i].marks);
            }

        }

        /// <summary>
        /// Filling studens marks
        /// </summary>
        /// <param name="marks">
        /// array for filling in studens card
        /// </param>
        public static void FillMarksArray(int[] marks)
        {
            Random random = new Random();

            for (int i = 0; i < marks.Length; i++)
            {
                marks[i] = random.Next(3, 5);
            }
        }

        /// <summary>
        /// Проверяем можно ли добавить такое количество студентов
        /// </summary>
        /// <param name="students">
        /// группа студентов для подсчета
        /// </param>
        /// <param name="countAddStudents">
        /// количество студентов к добавлению 
        /// </param>
        public static bool IsFullGroup(ref Student[] students,
                int countAddStudents) {

            // если количество в группе + количество студентов, которых хотим
            // добавить, не превышает максимальное количество студентов, то возвращаем true
            if (students.Count() + countAddStudents <= MAX_STUDENTS_COUNT)
            {
                return true;
            }           

            return false;
        }
        
        /// <summary>
        /// добавление студента в группу
        /// </summary>
        /// <param name="group">
        /// группа для добавления
        /// </param>
        /// <param name="countAddStudents">
        /// количество сдудетнов для добавления
        /// </param>
        public static void CreateStudent(ref Group studentsGroup, 
                int countAddStudents)
        {

            int tmpIndex = studentsGroup.students.Count();
            // изменение размера группы студентов на countAddStudents элементов
            Array.Resize(ref studentsGroup.students, 
                    studentsGroup.students.Length + countAddStudents);

            for (int i = tmpIndex; i < studentsGroup.students.Count(); i++)
            {
                // идекс элемента для заполнения данныз о новом студенте


                Console.Clear();

                // печать банера на запрос ввода номера учетки
                UI.PrintRequestRecordBook();

                // переменная для хранения номера учетки
                string recordBook;

                recordBook = Console.ReadLine();                

                
                bool isRBCorrect;

                // вызов функ-ии на проверку номера зачетки
                isRBCorrect = IsRecordBookCorrect(recordBook);

                if (!isRBCorrect)
                {
                    do
                    {
                        // печать ошибки
                        UI.PrintErrorRecordBook();

                        recordBook = Console.ReadLine();

                        // повторная проверка введенного номера
                        isRBCorrect = IsRecordBookCorrect(recordBook);

                        // проверяем до тех пор, пока нормер не правильный
                    } while (!isRBCorrect);
                }

                bool isRBExist;

                // вызов функции на проверку наличия такого же номера
                isRBExist = IsRecordBookExist(ref studentsGroup.students, recordBook,
                        studentsGroup.students.Count() - countAddStudents);

                if (isRBExist)
                {
                    do
                    {
                        UI.PrintErrorRBExist();

                        recordBook = Console.ReadLine();
                        isRBExist = IsRecordBookExist(ref studentsGroup.students, recordBook);

                    } while (!isRBExist);
                }
                

                #region заполнение карточки студента

                // присвоение номера учетки новому студенту
                studentsGroup.students[i].recordBook = recordBook;

                // обработка имени студента
                Console.WriteLine("Укажите firstName\t");
                string firstName = Console.ReadLine();
                studentsGroup.students[i].firstName = firstName;

                // обработка фамилию студента
                Console.WriteLine("Укажите lastName\t");
                string lastName = Console.ReadLine();
                studentsGroup.students[i].lastName = lastName;

                // обработка отчество студента
                Console.WriteLine("Укажите middleName\t");
                string middleName = Console.ReadLine();
                studentsGroup.students[i].middleName = middleName;

                // обработка phonenumber студента
                Console.WriteLine("Укажите phonenumber\t");
                string phonenumber = Console.ReadLine();
                studentsGroup.students[i].phonenumber = phonenumber;

                // обработка birthday студента
                Console.WriteLine("Укажите birthday\t");
                string birthday = Console.ReadLine();
                DateTime.TryParse(birthday, out DateTime date);
                studentsGroup.students[i].birthday = date;

                // обработка email студента
                Console.WriteLine("Укажите email\t");
                string email = Console.ReadLine();
                studentsGroup.students[i].email = email;

                // обработка address студента
                Console.WriteLine("Укажите address\t");
                string address = Console.ReadLine();
                studentsGroup.students[i].address = address;

                // addition marks
                const ushort STRARTED_MARKS_ARRAY_SIZE = 0;

                studentsGroup.students[i].marks = new int[STRARTED_MARKS_ARRAY_SIZE];
                string userInput;

                do
                {
                    ClearCurrentConsoleLine();
                    Console.WriteLine("Input mark:\t");

                    userInput = Console.ReadLine();
                    int.TryParse(userInput, out int res);

                    AddMark(studentsGroup.students, i,  res);
                    //studentsGroup.students[i].marks[i] = res;
                    Console.WriteLine("to continue press any key, or press Esc for finish");
                } while (Console.ReadKey().Key != ConsoleKey.Escape);
                ClearCurrentConsoleLine();


                #endregion заполнение карточки студента
            }

        }
        /// <summary>
        /// Addition marks and resize array
        /// </summary>
        /// <param name="studentCard">
        /// array for filling
        /// </param>
        /// <param name="mark">
        /// mark for addind
        /// </param>
        static private void AddMark(Student [] studentCard, int index, int mark)
        {
            // increase size on one element
            Array.Resize(ref studentCard[index].marks, studentCard[index].marks.Count() + 1);

            studentCard[index].marks[studentCard[index].marks.Length - 1] = mark;


            //marksArray[marksArray.Length - 1] = mark;
        }
        static private void  ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }

        /// <summary>
        /// Проверка корректности номера зачетки
        /// </summary>
        /// <param name="recordBook">
        /// номер зачетки для проверки
        /// </param>
        /// <returns>
        /// true - корректный номер
        /// false - не верный
        /// </returns>
        public static bool IsRecordBookCorrect(string recordBook)
        {
            
            for (int i = 0; i < recordBook.Length; i++)
            {
                // 2 - это количество букв в начале зачетки
                if (i <2)
                {
                    // в диапазоне от 65 до 90 содержаться
                    // коды символов букв от A до Z
                    if (!((int)(char)recordBook[i] >= 65 && (int)(char)recordBook[i] <= 90))
                    {
                        return false;
                    }
                }
                else
                {
                    // проверка является ли символ числом
                    if (!char.IsDigit(recordBook[i]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// проверка наличия указанной учетки
        /// </summary>
        /// <param name="students">
        /// группа студентов
        /// </param>
        /// <param name="recordBook">
        /// номер зачетки для проверки
        /// </param>
        /// <returns></returns>
        public static bool IsRecordBookExist(ref Student[] students, string recordBook)
        {
            // количество симврорв в номере зачетки
            const ushort recordBookLength = 8;

            if (recordBook.Length != recordBookLength)
            {
                return false;
            }

            ushort matchCount = 0;

            // сравниваем учетки каждого студента с введенными
            for (int i = 0; i < students.Count(); i++)
            {
                matchCount = 0;
                for (int j = 0; j < recordBookLength; j++)
                {
                    // сравниваем посимвольно введеный номер УЗ с имеющимися
                    if ((char)students[i].recordBook[j] == (char)recordBook[j])
                    {
                        ++matchCount;
                    }
                }

                if (matchCount == recordBookLength)
                {
                    return true;
                }
            }
           
            return false;
        }

        /// <summary>
        /// проверка наличия указанной учетки
        /// </summary>
        /// <param name="students">
        /// группа студентов
        /// </param>
        /// <param name="recordBook">
        /// номер зачетки для проверки
        /// </param>
        /// <returns></returns>
        public static bool IsRecordBookExist(ref Student[] students, string recordBook,
                int countStudents)
        {
            // количество симврорв в номере зачетки
            const ushort recordBookLength = 8;

            if (recordBook.Length != recordBookLength)
            {
                return false;
            }

            ushort matchCount = 0;

            // сравниваем учетки каждого студента с введенными
            for (int i = 0; i < countStudents; i++)
            {
                matchCount = 0;
                for (int j = 0; j < recordBookLength; j++)
                {
                    // сравниваем посимвольно введеный номер УЗ с имеющимися
                    if ((char)students[i].recordBook[j] == (char)recordBook[j])
                    {
                        ++matchCount;
                    }
                }

                if (matchCount == recordBookLength)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// возвращаем группу по енаму
        /// </summary>
        /// <param name="group1">
        /// 1-я группа студентов (финансисты)
        /// </param>
        /// <param name="group2"><
        /// 2-я группа студентов (математики)
        /// /param>
        /// <param name="userChoise">
        /// пользовательский выбор, полученный с енама
        /// </param>
        /// <returns>
        /// группа для добавления
        /// </returns>
        public static ushort GetGroup(ushort userChoice)
        {
            // по умолчанию группа финансистов
            ushort indexGroup = 0;

            switch (userChoice)
            {
                
                case 1:
                    // индекс группы финансистов
                    indexGroup = 0;
                    break;
                case 2:
                    // индекс группы математиков
                    indexGroup = 1;
                    break;
            }

            return indexGroup;
        }

        /// <summary>
        /// чтение данных студента по номеру зачетки
        /// </summary>
        /// <param name="students">
        /// группа студентов
        /// </param>
        /// <param name="recordBook">
        /// номер зачетки
        /// </param>
        public static void ReadRequest(ref Student[] students, string recordBook)
        {
            // обрабатываем все карточки студенто в группе
            for (int student = 0; student < students.Count(); ++student)
            {
                // проверям на совпадение того, что запросили с тем, что есть
                if (students[student].recordBook.Contains(recordBook))
                {

                    UI.PrintUserCard(ref students,student);
                    
                }
            }
        }

        /// <summary>
        /// обновление поля в карточке пользователя
        /// </summary>
        /// <param name="students">
        /// группа студента
        /// </param>
        /// <param name="recordBook">
        /// номер зачетки
        /// </param>
        /// <param name="fieldNum">
        /// номер поля к изменению
        /// </param>
        /// <param name="newVol">
        /// новое значение
        /// </param>
        public static void UpdateStudentData(ref Student[] students, 
                string recordBook, ushort fieldNum, string newVol, int indexStudent)
        {
            switch ((EnumFields)fieldNum)
            {
                case EnumFields.firstName:
                    students[indexStudent].firstName = newVol;
                    break;
                case EnumFields.middleName:
                    students[indexStudent].middleName = newVol;
                    break;
                case EnumFields.lastName:
                    students[indexStudent].lastName = newVol;
                    break;
                case EnumFields.birthday:
                    DateTime.TryParse(newVol, out DateTime date);
                    students[indexStudent].birthday = date;
                    break;
                case EnumFields.address:
                    students[indexStudent].address = newVol;
                    break;
                case EnumFields.phonenumber:
                    students[indexStudent].phonenumber = newVol;
                    break;
                case EnumFields.email:
                    students[indexStudent].email = newVol;
                    break;
                case EnumFields.recordBook:
                    students[indexStudent].recordBook = newVol;
                    break;

            }
        }

        /// <summary>
        /// получение инжекса под которым хранится запись студента
        /// </summary>
        /// <param name="students">
        /// группа студентов
        /// </param>
        /// <param name="recordBook">
        /// номер учетки
        /// </param>
        /// <returns>
        /// номер индекса
        /// </returns>
        public static int GetStudentIndex(ref Student[] students, string recordBook)
        {
            // количество символов в номере зачетки
            const ushort recordBookLength = 8;

            ushort matchCount = 0;

            int index = -1;

            // сравниваем учетки каждого студента с введенными
            for (int i = 0; i < students.Count(); i++)
            {
                matchCount = 0;
                for (int j = 0; j < recordBookLength; j++)
                {
                    // сравниваем посимвольно введеный номер УЗ с имеющимися
                    if ((char)students[i].recordBook[j] == (char)recordBook[j])
                    {
                        ++matchCount;
                    }
                }

                if (matchCount == recordBookLength)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }

        /// <summary>
        /// Проверка номера зачетки c с повторным запросом, если потребуется
        /// </summary>
        /// <param name="students"></param>
        /// <param name="recordBook"></param>
        /// <param name="isRBCorrect"></param>
        public static void CheckAndRequestRB(ref Student[] students, 
                ref string recordBook, ref bool isRBCorrect)
        {
            if (!isRBCorrect)
            {
                do
                {
                    // печать ошибки
                    UI.PrintErrorRecordBook();

                    recordBook = Console.ReadLine();

                    // повторная проверка введенного номера
                    isRBCorrect = IsRecordBookCorrect(recordBook);

                    // проверяем до тех пор, пока нормер не правильный
                } while (!isRBCorrect);
            }

            bool isRBExist;

            // вызов функции на проверку наличия такого же номера
            isRBExist = IsRecordBookExist(ref students, recordBook);

            if (isRBExist)
            {
                do
                {
                    UI.PrintErrorRBExist();

                    recordBook = Console.ReadLine();
                    isRBExist = IsRecordBookExist(ref students, recordBook);

                } while (!isRBExist);
            }
        }

        /// <summary>
        /// удаление карточки студента
        /// </summary>
        /// <param name="students">
        /// Группа студентов
        /// </param>
        /// <param name="indexStudent">
        /// Индекс под которым хранится карточка студента
        /// </param>
        public static void DeleteElement(ref Student[] students, int indexStudent)
        {
            // временная структкра для сохранение перемещаемого элемента
            //Student tempStudentCard = new Student();

            Student tempStudentCard = students[students.Length - 1];
            students[students.Length - 1] = students[indexStudent];
            students[indexStudent] = tempStudentCard;

            Array.Resize(ref students, students.Length - 1);

        }

        /// <summary>
        /// Проверка выбора
        /// </summary>
        /// <param name="groups">
        /// Все группы студентов
        /// </param>
        /// <param name="indexGroupForMoving">
        /// Выбранный индекс для перемещения
        /// </param>
        /// <param name="indexGroup">
        /// индекс группы из которой выполняется перемещение
        /// </param>
        /// <returns></returns>
        public static bool IsGroupAvailable(ref Group[] groups, ushort indexGroupForMoving,
                ushort indexGroup)
        {
            if (indexGroupForMoving > groups.Count() - 1 || indexGroupForMoving == indexGroup)
            {
                return false;
            }

            return true;
        }
    }

}
