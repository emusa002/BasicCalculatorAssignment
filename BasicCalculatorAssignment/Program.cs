namespace BasicCalculatorAssignment
{
    internal class Program
    {
        // The goal of this assignment is to learn how to create and use methods in our code
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Simple Calculator");
                Console.WriteLine("-----------------");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an operation: ");

                // Task 1. Read choice input and assing it to new int variable
                int choiceInput = gatherInput<int>("");

                if (choiceInput < 1 || choiceInput > 5)
                {
                    Console.WriteLine("Invalid Choice input. Please select a valid option");
                    continue;
                }

                // Task 2. Check if user selected choice 5. If so then exit the loop
                if (choiceInput == 5)
                {
                    break;
                }

                Console.Write("Enter first number: ");
                // Task 3. Get the first number and assing it to new double variable
                double firstInput = gatherInput<double>("");

                Console.Write("Enter second number: ");
                // Task 4. Get the second number and assing it to new double variable
                double secondInput = gatherInput<double>("");

                // Task 5. Create double variable for default result value and assign it to be 0
                double result = 0;

                // Task 6. Handle choices using switch statement
                // Task 6.1 For each case create new function/method an call it inside the case
                //          - Case 1: Add 
                //          - Case 2: Subtract
                //          - Case 3: Multiply
                //          - Case 4: Divide, Note remeber to handle 0
                // Note: Think what the default choice should be
                // Note: Declare each case function/method outside Main method
                //       There is comment below where you can place your methods

                switch (choiceInput)
                {
                    case 1:
                        result = add(firstInput, secondInput);
                        break;
                     case 2:
                        result = subtract(firstInput, secondInput); 
                        break;
                    case 3:
                        result = multiply(firstInput, secondInput);
                        break;
                    case 4:
                        try
                        {
                            result = divide(firstInput, secondInput);
                        } catch (DivideByZeroException e)
                        {
                            Console.WriteLine("Invalid Second input. Cannot Divide by Zero. Please try again.");
                            continue;
                        }
                        break;
                    default:
                        result = add(firstInput, secondInput);
                        break;
                }

                // Task 7. Print out the result
                Console.WriteLine("Result is: {0}", Convert.ToString(result));
            }
        }

        // Declare your methods/functions here

        static double add(double x, double y)
        {
            return x + y;
        }

        static double subtract(double x, double y)
        {
            return x - y;
        }

        static double multiply(double x, double y)
        {
            return x * y;
        }
 
        static double divide(double x, double y)
        {
            if (y == 0)
            {
                throw new DivideByZeroException();
            }

                return x / y;

        }

            static T gatherInput<T>(string prompt, bool allowNull = false)
            {
                Console.WriteLine(prompt);
                string? _ = Console.ReadLine();
                dynamic result;

                if (_ == null && allowNull == false)
                {
                    Console.WriteLine("Invalid Value");
                    return gatherInput<T>(prompt, allowNull);
                }

                try
                {
                    result = Convert.ChangeType(_, typeof(T));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid Value");
                    return gatherInput<T>(prompt, allowNull);
                }


                return result;
            }


        }
}