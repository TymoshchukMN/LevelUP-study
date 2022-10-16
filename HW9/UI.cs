using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    internal class UI
    {
        public static string[] groupName = { "финансисты", "математики" };

        /// <summary>
        /// печать содержимого элементов структуры
        /// </summary>
        /// <param name="students">
        /// элемент структуры
        /// </param>
        public static void PrintAddedStudents(ref Student [] students,
                ushort countAddStudents)
        {
            Console.Clear();
            // количество студентов, -1 используем, т.к. Count возвращает
            // количество студентов, а нам нужен индекс, он не 1 меньше
            int firtsIndexForPrint = students.Count() - countAddStudents;
            for (int i = firtsIndexForPrint; i < students.Count(); i++)
            {                
                
                Console.WriteLine(new String('=', 50));

                Console.Write($"firstName\t{students[i].firstName}\n" +
                        $"middleName\t{students[i].middleName}\n" +
                        $"lastName\t{students[i].lastName}\n" +
                        $"birthday\t{students[i].birthday}\n" +
                        $"phonenumber\t{students[i].phonenumber}\n" +
                        $"address\t\t{students[i].address}\n" +
                        $"email\t\t{students[i].email}\n" +
                        $"record book:\t");

                ConsoleColor defaultConsoleColor = Console.ForegroundColor;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("{0}\n", students[i].recordBook);

                Console.ForegroundColor = defaultConsoleColor;

                Console.Write($"marks:\t");
                PrintStudentsMarks(students[i].marks);
            }
            
        }

        /// <summary>
        /// печать карточки крнкретного студента
        /// </summary>
        /// <param name="students"></param>
        /// <param name="index"></param>
        public static void PrintUserCard(ref Student[] students, int index)
        {
            Console.WriteLine();
            Console.WriteLine(new String('=', 50));

            Console.Write($"firstName\t{students[index].firstName}\n" +
                    $"middleName\t{students[index].middleName}\n" +
                    $"lastName\t{students[index].lastName}\n" +
                    $"birthday\t{students[index].birthday}\n" +
                    $"phonenumber\t{students[index].phonenumber}\n" +
                    $"address\t\t{students[index].address}\n" +
                    $"email\t\t{students[index].email}\n" +
                    $"record book:\t");
            
            ConsoleColor defaultConsoleColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}\n",students[index].recordBook);

            Console.ForegroundColor = defaultConsoleColor;

            Console.Write($"marks:\t");
            PrintStudentsMarks(students[index].marks);
        }

        /// <summary>
        /// Printing studet's marks
        /// </summary>
        /// <param name="marks">
        /// studet's marks (Array)
        /// </param>
        public static void PrintStudentsMarks(int[] marks)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                Console.Write("{0} ", marks[i]);
            }
        }        

        /// <summary>
        /// печать всех студентов группы
        /// </summary>
        /// <param name="students">
        /// группа студентов
        /// </param>
        public static void PrintGroupContent(ref Student[] students, int goupNum)
        {
            Console.Clear();
            ConsoleColor defaultConsoleColor = Console.ForegroundColor;

            Console.Write("Студенты в группе ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("{0}\n", groupName[goupNum-1]);
            Console.ForegroundColor = defaultConsoleColor;

            for (int i = 0; i < students.Count(); i++)
            {
                Console.WriteLine(new String('=', 50));
                

                Console.Write($"Student:\t{students[i].firstName} " +
                        $"{students[i].middleName} " +
                        $"{students[i].lastName}\n" +
                        $"phonenumber\t{students[i].phonenumber}\n" +
                        $"address\t\t{students[i].address}\n" +
                        $"record book:\t");                

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0}\n", students[i].recordBook);

                Console.ForegroundColor = defaultConsoleColor;
            }
        }

        /// <summary>
        /// печать запроса количества студентов к добавлению
        /// </summary>
        public static void PrintRequestCountStudent()
        {
            Console.Write("Какаое количество студентов хотите добавить:\t");
        }

        /// <summary>
        /// запрос группы для добавления
        /// </summary>
        public static void PrintRequestGroup()
        {
            Console.WriteLine("Выберите группу:\n" +
                           "\n1. Финансисты" +
                           "\n2. Математики");
        }

        /// <summary>
        /// печать банера на запрос количества студентов к добавлению
        /// </summary>
        /// <param name="countAddStudents"></param>
        public static void PrintDenyAddBanner(ushort countAddStudents, 
                ref Student[] students, ushort maxStudetsCouutn)
        {
            
            Console.WriteLine("Нельзя добавить \"{0}\" студентов. " +
                "Фактическое количество: {1}, максимально допустимое: {2}", 
                    countAddStudents, students.Count(), maxStudetsCouutn);
        }

        /// <summary>
        /// печать банера на запрос номер зачетки
        /// </summary>
        public static void PrintRequestRecordBook()
        {
            Console.WriteLine("Введите номер зачетки: в формате XX000000" +
                "\nсначала 2 символа латиницей, затем 6 цифр\n");
        }

        public static void PrintRequestRecordBookForSearch()
        {
            Console.WriteLine("Введите номер зачетки: в формате XX000000" +
                "\nили укажите символы для поиска");
        }

        public static void PrintErrorRecordBook()
        {
            Console.WriteLine("Не правильный номер учетки," +
                           "введите повторно: ");
        }

        public static void PrintErrorRBExist()
        {
            Console.WriteLine("Такой номер учетки уже есть. Укажите другой номер");
        }

        public static void PrintErrorRBNOTExist()
        {
            ConsoleColor defaultConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("\nТакого номера нет. ");

            Console.ForegroundColor = defaultConsoleColor;
            Console.WriteLine("Укажите другой номер\n");
        }

        /// <summary>
        /// вывод на эран всех номеров зачеток
        /// </summary>
        /// <param name="groupOfStudents">
        /// группа стедентов
        /// </param>
        public static void PrintExistingRB(ref Group groupOfStudents)
        {
            Console.WriteLine("Номера учеток в группе \"{0}\"", groupOfStudents.name);
            Console.WriteLine();
            for (int i = 0; i < groupOfStudents.students.Count(); i++)
            {
                // печать карточки, у которой есть совпаления
                // по капрашиваемому номеру учетки
                Console.WriteLine(groupOfStudents.students[i].recordBook);
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Запрос поле для изменения
        /// </summary>
        public static void RequestFieldForChange()
        {
            Console.WriteLine("Укажите номер поля к изменению:\n" +
                    "1. Имя\n" +
                    "2. Фамилия\n" +
                    "3. Отчество\n" +
                    "4. День рождения\n" +
                    "5. Адрес проживания\n" +
                    "6. Номер телефона\n" +
                    "7. email\n" +
                    "8. Номер Учетки\n");
        }

        /// <summary>
        /// запрос нового значения
        /// </summary>
        public static void RequestNewVol()
        {
            Console.Clear();
            Console.WriteLine("Укажите новое значение: ");
        }

        public static void PrintEndProgram()
        {
            Console.WriteLine("\n{0}",new string ('=',50));
            Console.WriteLine("Нажмине любую клавишу для продолжения," +
                "или Esc для завершения работы программы");
        }

        /// <summary>
        /// Запрос действий у пользователя
        /// </summary>
        public static void PrintRequestAction()
        {
            Console.WriteLine("Выберите тип операции:\n" +
                        "\n\t1. create" +
                        "\n\t2. read" +
                        "\n\t3. update" +
                        "\n\t4. delete" +
                        "\n\t5. Move student to another grouop");

        }
        /*/// <summary>
        /// Печать доступных групп для перемещения
        /// </summary>
        /// <param name="groups">
        /// групы студентов
        /// </param>
        /// <param name="indexGroup">
        /// Уже выбранная группа, из которой будет перемещен студент
        /// </param>
        public static void PrintAvailableGroupForMoving(ref Group[] groups,
                ushort indexGroup)
        {
            Console.WriteLine("Доступные группы для перемещения:\n");
            for (int i = 0; i < groups.Count(); i++)
            {
                if (i != indexGroup)
                {
                    Console.WriteLine("{0} - {1}", i + 1, groups[i].name);
                }
            }
        }*/

        /// <summary>
        /// Printing error, that moving to selected group is impossible
        /// </summary>
        public static void PrintErrorImpossibleMovingToGroup()
        {
            Console.WriteLine("Такой группы или нет, или в нее нельзя " +
                "переместить студента. Выберите другую группу");
        }

        /// <summary>
        /// Print request group for moving
        /// </summary>
        /// <param name="groups">
        /// Existing group struct 
        /// </param>
        /// <param name="indexGroup">
        /// index selected group from which might be moved
        /// student
        /// </param>
        public static void PrintRequestGroupForMoving(ref Group[] groups,
                ushort indexGroup)
        {
            Console.WriteLine("\nДоступные группы для перемещения");
            for (int i = 0; i < groups.Count(); i++)
            {
                if (i != indexGroup)
                {
                    Console.WriteLine("{0} - {1}", i + 1, groups[i].name);
                }
            }
        }

        public static void PrintMovingResult()
        {
            Console.WriteLine("Moving completed");
        }
    }

}

