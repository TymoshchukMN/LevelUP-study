////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 03/11/2022
// Last Modified On : 03/11/2022 
// Description: list filds for change
// Project: HW_10
////////////////////////////////////////////

namespace HW_10
{
    /// <summary>
    /// поля для изменения
    /// </summary>
    enum FieldForChange : ushort
    {
        none        = 0,
        firstName   = 97,    // имя
        middleName  = 98,   // отчество
        lastName    = 99,     // фамилия
        phoneNumber = 100,
        address     = 101,
        email       = 102
    }
}
