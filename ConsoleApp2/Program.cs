using System;

namespace SimpleCalculator
{
    internal static class Program
    {
        private enum Operation
        {
            Unknown,

            Addition,

            Subtraction,

            Multiplication,

            Division,

        };

        private static void Main()

        {
            char repeat = 'д';
            while (repeat == 'д')

            {
                // Запрос ввода пользователем первого числа
                string stringFirstNumber;
                double firstNumber;

                do
                {
                    Console.WriteLine("Введите первое число:");
                    stringFirstNumber = Console.ReadLine();
                } while (!double.TryParse(stringFirstNumber, out firstNumber));

                // Запрос ввода пользователем второго числа
                string stringSecondNumber;
                double secondNumber;

                do
                {
                    Console.WriteLine("Введите второе число:");
                    stringSecondNumber = Console.ReadLine();
                } while (!double.TryParse(stringSecondNumber, out secondNumber));

                string stringOperation;
                Operation operation;

                do
                {
                    // Запрос выбора пользователем операции
                    Console.WriteLine("Выберите и введите знак операции: +, -, *, /:");
                    stringOperation = Console.ReadLine();

                    // Используется для выбора операции
                    operation = ConvertStringChoiceToEnum(stringOperation);
                } while (operation == Operation.Unknown);

                // Результат операции
                var result = DoSomethingByOperation(operation, firstNumber, secondNumber);

                Console.WriteLine();
                Console.WriteLine("Результат {0} {1} {2} = {3}", firstNumber, stringOperation, secondNumber, result);
                Console.ReadKey();

                Console.WriteLine("Вы хотите продолжить работу с калькулятором? (д/н)");
                repeat = Convert.ToChar(Console.ReadLine());
            }
        }

        private static Operation ConvertStringChoiceToEnum(string stringOperation)
        {
            // Конвертация строки выбора операции в enum
            switch (stringOperation)
            {
                case "+":
                case "addition":
                    return Operation.Addition;
                case "-":
                case "subtraction":
                    return Operation.Subtraction;
                case "*":
                case "multiplication":
                    return Operation.Multiplication;
                case "/":
                case "division":
                    return Operation.Division;
                default:
                    return Operation.Unknown;
            }
        }

        private static double DoSomethingByOperation(Operation operation, double firstNumber, double secondNumber)
        {
            // Выполнение операции в зависисмости от выбора
            switch (operation)
            {
                case Operation.Addition:
                    return firstNumber + secondNumber;

                case Operation.Subtraction:
                    return firstNumber - secondNumber;

                case Operation.Multiplication:
                    return firstNumber * secondNumber;

                case Operation.Division:
                    return firstNumber / secondNumber;

                case Operation.Unknown:
                    return double.NaN;

                default:
                    return double.NaN;
            }
        }
    }
}