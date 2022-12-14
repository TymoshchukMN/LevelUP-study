////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 17/11/2022
// Last Modified On : 
// Description: Enum CRUD operations
// Project: HW_11
////////////////////////////////////////////


namespace HW_11
{
    /// <summary>
    /// CRUD
    /// </summary>
    enum CRUD :ushort
    {
        none    = 0,
        create  = 97,   // '1' numpad
        read    = 98,   // '2'
        update  = 99,   // '3'
        delete  = 100,  // '4'
        move    = 101   // '5
    }
}
