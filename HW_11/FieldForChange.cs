////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 17/11/2022
// Last Modified On:
// Description: list filds for change
// Project: HW_11
////////////////////////////////////////////

namespace HW_11
{
    /// <summary>
    /// поля для изменения
    /// </summary>
    enum FieldForChange : ushort
    {
        none = 0,
        firstName = 97,    // имя
        middleName = 98,   // отчество
        lastName = 99,     // фамилия
        addressRegistration = 100,
        addressResidential = 101
    }
}