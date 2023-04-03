////////////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 26/12/2022
// Last Modified On : 
// Description: Перечисление игровых символов
// Project: Game
////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game3
{
    /// <summary>
    /// Символы игровой консоли
    /// </summary>
    public enum GameSymbols : ushort
    {
        none = 0,
        bugType1CentralItem1 = 45,   // '0'
        bugType1CentralItem2 = 111,  // 'o'
        bugType1Side1 = 47,         // '/'
        bugType1Side2 = 92,         // '\'

        bugType2CentralItem1 = 164, // '¤'
        bugType2CentralItem2 = 94,  // '^'
        bugType2Side1 = 60,         // '<'
        bugType2Side2 = 62,         // '>'

        bugType3CentralItem1 = 337, // 'ő'
        bugType3CentralItem2 = 164, // '¤'
        bugType3Side1 = 95,         // '_'
        bugType3Side2 = 45,         // '-'

        bugType3 = 246,     // 'ő'
        boolet = 176,       // '°'
        shooter = 9577,     // '╩'

        LEFT_TOP = 9556,    // '╔'
        LEFT_DOWN = 9562,   // '╚'
        RIGHT_DOWN = 9565,  // '╝'
        RIGHT_TOP = 9559,   // '╗',
        HORIZONTAL = 9552,  // '═',
        VERTICAL = 9553     //'║',

    }
}