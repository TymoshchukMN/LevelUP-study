// changelog:
//
// 1.Changed the logic of creating groups of students from
//      Group univercityGroups = new Group();
//      to
//      Group [] groupStudents = new Group[COUNT_GROUPS];
//      {
//          name = "",
//          students = new Student[COUNT_STUDENTS]
//      };
//
// 2. Changed the type of group filling from univercityGroups.GROUPNAMR = students;
//      on GROUPNAMR.students = students
//
// 3. The function to receive a group of students (choisedGroup) has been
//      changed, 2 separate parameters passed by reference have been added
//      to the method instead of one.
// 4. Added a do while loop to continue working with the user after CRUD operations
// 5. student group input prompt output prior to CRUD operations
// 6. Added moving operation
// 7. Added opoirtunity for additional marks



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW9
{
    internal class Program
    {
        static void Main(string[] args)
        {

            const ushort COUNT_STUDENTS         = 30;
            const ushort COUNT_GROUPS           = 2;
            const ushort INDEX_FINANCE_GROUP    = 0;
            const ushort INDEX_MATH_GROUP       = 1;


            #region инициализация и заполнение

            //Student[] students = new Student[COUNT_STUDENTS];
            Group[] groupStudents = new Group[COUNT_GROUPS];

            groupStudents[INDEX_FINANCE_GROUP] = new Group
            {

                name = "finance",
                students = new Student[COUNT_STUDENTS]
            };

            groupStudents[INDEX_MATH_GROUP] = new Group
            {
                name = "mathematics",
                students = new Student[COUNT_STUDENTS]
            };
            
            // заполнение группы студентов "финансы"
            CustomFunctions.FillStudentsAuto(groupStudents[INDEX_FINANCE_GROUP].students,
                    COUNT_STUDENTS);

            // заполнение группы студентов "математика"
            CustomFunctions.FillStudentsAuto(groupStudents[INDEX_MATH_GROUP].students,
                    COUNT_STUDENTS);

            #endregion инициализация и заполнение

            #region CRUD

            do
            {
                #region BANNER

                // банер выбора группы
                UI.PrintRequestGroup();

                ushort groupForAdd;
                groupForAdd = ushort.Parse(Console.ReadLine());

                ushort indexGroup = CustomFunctions.GetGroup(groupForAdd);

                Console.Clear();

                UI.PrintRequestAction();
                
                // преобразуем выбор пользователя  в enum
                CRUDoperations userChoise = (CRUDoperations)Console.ReadKey().Key;

                #endregion BANNER

                Console.Clear();

                switch (userChoise)
                {
                    #region создать (CREATE)

                    case CRUDoperations.create:

                        // банер запроса количества студентов
                        UI.PrintRequestCountStudent();

                        // количество студентов к добавлению
                        string usersInput = Console.ReadLine();

                        ushort.TryParse(usersInput, out ushort countAddStudents);


                        // проверка можно ли добавить столько студентов
                        bool isAdditionAvailable;

                        isAdditionAvailable = CustomFunctions.IsFullGroup(
                                ref groupStudents[indexGroup].students,
                                countAddStudents);

                        if (isAdditionAvailable)
                        {
                            // создание карточки студента
                            CustomFunctions.CreateStudent(
                                   ref groupStudents[indexGroup], countAddStudents);

                            // печать введенных студентов
                            UI.PrintAddedStudents(ref groupStudents[indexGroup].students,
                                    countAddStudents);
                        }
                        else
                        {
                            // печать баннера, что добавить нельзя
                            UI.PrintDenyAddBanner(countAddStudents,
                                    ref groupStudents[indexGroup].students,
                                    CustomFunctions.MAX_STUDENTS_COUNT);
                        }

                        break;

                    #endregion создать (CREATE)

                    #region READ

                    case CRUDoperations.read:


                        UI.PrintExistingRB(ref groupStudents[indexGroup]);

                        // Запрос номера зачетки для поиска 
                        UI.PrintRequestRecordBookForSearch();

                        // переменная для хранения номера учетки
                        string recordBook;

                        recordBook = Console.ReadLine();

                        // вызов функции на чтение данных студента по номеру зачетки
                        CustomFunctions.ReadRequest(ref groupStudents[indexGroup].students,
                                recordBook);

                        break;

                    #endregion READ

                    #region UPDATE

                    case CRUDoperations.update:

                        // банер выбора группы
                        UI.PrintRequestGroup();

                        // печать карточек студентов в группе
                        UI.PrintGroupContent(ref groupStudents[indexGroup].students,
                                groupForAdd);

                        // запро номер учеки студента для изменения
                        UI.PrintRequestRecordBook();

                        recordBook = Console.ReadLine();

                        #region проверка номера зачетки


                        bool isRBCorrect;

                        // вызов функ-ии на проверку номера зачетки
                        isRBCorrect = CustomFunctions.IsRecordBookCorrect(recordBook);

                        bool isRBexist;

                        isRBexist = CustomFunctions.IsRecordBookExist(
                                ref groupStudents[indexGroup].students, recordBook);

                        if (!isRBexist)
                        {
                            // печать ошибки, что такого номера нет
                            UI.PrintErrorRBNOTExist();

                            do
                            {
                                UI.PrintRequestRecordBook();
                                recordBook = Console.ReadLine();

                                isRBexist = CustomFunctions.IsRecordBookExist(
                                        ref groupStudents[indexGroup].students,
                                        recordBook);

                            } while (!isRBexist);
                        }

                        // полчение индекса под которым хранится карточка студента
                        int indexStudent = CustomFunctions.GetStudentIndex(
                                ref groupStudents[indexGroup].students, recordBook);

                        #endregion проверка номера зачетки

                        // запрос поля для изменния
                        UI.RequestFieldForChange();

                        // полчение параметра к изменению
                        ushort.TryParse(Console.ReadLine(), out ushort fieldNum);

                        // запрос нового значения для поля
                        UI.RequestNewVol();
                        string newVol = Console.ReadLine();

                        Console.WriteLine("\nКарточка до изменения");
                        UI.PrintUserCard(ref groupStudents[indexGroup].students,
                                indexStudent);

                        // вызов функции на изменение
                        CustomFunctions.UpdateStudentData(ref groupStudents[indexGroup].students,
                                recordBook, fieldNum, newVol, indexStudent);


                        Console.WriteLine("\nКарточка после изменения");
                        UI.PrintUserCard(ref groupStudents[indexGroup].students,
                                indexStudent);

                        break;

                    #endregion UPDATE

                    #region DELETE

                    case CRUDoperations.delete:

                        // печать карточек студентов в группе
                        UI.PrintGroupContent(ref groupStudents[indexGroup].students,
                                groupForAdd);

                        // запроc номер учеки студента для изменения
                        UI.PrintRequestRecordBook();

                        recordBook = Console.ReadLine();

                        #region проверка номера зачетки

                        // вызов функ-ии на проверку номера зачетки
                        isRBCorrect = CustomFunctions.IsRecordBookCorrect(recordBook);

                        isRBexist = CustomFunctions.IsRecordBookExist(
                                ref groupStudents[indexGroup].students,
                                recordBook);

                        if (!isRBexist)
                        {
                            // печать ошибки, что такого номера нет
                            UI.PrintErrorRBNOTExist();

                            do
                            {
                                UI.PrintRequestRecordBook();
                                recordBook = Console.ReadLine();

                                isRBexist = CustomFunctions.IsRecordBookExist(
                                        ref groupStudents[indexGroup].students,
                                        recordBook);

                            } while (!isRBexist);
                        }

                        // полчение индекса под которым хранится карточка студента
                        indexStudent = CustomFunctions.GetStudentIndex(
                                ref groupStudents[indexGroup].students, recordBook);

                        #endregion проверка номера зачетки

                        CustomFunctions.DeleteElement(ref groupStudents[indexGroup].students,
                                indexStudent);

                        // печать карточек студентов в группе
                        UI.PrintGroupContent(ref groupStudents[indexGroup].students,
                                groupForAdd);

                        break;

                    #endregion DELETE

                    #region Move

                    case CRUDoperations.move:

                        #region processing group for moving

                        UI.PrintRequestGroupForMoving(ref groupStudents, indexGroup);

                        string numberGroupForMoving = Console.ReadLine();
                        ushort.TryParse(numberGroupForMoving, out ushort groupForMoving);

                        ushort indexGroupForMoving = CustomFunctions.GetGroup(indexGroup);

                        // check if we can use selected group for moving
                        // groupForMoving - 1 becouse we need to use index
                        // except count 
                        bool isGroupAvailable = CustomFunctions.IsGroupAvailable(
                            ref groupStudents, --groupForMoving, indexGroup);

                        if (!isGroupAvailable)
                        {
                            do
                            {
                                UI.PrintErrorImpossibleMovingToGroup();

                                numberGroupForMoving = Console.ReadLine();
                                ushort.TryParse(numberGroupForMoving, out groupForMoving);
                                // groupForMoving - 1 becouse we need to use index
                                // except count 
                                isGroupAvailable = CustomFunctions.IsGroupAvailable(ref groupStudents,
                                        --groupForMoving, indexGroup);
                            } while (!isGroupAvailable);
                        }

                        #endregion processing group for moving

                        const ushort COUNT_MOVING_STUDENS = 1;

                        // проверка можно ли добавить столько студентов
                        isAdditionAvailable = CustomFunctions.IsFullGroup(
                                ref groupStudents[indexGroup].students,
                                COUNT_MOVING_STUDENS);

                        if (isAdditionAvailable)
                        {
                            // change array size for moving student
                            Array.Resize(ref groupStudents[groupForMoving].students,
                                groupStudents[groupForMoving].students.Length
                                + COUNT_MOVING_STUDENS);

                            #region processing record book 

                            UI.PrintExistingRB(ref groupStudents[indexGroup]);

                            // запро номер учеки студента для изменения
                            UI.PrintRequestRecordBook();

                            recordBook = Console.ReadLine();

                            // вызов функ-ии на проверку номера зачетки
                            isRBCorrect = CustomFunctions.IsRecordBookCorrect(recordBook);

                            isRBexist = CustomFunctions.IsRecordBookExist(
                                    ref groupStudents[indexGroup].students, recordBook);

                            if (!isRBexist)
                            {
                                // печать ошибки, что такого номера нет
                                UI.PrintErrorRBNOTExist();

                                do
                                {
                                    UI.PrintRequestRecordBook();
                                    recordBook = Console.ReadLine();

                                    isRBexist = CustomFunctions.IsRecordBookExist(
                                            ref groupStudents[indexGroup].students,
                                            recordBook);

                                } while (!isRBexist);
                            }

                            // полчение индекса под которым хранится карточка студента
                            indexStudent = CustomFunctions.GetStudentIndex(
                                    ref groupStudents[indexGroup].students, recordBook);

                            Console.Clear();

                            groupStudents[groupForMoving].students[groupStudents[groupForMoving].students.Count() - 1]
                                    = groupStudents[indexGroup].students[indexStudent];

                            // Delete element in array fro wich moving was completed
                            CustomFunctions.DeleteElement(ref groupStudents[indexGroup].students,
                                indexStudent);

                            #endregion processing record book

                        }
                        else
                        {
                            // печать баннера, что добавить нельзя
                            UI.PrintDenyAddBanner(1, ref groupStudents[indexGroup].students,
                                    CustomFunctions.MAX_STUDENTS_COUNT);
                        }

                        UI.PrintMovingResult();
                        break;

                    #endregion Move
                }

                #endregion CRUD
                UI.PrintEndProgram();

            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
