using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW9
{
    /// <summary>
    /// Структура студентов
    /// </summary>
    internal struct Student
    {
        public string firstName;    // имя
        public string middleName;   // отчество
        public string lastName;     // фамилия
        public DateTime birthday;   // день рождения        
        public string address;      // адрес проживания
        public string phonenumber;  // номер телефона
        public string email;        // адрес почты
        public string recordBook;   // номер зачетки

        public int[] marks;         // массив оценок

    }   

}
