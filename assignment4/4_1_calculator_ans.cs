using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter an expression (ex. 2 + 3): ");
            string input = Console.ReadLine();

            try
            {
                Parser parser = new Parser();
                (double num1, string op, double num2) = parser.Parse(input);

                Calculator calculator = new Calculator();
                double result = calculator.Calculate(num1, op, num2);

                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }

    // Parser class to parse the input
    public class Parser
    {
        public (double, string, double) Parse(string input)
        {
            string[] parts = input.Split(' ');

            if (parts.Length != 3)
            {
                throw new FormatException("Input must be in the format: number operator number");
            }

            double num1 = Convert.ToDouble(parts[0]);
            string op = parts[1];
            double num2 = Convert.ToDouble(parts[2]);

            return (num1, op, num2);
        }
    }

    // Calculator class to perform operations
    public class Calculator
    {
        // ---------- TODO ----------

        public double Calculate(double num1, string op, double num2)
        {
            switch (op)
            {
                case "+": return num1 + num2;
                case "-": return num1 - num2;
                case "*": return num1 * num2;
                case "/": return num2 != 0.0 ? num1 / num2 : throw new DivideByZeroException("Division by zero is not allowed");
                default: throw new InvalidOperationException("Invalid operator");

                // CHALLENGE
                case "**":
                    {   // Iterative exponentiation by squaring (w/ bit manipulation)
                        // or just return Math.Pow(num1, (int)num2);
                        double result = 1.0;

                        // Invert base if exponent is negative
                        int exponent = (int)num2;
                        if (exponent < 0)
                        {
                            num1 = 1.0 / num1;
                            exponent = -exponent;
                        }

                        // Loop through each bit of exponent
                        while (exponent > 0)
                        {
                            // Multiply result by base if its rightmost bit is set
                            if ((exponent & 1) == 1) result *= num1;

                            // Square base and right shift exponent
                            num1 *= num1;
                            exponent >>= 1;
                        }

                        return result;
                    }

                case "%":
                    {   // w/o using modulus operator
                        // or just return (int)num1 % (int)num2;

                        // Make divisor positive if it is negative
                        int divisor = (int)num2;
                        if (divisor == 0) throw new DivideByZeroException("Division by zero is not allowed");
                        if (divisor < 0) divisor = -divisor;

                        // Perform additions if dividend is negative, subtractions if positive
                        int dividend = (int)num1;
                        if (dividend < 0) while (dividend <= -divisor) dividend += divisor;
                        else while (dividend >= divisor) dividend -= divisor;

                        return (double)dividend;
                    }

                case "G":
                    {   // Euclidean algorithm
                        int a = (int)num1;
                        if (a < 0) a = -a;

                        int b = (int)num2;
                        if (b < 0) b = -b;

                        return GCD(a, b);
                    }

                case "L":
                    {   // Euclidean algorithm
                        int a = (int)num1;
                        if (a < 0) a = -a;

                        int b = (int)num2;
                        if (b < 0) b = -b;

                        // Special case, LCM(0,0) = 0
                        if (a == 0 && b == 0) return 0.0;
                        else return (double)((a / GCD(a, b)) * b);
                    }
            }
        }

        static private int GCD(int a, int b)
        {   // Euclidean algorithm
            while (a != 0 && b != 0)
            {
                if (a > b) a %= b;
                else b %= a;
            }

            return a | b;
        }

        // --------------------
    }
}

/* example output

Enter an expression (ex. 2 + 3):
>> 4 * 3
Result: 12

*/


/* example output (CHALLANGE)

Enter an expression (ex. 2 + 3):
>> 4 ** 3
Result: 64

Enter an expression (ex. 2 + 3):
>> 5 ** -2
Result: 0.04

Enter an expression (ex. 2 + 3):
>> 12 G 15
Result: 3

Enter an expression (ex. 2 + 3):
>> 12 L 15
Result: 60

Enter an expression (ex. 2 + 3):
>> 12 % 5
Result: 2

*/