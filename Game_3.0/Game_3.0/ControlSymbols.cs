//////////////////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 17/10/2022
// Last Modified On : 30/03/2023
// Description: enum for contain control symbols, for user actions
// Project: Game v3.0
//////////////////////////////////////////////////////////////////

namespace Game3
{
    /// <summary>
    /// Перечисление управляющих символов
    /// </summary>
    public enum ControlSymbols : ushort
    {
        none = 0,
        RightArrow = 39,
        LeftArrow = 37,
        Spacebar = 32,
        Pause = 80,
        Escape = 27,
        Enter = 13
    }
}
