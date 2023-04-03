using System;


namespace Game3
{

    /// <summary>
    /// Пользовательские фукции
    /// </summary>
    internal class BL
    {

        const ushort COUNT_BUG_TYPE_1   = 14;
        const ushort COUNT_BUG_TYPE_2   = 28;
        const ushort COUNT_BUG_TYPE_3   = 42;

        // number of columns with beetles
        const ushort COLUMN_COUNT       = 7;


        /// <summary>
        /// Заполнение структуры с жуками
        /// </summary>
        /// <param name="bugs">
        /// структура для заполнения
        /// </param>
        public static void FillBugs(ref Beetle[] bugs)
        {
            const ushort STEP_ROW = 1;
            const ushort STEP_COLUMN = 4;

            // starting position of the cursor from the top of the console
            const ushort START_TOP_CURSOR_POSITION = 4;

            // starting position of the cursor from the left side of the console
            const ushort LEFT_CURSOR_POSITION = 6;

            ushort xCoor = LEFT_CURSOR_POSITION;
            ushort yCoor = START_TOP_CURSOR_POSITION;

            byte fillFlag = 0b0;

            for (int i = 0; i < bugs.Length; i++)
            {
                if (i < COUNT_BUG_TYPE_1)
                {
                    SetCoordinates(bugs, BeetleTypes.type1, COLUMN_COUNT
                        , STEP_COLUMN, ref xCoor, yCoor, ref fillFlag
                        , ref i);
                }
                else
                {
                    if (i < COUNT_BUG_TYPE_2)
                    {

                        SetCoordinates(bugs, BeetleTypes.type2, COLUMN_COUNT
                            , STEP_COLUMN, ref xCoor, yCoor, ref fillFlag
                            , ref i);
                    }
                    else
                    {
                        if (i < COUNT_BUG_TYPE_3)
                        {
                            SetCoordinates(bugs, BeetleTypes.type3, COLUMN_COUNT
                                , STEP_COLUMN, ref xCoor, yCoor, ref fillFlag
                                , ref i);
                        }
                        else
                        {

                            if (i >= bugs.Length)
                            {
                                break;
                            }
                            --i;
                        }
                    }
                }
                yCoor += STEP_ROW;
            }
        }

        /// <summary>
        /// Установка координат жуков при заполнении 
        /// </summary>
        /// <param name="bugs">
        /// массив жуков
        /// </param>
        /// <param name="bugType">
        /// тип жука к заполнению
        /// </param>
        /// <param name="countColumns">
        /// количество столюцов жуков
        /// </param>
        /// <param name="STEP_COLUMN">
        /// шаг по столбцам (константа)
        /// </param>
        /// <param name="xCoor">
        /// координата первого элемента жука от слевого края консоли 
        /// </param>
        /// <param name="yCoor">
        /// координата жука от верхнего края консоли 
        /// </param>
        /// <param name="fillFlag">
        /// флаг, определяющий какой тип жука печатать
        /// </param>
        /// <param name="i">
        /// внешний итератор для перебора массива жуков
        /// </param>
        private static void SetCoordinates(Beetle[] bugs,
                BeetleTypes bugType, ushort countColumns, ushort STEP_COLUMN,
                ref ushort xCoor, ushort yCoor,
                ref byte fillFlag, ref int i)
        {
            if (fillFlag == 0b0)
            {
                switch (bugType)
                {
                    case BeetleTypes.type1:

                        for (int k = 0; k < countColumns; k++)
                        {
                            xCoor += STEP_COLUMN;

                            bugs[i] = new BeetleType1(xCoor, yCoor);
                            
                            ++i;
                        }
                        fillFlag = (byte)~fillFlag;

                        --i;

                        break;

                    case BeetleTypes.type2:

                        for (int k = 0; k < countColumns; k++)
                        {
                            xCoor += STEP_COLUMN;

                            bugs[i] = new BeetleType2(xCoor, yCoor);
                            ++i;
                        }
                        fillFlag = (byte)~fillFlag;

                        --i;

                        break;
                    case BeetleTypes.type3:

                        for (int k = 0; k < countColumns; k++)
                        {
                            xCoor += STEP_COLUMN;
                            bugs[i] = new BeetleType3(xCoor, yCoor);
                            
                            ++i;
                        }
                        fillFlag = (byte)~fillFlag;

                        --i;
                        break;
                }
            }
            else // if(fillFlag == 0b0)
            {
                switch (bugType)
                {
                    case BeetleTypes.type1:

                        for (int k = 0; k < countColumns; k++)
                        {
                            xCoor -= STEP_COLUMN;

                            bugs[i] = new BeetleType1(xCoor, yCoor);

                            ++i;
                        }
                        fillFlag = (byte)~fillFlag;

                        --i;

                        break;
                    case BeetleTypes.type2:

                        for (int k = 0; k < countColumns; k++)
                        {
                            xCoor -= STEP_COLUMN;

                            bugs[i] = new BeetleType2(xCoor, yCoor);

                            ++i;
                        }
                        fillFlag = (byte)~fillFlag;

                        --i;

                        break;
                    case BeetleTypes.type3:

                        for (int k = 0; k < countColumns; k++)
                        {
                            xCoor -= STEP_COLUMN;

                            bugs[i] = new BeetleType3(xCoor, yCoor);

                            ++i;
                        }
                        fillFlag = (byte)~fillFlag;

                        --i;
                        break;
                }
            }
        }

        /// <summary>
        /// Получаем направление движения жуков
        /// </summary>
        /// <param name="bugs">
        /// структура жуков
        /// </param>
        /// <param name="directionBugsRows">
        /// перемнная, хранящая направление
        /// </param>
        /// <param name="rightBoardPosition">
        /// позиция правой границы консоли
        /// </param>
        /// <param name="leftBoardPosition">
        /// позиция леврй границы консоли
        /// </param>
        public static void GetDirection(ref Beetle[] bugs,
                ref byte directionBugsRows, ushort rightBoardPosition,
                ushort leftBoardPosition)
        {
            
            ushort lastElementPosition = FindLastElementInRows(ref bugs);
            ushort firtsElementPosition = FindFirstElementInRows(ref bugs);

            if (lastElementPosition >= rightBoardPosition)
            {
                directionBugsRows = 0b1;
            }
            else
            {
                if (firtsElementPosition <= leftBoardPosition)
                {
                    directionBugsRows = 0b0;
                }
            }
        }

        /// <summary>
        /// возвращаем кообдинату столбца последнего элемента 
        /// справа в массиве жуков
        /// </summary>
        /// <param name="bugs"></param>
        /// <returns>
        /// координата столбца
        /// </returns>
        public static ushort FindLastElementInRows(ref Beetle[] bugs)
        {
            ushort posElement = 0;
            
            for (int i = 0; i < bugs.GetLength(0); i++)
            {

                if (i < COUNT_BUG_TYPE_1)
                {
                    if (bugs[i].X > posElement)
                    {
                        posElement
                            = (ushort)(bugs[i].X + Beetle.BEETLE_LENGHT);
                    }
                }
                else
                {
                    if (bugs[i].X < COUNT_BUG_TYPE_2)
                    {
                        if (bugs[i].X > posElement)
                        {
                            posElement
                            = (ushort)(bugs[i].X + Beetle.BEETLE_LENGHT);

                        }
                    }
                    else
                    {
                        if (i < COUNT_BUG_TYPE_3)
                        {
                            if (bugs[i].X > posElement)
                            {
                                posElement
                             = (ushort)(bugs[i].X + Beetle.BEETLE_LENGHT);
                            }
                        }
                    }
                }
            }

            return posElement;
        }

        /// <summary>
        /// возвращаем кообдинату столбца последнего элемента 
        /// слева в массиве жуков
        /// </summary>
        /// <param name="bugs"></param>
        /// <returns>
        /// координата столбца
        /// </returns>
        public static ushort FindFirstElementInRows(ref Beetle[] bugs)
        {

            ushort posElement = ushort.MaxValue;

            for (int i = 0; i < bugs.GetLength(0); i++)
            {

                if (i < COUNT_BUG_TYPE_1)
                {
                    if ((bugs[i] as BeetleType1).X < posElement)
                    {
                        posElement = (bugs[i] as BeetleType1).X;
                    }
                }
                else
                {
                    if (i < COUNT_BUG_TYPE_2)
                    {
                        if ((bugs[i] as BeetleType2).X < posElement)
                        {
                            posElement = (bugs[i] as BeetleType2).X;
                        }
                    }
                    else
                    {
                        if (i < COUNT_BUG_TYPE_3)
                        {
                            if ((bugs[i] as BeetleType3).X < posElement)
                            {
                                posElement = (bugs[i] as BeetleType3).X;
                            }
                        }
                    }
                }
            }
            return posElement;
        }

        /// <summary>
        /// Очистка жука в консоли при перемещении жуков
        /// </summary>
        /// <param name="x">
        /// координата первого символа массива элементов жука
        /// по оси Х
        /// </param>
        /// <param name="y">
        /// координата  жука по оси У
        /// </param>
        /// <<param name="beetle_lenth">
        /// количество элементов жука
        /// </param>
        public static void ClerBugInConsole(ushort x, ushort y
                , ushort beetle_lenth)
        {
            for (ushort i = 0; i < beetle_lenth; ++i)
            {
                Console.SetCursorPosition(x, y);
                Console.Write((char)GameSymbols.none);
                ++x;
            }
        }

        /// <summary>
        /// Изменение коордитат жуков
        /// </summary>
        /// <param name="bugs">
        /// массив жуков
        /// </param>
        /// <param name="leftBoardPosition">
        /// позиция левой стороны консоли
        /// </param>
        /// <param name="rightBoardPosition">
        /// позиция правой стороны консоли
        /// </param>
        /// <param name="directionPrintFlag">
        /// флаг направления движения жуков (вправа/влево)
        /// </param>
        public static void MoveBugsInsideConsole(ref Beetle[] bugs
                , ushort leftBoardPosition, ushort rightBoardPosition
                , ref byte directionPrintFlag)
        {
            GetDirection(ref bugs, ref directionPrintFlag, rightBoardPosition
                    , leftBoardPosition);

            for (ushort i = 0; i < bugs.Length; ++i)
            {
                bugs[i].Move(leftBoardPosition, rightBoardPosition
                        ,ref directionPrintFlag);
            }

        }


        /// <summary>
        /// Проверка перемечения пули
        /// </summary>
        /// <param name="bugX">
        /// X - координата жука
        /// </param>
        /// <param name="bugY">
        /// У - координата жука
        /// </param>
        /// <param name="booletX">
        /// X - координата пули
        /// </param>
        /// <param name="booletY">
        /// У - координата жука
        /// </param>
        /// <param name="bugType">
        /// фактический тип жука
        /// </param>
        /// <returns></returns>
        public static bool CheckIfBulletAcrossBeetle(ref Beetle [] beetles, ushort booletX,
            ushort booletY, out ushort resAccrossPosition, ref short beetleIndex)
        {
            bool isAcross = false;

            resAccrossPosition = 0;
            for (int i = beetles.Length - 1; i >= 0; i--)
            {
                if (beetles[i].BeetleType == BeetleTypes.none)
                {
                    continue;
                }
                if ((beetles[i].X == booletX) && (beetles[i].Y == booletY))
                {
                    resAccrossPosition = 1;
                    isAcross = true;
                    beetleIndex = (short)i;
                    break;
                }
                else
                {
                    if ((beetles[i].X + 1 == booletX) && (beetles[i].Y == booletY))
                    {
                        resAccrossPosition = 2;
                        isAcross = true;
                        beetleIndex = (short)i;
                        break;
                    }
                    else
                    {
                        if ((beetles[i].X + 2 == booletX) && (beetles[i].Y == booletY))
                        {
                            resAccrossPosition = 3;
                            isAcross = true;
                            beetleIndex = (short)i;
                            break;
                        }
                    }
                }
            }

            return isAcross;
        }
    }
}
