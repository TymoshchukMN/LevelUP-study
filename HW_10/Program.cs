using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const ushort COUNT_GROUPS = 2;
            const ushort INDEX_FINANCE_GROUP = 0;
            const ushort INDEX_MATH_GROUP = 1;
            const ushort ERROR_RUNTIME = 1603;

            StudentsGroup[] groups = new StudentsGroup[COUNT_GROUPS];

            bool isManualFill = false;

            groups[INDEX_FINANCE_GROUP] = new StudentsGroup(GroupNames.Finance,
                    isManualFill);

            groups[INDEX_MATH_GROUP] = new StudentsGroup(GroupNames.Mathematics,
                    isManualFill);

            ConsoleKey defConsoleKey = ConsoleKey.D0;

            UI.ChangeConsoleHeight();

            do // while (defConsoleKey != ConsoleKey.Escape);
            {
                #region работа с пользователем

                UI.PrintRequestGroup();

                ConsoleKey groupNum = Console.ReadKey().Key;

                ushort choisedGroup = CustomFunctions.GetGroupIndex(groupNum);

                Console.Clear();

                if (choisedGroup == ERROR_RUNTIME)
                {
                    do
                    {
                        UI.PrintErrorSelectedGroup();

                        choisedGroup = CustomFunctions.GetGroupIndex(
                                Console.ReadKey().Key);

                    } while (choisedGroup == ERROR_RUNTIME);
                }

                Console.Clear();

                UI.PrintRequestCRUD();

                CRUD operation = (CRUD)Console.ReadKey().Key;

                #endregion работа с пользователем

                #region CRUD

                switch (operation)
                {
                    case CRUD.create:

                        #region CREATE

                        string firstName = string.Empty;
                        string middleName = string.Empty;
                        string lastName = string.Empty;
                        string phoneNumber = string.Empty;
                        string address = string.Empty;
                        string email = string.Empty;
                        string recordBook = string.Empty;

                        UI.PrintRequestDataForNewStudent();

                        ResultCodes operationResult = ResultCodes.none;

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

                        #region PhoneNumber

                        UI.PrintRequestPhoneNumber();

                        operationResult = CustomFunctions.ProcessingPhoneNumber(
                                out phoneNumber);

                        if (operationResult != ResultCodes.success)
                        {
                            do
                            {
                                UI.PrintWrongInput(phoneNumber);
                                UI.PrintRequestPhoneNumber();

                                operationResult = CustomFunctions.ProcessingPhoneNumber(
                                out phoneNumber);

                            } while (operationResult != ResultCodes.success);
                        }

                        #endregion PhoneNumber

                        #region Address

                        UI.PrintRequestAddress();

                        CustomFunctions.ProcessingAddress(out address);

                        #endregion Address

                        #region email

                        UI.PrintRequestEmail();
                        CustomFunctions.ProcessingEmail(out email);

                        #endregion

                        #region recordBook

                        UI.PrintRequestRecordBooh();

                        recordBook = Console.ReadLine();

                        ResultCodes isCorrect = ResultCodes.none;

                        CustomFunctions.IsRecordBookCorrect(recordBook,
                                out isCorrect);

                        if (isCorrect != ResultCodes.success)
                        {
                            do
                            {
                                UI.PrintErrorRBWrong(recordBook);
                                UI.PrintRequestRecordBooh();
                                recordBook = Console.ReadLine();
                                CustomFunctions.IsRecordBookCorrect(recordBook,
                                    out isCorrect);

                            } while (isCorrect != ResultCodes.success);

                        }

                        #endregion recordBook

                        groups[choisedGroup].AddStudent(firstName, middleName,
                            lastName, phoneNumber, address, email, recordBook,
                            out operationResult);

                        if (operationResult == ResultCodes.success)
                        {
                            UI.ClearPreviousConsoleLine();
                            UI.PrintSuccess();
                            groups[choisedGroup][recordBook].PrintFullStudentInfo();
                        }
                        else
                        {
                            if(operationResult == ResultCodes.exeptionStudentGroup)
                            {
                                UI.PrintErrorAddingStudent();
                            }
                        }

                        #endregion CREATE

                        break;

                    case CRUD.read:

                        #region READ

                        // print all students in group
                        groups[choisedGroup].ListStudentsInGroup();

                        UI.PrintRequestRecordBooh();

                        recordBook = Console.ReadLine();

                        isCorrect = ResultCodes.none;

                        CustomFunctions.IsRecordBookCorrect(recordBook,
                                out isCorrect);

                        CustomFunctions.ProcessingWrongRB(ref recordBook,
                                ref isCorrect);

                        ResultCodes isRBexist = ResultCodes.none;

                        //  ============= INDEXATOR

                        isRBexist = groups[choisedGroup][recordBook].IsContainRB(recordBook);

                        if (isRBexist != ResultCodes.success)
                        {
                            recordBook = CustomFunctions.ProcessingNonexistentRB(ref groups,
                                choisedGroup, recordBook, out isCorrect,
                                out isRBexist);
                        }

                        groups[choisedGroup][recordBook].PrintFullStudentInfo();

                        #endregion READ

                        break;

                    case CRUD.update:

                        #region UPDATE

                        groups[choisedGroup].ListStudentsInGroup();

                        #region processing RB from USER

                        UI.PrintRequestRecordBooh();

                        recordBook = Console.ReadLine();

                        isCorrect = ResultCodes.none;

                        CustomFunctions.IsRecordBookCorrect(recordBook,
                                out isCorrect);

                        CustomFunctions.ProcessingWrongRB(ref recordBook,
                                ref isCorrect);

                        isRBexist = ResultCodes.none;

                        //  ============= INDEXATOR

                        isRBexist = groups[choisedGroup][recordBook].IsContainRB(recordBook);

                        if (isRBexist != ResultCodes.success)
                        {
                            recordBook = CustomFunctions.ProcessingNonexistentRB(ref groups,
                                choisedGroup, recordBook, out isCorrect,
                                out isRBexist);
                        }

                        #endregion processing RB from USER

                        UI.PrintRequestFieldForChange();

                        FieldForChange fieldForChange = (FieldForChange)Console.ReadKey().Key;

                        operationResult = CustomFunctions.IsFieldExist(fieldForChange,
                            out operationResult);
                        
                        if (operationResult != ResultCodes.success)
                        {                            
                            do
                            {
                                UI.ClearPreviousConsoleLine();
                                UI.PrintErrorChoosingField();

                                fieldForChange = (FieldForChange)Console.ReadKey().Key;

                                operationResult = CustomFunctions.IsFieldExist(fieldForChange,
                                    out operationResult);

                            } while (operationResult != ResultCodes.success);
                        }

                        groups[choisedGroup][recordBook].PrintFullStudentInfo();

                        UI.RequestNewVol();
                        string newVol = Console.ReadLine();

                        CustomFunctions.ChangeField(ref groups, choisedGroup, recordBook,
                            fieldForChange, newVol, out operationResult);

                        if (operationResult == ResultCodes.success)
                        {
                            UI.PrintSucess();
                            groups[choisedGroup][recordBook].PrintFullStudentInfo();
                        }
                        else
                        {
                            UI.PrintError();
                        }

                        #endregion UPDATE

                        break;                    

                    case CRUD.delete:

                        #region DELETE

                        groups[choisedGroup].ListStudentsInGroup();

                        #region processing RB from USER

                        UI.PrintRequestRBForDelete();

                        recordBook = Console.ReadLine();

                        isCorrect = ResultCodes.none;

                        CustomFunctions.IsRecordBookCorrect(recordBook,
                                out isCorrect);

                        CustomFunctions.ProcessingWrongRB(ref recordBook,
                                ref isCorrect);

                        isRBexist = ResultCodes.none;

                        //  ============= INDEXATOR

                        isRBexist = groups[choisedGroup][recordBook].IsContainRB(recordBook);

                        if (isRBexist != ResultCodes.success)
                        {
                            recordBook = CustomFunctions.ProcessingNonexistentRB(ref groups,
                                choisedGroup, recordBook, out isCorrect,
                                out isRBexist);
                        }

                        #endregion processing RB from USER

                        groups[choisedGroup].DeleteStudent(recordBook,
                            out operationResult);

                        if (operationResult == ResultCodes.success)
                        {
                            UI.PrintSucess();

                            groups[choisedGroup].ListStudentsInGroup();
                        }
                        else
                        {
                            UI.PrintError();
                        }

                        #endregion

                        break;
                    case CRUD.move:
                        break;
                    default:
                        break;
                }

                #endregion CRUD

                UI.PrintWhatToDoNext();

                defConsoleKey = Console.ReadKey().Key;

                Console.Clear();

            } while (defConsoleKey != ConsoleKey.Escape);



            Console.ReadKey();
        }

       
    }
}
