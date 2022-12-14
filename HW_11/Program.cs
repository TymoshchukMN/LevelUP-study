using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.ChangeConsoleHeight();

            ResultCodes operationResult = ResultCodes.none;

            #region СОЗДАНИЕ и ЗАПОЛНЕНИЕ групп

            ushort countGroups = CustomFunctions.GetCountGroups();

            StudentGroups[] groups = new StudentGroups[countGroups];

            // создаем группы и наполняем их студентами
            CustomFunctions.CreateGroups(countGroups, groups, out operationResult);

            if (operationResult == ResultCodes.success)
            {
                UI.PrintSuccessFilling(countGroups);
            }
            else
            {
                UI.PintErrorFilleng();
            }

            #endregion СОЗДАНИЕ и ЗАПОЛНЕНИЕ групп

            ConsoleKey defConsoleKey = ConsoleKey.D0;

            do
            {
                UI.PrintRequestGroups(groups);
                operationResult = ResultCodes.none;

                #region обработка выбора группы

                string selectedGroup = Console.ReadLine();

                ushort choisedGroup;


                CustomFunctions.GetGroupNumber(groups, selectedGroup,
                    out operationResult, out choisedGroup);

                if (operationResult == ResultCodes.groupNotExist)
                {
                    UI.PrintErrorExistingGroup(selectedGroup);
                    continue;
                }

                #endregion обработка выбора группы


                Console.Clear();

                UI.PrintRequestCRUD();

                CRUD operation = (CRUD)Console.ReadKey(true).Key;

                switch (operation)
                {
                    case CRUD.create:
                        Console.Clear();

                        #region CREATE

                        string firstName = string.Empty;
                        string middleName = string.Empty;
                        string lastName = string.Empty;
                        string addressResidential = string.Empty;
                        string addressRegistration = string.Empty;
                        string recordBook = string.Empty;

                        UI.PrintRequestDataForNewStudent();

                        #region firstName

                        UI.PrintRequestFirstName();

                        operationResult = CustomFunctions.ProcessingFirstName(
                                out firstName);

                        if (operationResult != ResultCodes.success)
                        {
                            do
                            {
                                UI.PrintWrongInput(firstName);
                                UI.PrintRequestFirstName();

                                operationResult = CustomFunctions.ProcessingFirstName(
                                out firstName);

                            } while (operationResult != ResultCodes.success);
                        }

                        #endregion firstName

                        #region middleName

                        UI.PrintRequestmiddleName();

                        operationResult = CustomFunctions.ProcessingMiddleName(
                                out middleName);

                        if (operationResult != ResultCodes.success)
                        {
                            do
                            {
                                UI.PrintWrongInput(middleName);
                                UI.PrintRequestmiddleName();

                                operationResult = CustomFunctions.ProcessingMiddleName(
                                out middleName);

                            } while (operationResult != ResultCodes.success);
                        }

                        #endregion middleName

                        #region lastName

                        UI.PrintRequestLastName();

                        operationResult = CustomFunctions.ProcessingLastName(
                                out lastName);

                        if (operationResult != ResultCodes.success)
                        {
                            do
                            {
                                UI.PrintWrongInput(lastName);
                                UI.PrintRequestLastName();

                                operationResult = CustomFunctions.ProcessingLastName(
                                out lastName);

                            } while (operationResult != ResultCodes.success);
                        }


                        #endregion lastName

                        #region Address

                        // адрес проживания
                        UI.PrintRequestAddresssResidential();                        
                        CustomFunctions.ProcessingAddress(out addressResidential);

                        // адрес прописки (регистрации)
                        UI.PrintRequestAddresssRegistration();                        
                        CustomFunctions.ProcessingAddress(out addressRegistration);

                        #endregion Address

                        #region recordBook

                        CustomFunctions.ProcessingRecordBook(out operationResult,
                            groups, choisedGroup, out recordBook);

                        groups[choisedGroup].IsRBExist(recordBook, out operationResult);

                        if (operationResult == ResultCodes.RBexist)
                        {                          
                            do
                            {
                                UI.PrintErrorRBExist(recordBook);
                                CustomFunctions.ProcessingRecordBook(out operationResult,
                                    groups, choisedGroup, out recordBook);

                                groups[choisedGroup].IsRBExist(recordBook, out operationResult);

                            } while (operationResult != ResultCodes.success);
                        }

                        #endregion recordBook

                        StudentCard tmpCard = new StudentCard(firstName, middleName, 
                            lastName, recordBook, addressResidential, addressRegistration) ;
                      
                        groups[choisedGroup].AddStudent(tmpCard, out operationResult);

                        if (operationResult == ResultCodes.success)
                        {
                            UI.ClearPreviousConsoleLine();
                            UI.PrintSuccess();
                            groups[choisedGroup][recordBook].PrintFullStudentInfo();

                        }
                        else
                        {
                            if (operationResult == ResultCodes.exeptionStudentGroup)
                            {
                                UI.PrintErrorAddingStudent();
                            }
                        }

                        #endregion CREATE

                        break;

                    case CRUD.read:

                        Console.Clear();

                        #region READ

                        groups[choisedGroup].ListStudents();

                        ProcessingRB(out operationResult, groups, choisedGroup, out recordBook);

                        groups[choisedGroup][recordBook].PrintFullStudentInfo();

                        #endregion READ

                        break;

                    case CRUD.update:
                        Console.Clear();

                        #region UPDATE

                        groups[choisedGroup].ListStudents();

                        #region processing RB from USER

                        ProcessingRB(out operationResult, groups, choisedGroup, out recordBook);

                        #endregion processing RB from USER

                        UI.PrintRequestFieldForChange();

                        FieldForChange fieldForChange 
                            = (FieldForChange)Console.ReadKey(true).Key;

                        CustomFunctions.IsFieldExist(fieldForChange,
                            out operationResult);

                        if (operationResult != ResultCodes.success)
                        {
                            do
                            {
                                UI.ClearPreviousConsoleLine();
                                UI.PrintErrorChoosingField();

                                fieldForChange 
                                    = (FieldForChange)Console.ReadKey(true).Key;

                                CustomFunctions.IsFieldExist(fieldForChange,
                                    out operationResult);

                            } while (operationResult != ResultCodes.success);
                        }

                        UI.RequestNewVol();

                        // новое значение в поле студента
                        string newVolInStudentField = Console.ReadLine();

                        operationResult = ResultCodes.none;

                        groups[choisedGroup][recordBook].ChangeFild(fieldForChange, 
                            newVolInStudentField, out operationResult);


                        if (operationResult == ResultCodes.success)
                        {
                            UI.PrintSuccess();
                            groups[choisedGroup][recordBook].PrintFullStudentInfo();
                        }
                        else
                        {
                            UI.PrintError();
                        }

                        #endregion UPDATE

                        break;

                    case CRUD.delete:

                        Console.Clear();
                        #region DELETE

                        groups[choisedGroup].ListStudents();

                        #region processing RB from USER

                        ProcessingRB(out operationResult, groups, choisedGroup, out recordBook);

                        #endregion processing RB from USER

                        groups[choisedGroup].DeleteStudent(recordBook,
                           out operationResult);

                        if (operationResult == ResultCodes.success)
                        {
                            UI.ClearPreviousConsoleLine();
                            UI.PrintSucess();
                                                        
                            groups[choisedGroup].ListStudents();
                        }
                        else
                        {
                            UI.PrintError();
                        }

                        #endregion DELETE

                        groups[choisedGroup].ListStudents();

                        break;

                    case CRUD.move:

                        Console.Clear();
                        groups[choisedGroup].ListStudents();

                        #region processing RB from USER

                        ProcessingRB(out operationResult, groups, choisedGroup, out recordBook);

                        UI.PrintAvailabledGroupForMoving((GroupNames)choisedGroup);

                        ConsoleKey targetGroupNum = Console.ReadKey(true).Key;

                        string targetGroupName = Console.ReadLine();

                        ushort targetGroup;

                        CustomFunctions.GetGroupNumber(groups, targetGroupName,
                            out operationResult, out targetGroup);

                        if (operationResult == ResultCodes.groupNotExist)
                        {
                            do
                            {
                                UI.PrintErrorExistingGroup(targetGroupName);
                                UI.PrintAvailabledGroupForMoving((GroupNames)choisedGroup);
                                targetGroupName = Console.ReadLine();

                                CustomFunctions.GetGroupNumber(groups, targetGroupName,
                                    out operationResult, out targetGroup);

                            } while (operationResult != ResultCodes.success);

                        }

                        StudentCard tempCard = new StudentCard(groups[choisedGroup][recordBook]);

                        groups[choisedGroup].DeleteStudent(recordBook,
                            out operationResult);

                        groups[targetGroup].AddStudent(tempCard,
                            out operationResult);

                        if (operationResult == ResultCodes.success)
                        {
                            UI.PrintSuccess();
                            groups[targetGroup].ListStudents();
                        }

                        #endregion processing RB from USER

                        break;
                }


                UI.PrintWhatToDoNext();

                defConsoleKey = Console.ReadKey(true).Key;

                Console.Clear();

            } while (defConsoleKey != ConsoleKey.Escape);


            Console.ReadKey();

        }

        private static void ProcessingRB(out ResultCodes operationResult, 
                StudentGroups[] groups, ushort choisedGroup, 
                out string recordBook)
        {
            UI.PrintRequestRecordBooh();

            recordBook = Console.ReadLine();
            operationResult = ResultCodes.none;

            groups[choisedGroup].IsRBExist(recordBook, out operationResult);

            if (operationResult != ResultCodes.RBexist)
            {
                do
                {
                    UI.PrintErrorRBNotExist(recordBook);

                    recordBook = Console.ReadLine();
                    operationResult = ResultCodes.none;

                    groups[choisedGroup].IsRBExist(recordBook, out operationResult);

                } while (operationResult != ResultCodes.RBexist);
            }
        }
    }
}
