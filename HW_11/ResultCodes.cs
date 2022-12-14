////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 25/10/2022
// Last Modified On : 17/11/2022
// Description: codes result operations
// Project: HW_11
////////////////////////////////////////////


namespace HW_11
{
    /// <summary>
    /// codes of execution
    /// </summary>
    enum ResultCodes : ushort
    {
        none = 0,                   // значение по умолчанию
        success = 1,                // операция прошла успешно
        exeptionStudentGroup = 2,   // группа переполнена, добавление не возможно
        fieldNotExist = 3,          // поле студента не существует
        groupNotExist = 4,          // группа не существует
        addStudentAvailable = 5,    // возможно добавление студента
        RBisNotCorrect = 6,
        RBexist         = 7,
        error = 1603                // ошибка выполнения
    }
}