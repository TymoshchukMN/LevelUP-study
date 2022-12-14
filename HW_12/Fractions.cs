////////////////////////////////////////////
// Author : Tymoshchuk Maksym
// Created On : 23/11/2022
// Last Modified On : 
// Description: Fractions
// Project: HW_11
////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class Fractions
    {
        #region ПОЛЯ (FIELDS)
                
        private int _numerator;     // числитель
        private int _denominator;   // знаменатель
        private int _whole;         // целое

        #endregion ПОЛЯ (FIELDS)

        #region PROPERTIES

        /// <summary>
        /// Знаменатель
        /// </summary>
        public int Denominator
        {
            get
            {
                return _denominator;
            }
            set
            {
                _denominator = value;
            }
        }

        /// <summary>
        /// Числитель
        /// </summary>
        public int Numerator
        {
            get
            {
                return _numerator;
            }
            set
            {
                _numerator = value;
            }
        }

        /// <summary>
        /// Целое число дроби
        /// </summary>
        public int Whole
        {
            get
            {
                return _whole;
            }
            set
            {
                _whole = value;
            }
        }

        #endregion PROPERTIES

        #region КОНСТРУКТОРЫ

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public Fractions()
        {
            _numerator = 0;
            _denominator = 0;
            _whole = 0;
        }

        /// <summary>
        /// "вторичный" Конструктор
        /// </summary>
        /// <param name="numerator">
        /// числитель
        /// </param>
        /// <param name="denomerator">
        /// знаменатель
        /// </param>
        /// <param name="whole">
        /// целое число
        /// </param>
        public Fractions(int numerator, int denomerator, int whole)
        {
            _numerator = numerator;
            _denominator = denomerator;
            _whole = whole;
        }

        /// <summary>
        /// "вторичный" Конструктор
        /// </summary>
        /// <param name="numerator">
        /// числитель
        /// </param>
        /// <param name="denomerator">
        /// знаменатель
        /// </param>
        public Fractions(int numerator, int denomerator)
        {
            _numerator = numerator;
            _denominator = denomerator;
        }

        public Fractions(Fractions fraction)
        {
            _numerator = fraction.Numerator;
            _denominator = fraction.Denominator;
            _whole = fraction.Whole;
        }

        #endregion КОНСТРУКТОРЫ

        #region METHODS

        // правило суммирования
        // привести дроби к наименьшему общему знаменателю;
        // сложить числители дробей, а знаменатель оставить без изменений;
        // сократить полученную дробь;

        /// <summary>
        /// Операция сложения
        /// </summary>
        /// <param name="firstFraction">
        /// первая дробь
        /// </param>
        /// <param name="secondFraction">
        /// вторая дробь
        /// </param>
        /// <returns>
        /// дробь
        /// </returns>
        public static Fractions operator + (Fractions firstFraction, 
            Fractions secondFraction)
        {
            Fractions result = new Fractions();

            if (firstFraction.Numerator > firstFraction.Denominator)
            {
                CustomMethods.CheckAndFetWhole(firstFraction);
            }

            if (secondFraction.Numerator > secondFraction.Denominator)
            {
                CustomMethods.CheckAndFetWhole(secondFraction);                               
            }

            // если и числитель и знаменатель равны 0,
            // то дробь содержит только целую часть
            if (firstFraction._numerator == 0
                && firstFraction._denominator == 0)
            {
                if (secondFraction._numerator == 0
                    && secondFraction._denominator == 0)
                {
                    result._whole = firstFraction._whole 
                        + secondFraction._whole;
                    
                    return result;
                }
                else
                {
                    result._whole = firstFraction._whole;
                    result._numerator = secondFraction._numerator;
                    result._denominator = secondFraction._denominator;

                    return result;
                }
            }
            else
            {
                if (secondFraction._numerator == 0
                    && secondFraction._denominator == 0)
                {
                    result._whole = secondFraction._whole;
                    result._numerator = firstFraction._numerator;
                    result._denominator = firstFraction._denominator;

                    return result;
                }
                else
                {
                    // одинаковый знаменатель в двух дробях
                    if (firstFraction._denominator 
                        == secondFraction._denominator)
                    {
                        result._numerator = firstFraction._numerator
                            + secondFraction._numerator;

                        result._denominator = firstFraction._denominator;
                        result._whole = firstFraction._whole + secondFraction._whole;
                        
                    }
                    else // знаменатели разные
                    {
                        // находии НОК
                        int LCM 
                            = CustomMethods.DetermineLCM(firstFraction._denominator
                            , secondFraction._denominator);

                        result._numerator = firstFraction._numerator 
                            * (LCM / firstFraction._denominator)
                            + secondFraction._numerator 
                            * (LCM / secondFraction._denominator);

                        result._denominator = LCM;

                        result._whole = firstFraction._whole + secondFraction._whole;
                    }

                    CustomMethods.CutFraction(result);
                }
            }

            if (result.Numerator > result.Denominator)
            {
                if (result.Denominator == 1)
                {
                    if (result.Whole !=0)
                    {
                        result.Whole = result.Whole + result.Numerator;
                    }
                    else
                    {
                        result.Whole = result.Numerator;
                        result.Numerator = 0;
                        result.Denominator = 0;
                    }
                }
                else
                {
                    if (result.Numerator % result.Denominator == 0)
                    {
                        if (result.Whole != 0)
                        {
                            result.Whole = result.Whole + result.Numerator;
                            result.Numerator = 0;
                            result.Denominator = 0;
                        }
                        else
                        {
                            result.Whole = result.Numerator / result.Denominator;
                            result.Numerator = 0;
                            result.Denominator = 0;
                        }
                    }
                    else
                    {
                        CustomMethods.Transform(result);
                    }
                }                
            }

            return result;
        }

        // Правило вычитания
        // привести дроби к наименьшему общему знаменателю;
        // из числителя первой дроби вычесть числитель второй дроби, а знаменатель оставить без изменений;
        // сократить полученную дробь.

        /// <summary>
        /// Операция сложения
        /// </summary>
        /// <param name="firstFraction">
        /// первая дробь
        /// </param>
        /// <param name="secondFraction">
        /// вторая дробь
        /// </param>
        /// <returns>
        /// дробь
        /// </returns>
        public static Fractions operator -(Fractions firstFraction,
            Fractions secondFraction)
        {
            Fractions result = new Fractions();

            if (firstFraction.Numerator > firstFraction.Denominator)
            {
                CustomMethods.CheckAndFetWhole(firstFraction);
            }

            if (secondFraction.Numerator > secondFraction.Denominator)
            {
                CustomMethods.CheckAndFetWhole(secondFraction);

            }

            // если и числитель и знаменатель равны 0,
            // то дробь содержит только целую часть
            if (firstFraction._numerator == 0
                && firstFraction._denominator == 0)
            {
                if (secondFraction._numerator == 0
                    && secondFraction._denominator == 0)
                {
                    result._whole = firstFraction._whole
                        - secondFraction._whole;

                    return result;
                }
                else
                {
                    result._whole = firstFraction._whole;
                    result._numerator = secondFraction._numerator;
                    result._denominator = secondFraction._denominator;

                    return result;
                }
            }
            else
            {
                if (secondFraction._numerator == 0
                    && secondFraction._denominator == 0)
                {
                    result._whole = secondFraction._whole;
                    result._numerator = firstFraction._numerator;
                    result._denominator = firstFraction._denominator;

                    return result;
                }
                else
                {
                    if (firstFraction._whole != 0)
                    {
                        if (secondFraction._whole != 0)
                        {
                            // одинаковый знаменатель в двух дробях
                            if (firstFraction._denominator
                                == secondFraction._denominator)
                            {
                                result._numerator
                                    = ((firstFraction._whole
                                    * firstFraction._denominator
                                    + firstFraction._numerator))
                                    - ((secondFraction._whole
                                    * secondFraction._denominator
                                    + secondFraction._numerator));

                                result._denominator = firstFraction._denominator;
                            }
                            else // знаменатели разные
                            {
                                // находии НОК
                                int LCM
                                    = CustomMethods.DetermineLCM(firstFraction._denominator
                                    , secondFraction._denominator);

                                result._numerator
                                    = ((firstFraction._whole
                                    * firstFraction._denominator
                                    + firstFraction._numerator)
                                    * (LCM / firstFraction._denominator))
                                    - ((secondFraction._whole * secondFraction._denominator + secondFraction._numerator))
                                    * (LCM / secondFraction._denominator);

                                result._denominator = LCM;
                            }
                        }
                        else
                        {
                            // одинаковый знаменатель в двух дробях
                            if (firstFraction._denominator
                                == secondFraction._denominator)
                            {
                                result._numerator
                                    = ((firstFraction._whole
                                    * firstFraction._denominator
                                    + firstFraction._numerator))
                                    - (secondFraction._denominator
                                    + secondFraction._numerator);

                                result._denominator = firstFraction._denominator;

                            }
                            else // знаменатели разные
                            {
                                // находии НОК
                                int LCM
                                    = CustomMethods.DetermineLCM(firstFraction._denominator
                                    , secondFraction._denominator);

                                result._numerator
                                    = ((firstFraction._whole
                                    * firstFraction._denominator
                                    + firstFraction._numerator)
                                    * (LCM / firstFraction._denominator))
                                    - (secondFraction._numerator
                                    * (LCM / secondFraction._denominator));

                                result._denominator = LCM;
                            }
                        }
                    }
                    else // firstFraction._whole !=0
                    {
                        if (secondFraction._whole != 0)
                        {
                            // одинаковый знаменатель в двух дробях
                            if (firstFraction._denominator
                                == secondFraction._denominator)
                            {
                                result._numerator
                                    = (firstFraction._denominator
                                    + firstFraction._numerator)
                                    - ((secondFraction._whole
                                    * secondFraction._denominator
                                    + secondFraction._numerator));

                                result._denominator = firstFraction._denominator;
                            }
                            else // знаменатели разные
                            {
                                // находии НОК
                                int LCM
                                    = CustomMethods.DetermineLCM(firstFraction._denominator
                                    , secondFraction._denominator);

                                result._numerator
                                    = firstFraction._denominator
                                    + firstFraction._numerator
                                    * (LCM / firstFraction._denominator)
                                    - ((secondFraction._whole 
                                    * secondFraction._denominator 
                                    + secondFraction._numerator))
                                    * (LCM / secondFraction._denominator);

                                result._denominator = LCM;

                            }
                        }
                        else
                        {
                            // одинаковый знаменатель в двух дробях
                            if (firstFraction._denominator
                                == secondFraction._denominator)
                            {
                                result._numerator
                                    = (firstFraction._denominator
                                    + firstFraction._numerator)
                                    - (secondFraction._denominator
                                    + secondFraction._numerator);

                                result._denominator = firstFraction._denominator;
                            }
                            else // знаменатели разные
                            {
                                // находии НОК
                                int LCM
                                    = CustomMethods.DetermineLCM(firstFraction._denominator
                                    , secondFraction._denominator);

                                result._numerator
                                    = firstFraction._numerator
                                    * (LCM / firstFraction._denominator)
                                    - (secondFraction._numerator
                                    * (LCM / secondFraction._denominator));

                                result._denominator = LCM;
                            }
                            //CustomMethods.CutFraction(result);
                        }
                    }
                }
            }

            CustomMethods.CutFraction(result);
            
            if (Math.Abs(result.Numerator) > Math.Abs(result.Denominator))
            {
                if (result.Denominator == 1)
                {
                    if (result.Whole != 0)
                    {
                        result.Whole = result.Whole - result.Numerator;
                    }
                    else
                    {
                        result.Whole = result.Numerator;
                        result.Numerator = 0;
                        result.Denominator = 0;
                    }
                }
                else
                {
                    if (result.Numerator % result.Denominator == 0)
                    {
                        if (result.Whole != 0)
                        {
                            result.Whole = result.Whole - result.Numerator;
                            result.Numerator = 0;
                            result.Denominator = 0;
                        }
                        else
                        {
                            result.Whole = result.Numerator / result.Denominator;
                            result.Numerator = 0;
                            result.Denominator = 0;
                        }
                    }
                    else
                    {
                        CustomMethods.Transform(result);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Операция деления
        /// </summary>
        /// <param name="firstFraction">
        /// первая дробь
        /// </param>
        /// <param name="secondFraction">
        /// вторая дробь
        /// </param>
        /// <returns>
        /// результат деления
        /// </returns>
        public static Fractions operator /(Fractions firstFraction,
                    Fractions secondFraction)
        {
            Fractions result = new Fractions();                        

            if (firstFraction._whole != 0)
            {
                if (secondFraction._whole != 0)
                {
                    result._numerator 
                        = (firstFraction._whole * firstFraction._denominator 
                        + firstFraction._numerator)
                        * secondFraction._denominator;

                    result._denominator
                        = (secondFraction._whole * secondFraction._denominator 
                        + secondFraction._numerator)
                        * firstFraction._denominator;

                }
                else
                {
                    result._numerator
                        = (firstFraction._whole * firstFraction._denominator 
                        + firstFraction._numerator)
                        * secondFraction._denominator;

                    result._denominator = firstFraction._denominator 
                        * secondFraction._numerator;
                }                
            }
            else
            {
                if (secondFraction._whole != 0)
                {
                    result._numerator = firstFraction._numerator 
                        * secondFraction._denominator;
                        

                    result._denominator = firstFraction._denominator 
                        * (secondFraction._whole * secondFraction._denominator 
                        + secondFraction._numerator);
                }
                else
                {
                    result._numerator = firstFraction._numerator 
                        * secondFraction._denominator;
                    result._denominator = firstFraction._denominator 
                        * secondFraction._numerator;
                }
            }

            CustomMethods.CutFraction(result);

            if (result._numerator > result._denominator)
            {
                CustomMethods.Transform(result);
            }

            return result;
        }

        /// <summary>
        /// Операция умножения
        /// </summary>
        /// <param name="firstFraction">
        /// первая дробь
        /// </param>
        /// <param name="secondFraction">
        /// вторая дробь
        /// </param>
        /// <returns>
        /// результат умножения
        /// </returns>
        public static Fractions operator *(Fractions firstFraction,
                    Fractions secondFraction)
        {
            Fractions result = new Fractions();
            
            if (firstFraction._whole != 0)
            {
                if (secondFraction._whole != 0)
                {
                    result._numerator
                        = (firstFraction._whole
                        * firstFraction._denominator
                        + firstFraction._numerator)
                        * (secondFraction._whole
                        * secondFraction._denominator
                        + secondFraction._numerator);

                    result._denominator
                        = firstFraction._denominator
                        * secondFraction._denominator;
                }
                else
                {
                    result._numerator
                         = (firstFraction._whole
                         * firstFraction._denominator
                         + firstFraction._numerator)
                         * secondFraction._numerator;

                    result._denominator
                        = firstFraction._denominator
                        * secondFraction._denominator;
                }
            }
            else
            {
                if (secondFraction._whole != 0)
                {
                    result._numerator
                        = (secondFraction._whole
                        * secondFraction._denominator
                        + secondFraction._numerator)
                        * firstFraction._numerator;
                        
                    result._denominator
                        = firstFraction._denominator
                        * secondFraction._denominator;
                }
                else
                {
                    result._numerator
                        = firstFraction._numerator
                        * secondFraction._numerator;

                    result._denominator
                        = firstFraction._denominator
                        * secondFraction._denominator;
                }
            }

            CustomMethods.CutFraction(result);
            CustomMethods.Transform(result);

            return result;
        }

        public static bool operator <(Fractions firstFraction,
                    Fractions secondFraction)
        {
            // Из двух дробей с одинаковыми знаменателями больше та дробь,
            // числитель которой больше.

            Fractions temp = new Fractions();

            // true - первая дроби больше второй
            bool res = false;

           

            if (firstFraction._whole != 0)
            {
                if (secondFraction._whole != 0)
                {
                    int first = firstFraction._whole 
                        * firstFraction._denominator 
                        + firstFraction._numerator;

                    int second = secondFraction._whole 
                        * secondFraction._denominator 
                        + secondFraction._numerator;

                    if (firstFraction._denominator == secondFraction._denominator)
                    {
                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                    else
                    {
                        int LCM =
                            CustomMethods.DetermineLCM(firstFraction._denominator
                           , secondFraction._denominator);

                        first = LCM / firstFraction._denominator * first;
                        second = LCM / secondFraction._denominator * second;

                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                }
                else
                {
                    int first = firstFraction._whole
                        * firstFraction._denominator
                        + firstFraction._numerator;

                    int second = secondFraction._numerator;

                    if (firstFraction._denominator == secondFraction._denominator)
                    {
                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                    else
                    {
                        int LCM =
                            CustomMethods.DetermineLCM(firstFraction._denominator
                           , secondFraction._denominator);

                        first = LCM / firstFraction._denominator * first;
                        second = LCM / secondFraction._denominator * second;

                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                }
            }
            else
            {
                if (secondFraction._whole != 0)
                {

                    int first = firstFraction._numerator;

                    int second = secondFraction._whole
                        * secondFraction._denominator
                        + secondFraction._numerator;

                    if (firstFraction._denominator == secondFraction._denominator)
                    {
                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                    else
                    {
                        int LCM =
                            CustomMethods.DetermineLCM(firstFraction._denominator
                           , secondFraction._denominator);

                        first = LCM / firstFraction._denominator * first;
                        second = LCM / secondFraction._denominator * second;

                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                }
                else
                {
                    if (firstFraction._denominator == secondFraction._denominator)
                    {
                        if (firstFraction._numerator > secondFraction._numerator)
                        {
                            res = true;

                            return res;
                        }
                    }
                    else
                    {
                        // Чтобы сравнить две обыкновенные дроби, следует
                        // привести дроби к общему знаменателю и сравнить 
                        // числители получившихся дробей. Дробь с большим 
                        // числителем будет больше.
                        int LCM =
                        CustomMethods.DetermineLCM(firstFraction._denominator
                            , secondFraction._denominator);

                        int first = LCM / firstFraction._denominator * firstFraction._numerator;
                        int second = LCM / secondFraction._denominator * secondFraction._numerator;

                        if (first > second)
                        {
                            res = true;

                            return res;
                        }
                    }
                }
            }

            return res;
        }

        public static bool operator >(Fractions firstFraction,
                    Fractions secondFraction)
        {
            
            return (!(firstFraction < secondFraction));
        }

        #endregion METHODS
    }
}
