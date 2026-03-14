using System;

public class Calculator
{
    public static void Run(string[] args)
    {
        string variable1 = "";
        string variable2 = "";
        string operation = "";

        try
        {
            List<double> resultNumber = Variables(variable1, variable2, operation);

            double variable1Number = resultNumber[0];
            double variable2Number = resultNumber[resultNumber.Count - 1];

            (double resultOperation, string? usedOperation) = OperationsHandling(variable1Number, variable2Number, operation);
            Console.WriteLine($"{variable1Number:0.0##} {usedOperation} {variable2Number:0.0##} = {resultOperation}");
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static List<double> Variables(string? variable1, string? variable2, string? operation)
    {
        bool isNumber = false;
        List<double> list = new List<double>();

        variable1 = Console.ReadLine();
        isNumber = double.TryParse(variable1, out double variable1Number);
        if (isNumber != true)
        {
            throw new InvalidDataException("Invalid data type for setting first number");
        }

        list.Add(variable1Number);

        variable2 = Console.ReadLine();
        isNumber = double.TryParse(variable2, out double variable2Number);
        if (isNumber != true)
        {
            throw new InvalidDataException("Invalid data type for setting second number");
        }

        else if (variable2Number == 0 && operation == "/")
        {
            throw new DivideByZeroException("Attempted to divide by zero");
        }

        list.Add(variable2Number);

        return list;
    }

    public static (double resultOperation, string? usedOperation) OperationsHandling(double variable1Number, double variable2Number, string? operation)
    {
        double result = 0.0;

        operation = Console.ReadLine();

        switch (operation)
        {
            case "+":
                result = variable1Number + variable2Number;
                break;

            case "-":
                result = variable1Number - variable2Number;
                break;

            case "*":
                result = variable1Number * variable2Number;
                break;

            case "/":
                result = variable1Number / variable2Number;
                break;
        }
        return (result, operation);
    }
}