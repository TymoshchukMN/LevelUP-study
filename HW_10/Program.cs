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
            const ushort COUNT_GROUPS           = 2;
            const ushort INDEX_FINANCE_GROUP    = 0;
            const ushort INDEX_MATH_GROUP       = 1;
            const ushort ERROR_RUNTIME          = 1603;

            StudentsGroup[] groups = new StudentsGroup[COUNT_GROUPS];

            bool isManualFill = false;

            groups[INDEX_FINANCE_GROUP] = new StudentsGroup(GroupNames.Finance,
                    isManualFill);

            groups[INDEX_MATH_GROUP] = new StudentsGroup(GroupNames.Mathematics,
                    isManualFill);

            ConsoleKey defConsoleKey = ConsoleKey.D0;

            do
            {
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

                Console.Clear();

                switch (operation)
                {
                    case CRUD.create:
                        
                        /*StudentCard tmpCard = new StudentCard(
                            Faker.Name.First(),
                            Faker.Name.Middle(),
                            Faker.Name.Last(),
                            RB
                        );*/

                        break;

                    case CRUD.read:

                        groups[choisedGroup].ListStudentsInGroup();

                        UI.PrintRequestRecordBookForSearch();

                        // переменная для хранения номера учетки
                        string recordBook;

                        recordBook = Console.ReadLine();

                        break;
                    case CRUD.update:
                        break;
                    case CRUD.delete:
                        break;
                    case CRUD.move:
                        break;
                    default:
                        break;
                }

                UI.PrintWhatToDoNext();
                defConsoleKey = Console.ReadKey().Key;

            } while (defConsoleKey != ConsoleKey.Escape);
            

            

            Console.ReadKey();
        }
    }
}
