using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isInputCorrect;

            #region Обработка первой дроби

            #region Обработка целого числа

            UI.RequestFirstWhole();

            string firstWholestr = Console.ReadLine();

            int firstWhole = 0;

            if (!(firstWholestr == string.Empty))
            {
                isInputCorrect = int.TryParse(firstWholestr, out firstWhole);
                
                if (!isInputCorrect)
                {
                    do
                    {
                        UI.PrintErrorInput();
                        UI.RequestFirstWhole();
                        isInputCorrect = int.TryParse(Console.ReadLine(), out firstWhole);

                    } while (!isInputCorrect);
                   
                }
            }

            #endregion Обработка целого числа

            #region Первый числитель

            UI.RequestFirstNumerator();

            isInputCorrect = int.TryParse(Console.ReadLine(), out int firstNumerator);

            if (!isInputCorrect)
            {
                do
                {
                    UI.PrintErrorInput();
                    UI.RequestFirstNumerator();
                    isInputCorrect = int.TryParse(Console.ReadLine(), out firstNumerator);

                } while (!isInputCorrect);
            }

            #endregion Первый числитель

            #region Первый знаменатель

            UI.RequestFirstDenominator();

            isInputCorrect = int.TryParse(Console.ReadLine(), out int firstDenominator);

            if (!isInputCorrect)
            {
                do
                {
                    UI.PrintErrorInput();
                    UI.RequestFirstDenominator();
                    isInputCorrect = int.TryParse(Console.ReadLine(), out firstDenominator);

                } while (!isInputCorrect);
            }

            #endregion Первый знаменатель

            #endregion Обработка первой дроби

            #region Обработка второй дроби

            #region Обработка целого числа

            UI.RequestSecondWhole();

            string secondWholestr = Console.ReadLine();

            int secondWhole = 0;

            if (!(secondWholestr == string.Empty))
            {
                isInputCorrect = int.TryParse(secondWholestr, out secondWhole);

                if (!isInputCorrect)
                {
                    do
                    {
                        UI.PrintErrorInput();
                        UI.RequestFirstWhole();
                        isInputCorrect = int.TryParse(Console.ReadLine(), out secondWhole);

                    } while (!isInputCorrect);

                }
            }

            #endregion Обработка целого числа

            #region Второй числитель

            UI.RequestSecondNumerator();

            isInputCorrect = int.TryParse(Console.ReadLine(), out int secondNumerator);

            if (!isInputCorrect)
            {
                do
                {
                    UI.PrintErrorInput();
                    UI.RequestSecondNumerator();
                    isInputCorrect = int.TryParse(Console.ReadLine(), out secondNumerator);

                } while (!isInputCorrect);
            }

            #endregion Второй числитель

            #region Второй знаменатель
                       
            UI.RequestSecondDenominator();

            isInputCorrect = int.TryParse(Console.ReadLine(), out int secondDenominator);

            if (!isInputCorrect)
            {
                do
                {
                    UI.PrintErrorInput();
                    UI.RequestSecondDenominator();
                    isInputCorrect = int.TryParse(Console.ReadLine(), out secondDenominator);

                } while (!isInputCorrect);
            }

            #endregion Второй знаменатель

            #endregion Обработка второй дроби

            Fractions firstFraction = new Fractions(firstNumerator
                , firstDenominator, firstWhole);

            Fractions secondFraction = new Fractions(secondNumerator
                , secondDenominator, secondWhole);

            #region СУММА

            Console.Write("\nОперация ");
            UI.ChangeColor(ConsoleColor.Green,"СУММИРОВАНИЯ");
            Console.WriteLine("\n");

            Fractions resultSum = firstFraction + secondFraction;

            int leftPos = Console.CursorLeft;
            int topPos = Console.CursorTop;
            
            const ushort STEP_LEFT = 5;            

            UI.PrintFraction(firstFraction, leftPos, topPos);

            UI.PrintOperatorSymbol('+', leftPos + STEP_LEFT, topPos + 1);

            UI.PrintFraction(secondFraction, leftPos + STEP_LEFT + 2, topPos);

            UI.PrintOperatorSymbol('=', leftPos + (STEP_LEFT * 2) + 1
                , topPos + 1); 

            UI.PrintFraction(resultSum, leftPos + STEP_LEFT * 2 + 4, topPos);

            #endregion СУММА

            #region ВЫЧИТАНИЕ

            Fractions resultSubtraction = firstFraction - secondFraction;

            leftPos = 0;
            
            const ushort TOP_STEP = 15;

            topPos = TOP_STEP;

            Console.Write("\nОперация ");
            UI.ChangeColor(ConsoleColor.Green, "ВЫЧИТАНИЯ");
            Console.WriteLine("\n");

            UI.PrintFraction(firstFraction, leftPos, topPos);

            UI.PrintOperatorSymbol('-', leftPos + STEP_LEFT, topPos + 1);

            UI.PrintFraction(secondFraction, leftPos + STEP_LEFT + 2, topPos);

            UI.PrintOperatorSymbol('=', leftPos + (STEP_LEFT * 2) + 1
                , topPos + 1);

            UI.PrintFraction(resultSubtraction, leftPos + STEP_LEFT * 2 + 4
                , topPos);

            #endregion ВЫЧИТАНИЕ

            #region ДЕЛЕНИЕ

            Fractions resultDevide = firstFraction / secondFraction;

            leftPos = 0;

            Console.Write("\nОперация ");
            UI.ChangeColor(ConsoleColor.Green, "ДЕЛЕНИЯ");
            Console.WriteLine("\n");

            topPos = Console.CursorTop;

            UI.PrintFraction(firstFraction, leftPos, topPos);

            UI.PrintOperatorSymbol('-', leftPos + STEP_LEFT, topPos + 1);

            UI.PrintFraction(secondFraction, leftPos + STEP_LEFT + 2
                , topPos);

            UI.PrintOperatorSymbol('=', leftPos + (STEP_LEFT * 2) + 1
                , topPos + 1);

            UI.PrintFraction(resultDevide, leftPos + STEP_LEFT * 2 + 4
                , topPos);

            #endregion ДЕЛЕНИЕ

            #region УМНОЖЕНИЕ

            Fractions resultMultiplication = firstFraction * secondFraction;

            leftPos = 0;

            Console.Write("\nОперация ");

            UI.ChangeColor(ConsoleColor.Green, "УМНОЖЕНИЯ");

            Console.WriteLine("\n");

            topPos = Console.CursorTop;

            UI.PrintFraction(firstFraction, leftPos, topPos);

            UI.PrintOperatorSymbol('-', leftPos + STEP_LEFT, topPos + 1);

            UI.PrintFraction(secondFraction, leftPos + STEP_LEFT + 2, topPos);

            UI.PrintOperatorSymbol('=', leftPos + (STEP_LEFT * 2) + 1
                , topPos + 1);

            UI.PrintFraction(resultMultiplication, leftPos + STEP_LEFT * 2 + 4
                , topPos);

            #endregion УМНОЖЕНИЕ

            #region СРАВНЕНИЕ

            bool compare = firstFraction < secondFraction;

            leftPos = 0;

            Console.Write("\nОперация ");

            UI.ChangeColor(ConsoleColor.Green, "СРАВНЕНИЯ");

            Console.WriteLine("\n");

            topPos = Console.CursorTop;

            UI.PrintFraction(firstFraction, leftPos, topPos);

            UI.PrintCompareResult(compare, leftPos + STEP_LEFT - 2 , topPos + 1);

            UI.PrintFraction(secondFraction, leftPos + STEP_LEFT + 2, topPos);


            compare = firstFraction > secondFraction;

            leftPos = 0;

            Console.Write("\nОперация ");

            UI.ChangeColor(ConsoleColor.Green, "СРАВНЕНИЯ");

            Console.WriteLine("\n");

            topPos = Console.CursorTop;

            UI.PrintFraction(firstFraction, leftPos, topPos);

            UI.PrintCompareResult(compare, leftPos + STEP_LEFT - 2, topPos + 1);

            UI.PrintFraction(secondFraction, leftPos + STEP_LEFT + 2, topPos);

            #endregion СПАВНЕНИЕ

            Console.ReadKey();

        }
    }
}
