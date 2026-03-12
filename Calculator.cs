using System;

public class Calculator
{
    public static void Run(string[] args)
    {
        string var1 = "";
        string var2 = "";
        string operation = "";
        int var1Int;
        int var2Int;

        try
        {
            List<int> resultInt = Vars(var1, var2);

            var1Int = resultInt[0];
            var2Int = resultInt[resultInt.Count - 1];

            int resultOperation = Operations(var1Int, var2Int, operation);
            Console.WriteLine(resultOperation);
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static List<int> Vars(string? var1, string? var2)
    {
        bool isInt = false;
        List<int> list = new List<int>();

        var1 = Console.ReadLine();
        isInt = int.TryParse(var1, out int var1Int);
        if (isInt != true)
        {
            throw new InvalidDataException("InvalidDataException: Invalid data type for setting first integer");
        }

        list.Add(var1Int);

        var2 = Console.ReadLine();
        isInt = int.TryParse(var2, out int var2Int);
        if (isInt != true)
        {
            throw new InvalidDataException("InvalidDataException: Invalid data type for setting second integer");
        }

        // stopped here, pick back up
        else if (var2Int == 0 && operation == "/")
        {
            throw new DivideByZeroException("DivideByZeroException:  Attempted to divide by zero.");
        }

        list.Add(var2Int);

        return list;

    }
    public static int Operations(int var1Int, int var2Int, string? operation)
    {
        int result = 0;

        operation = Console.ReadLine();

        switch (operation)
        {
            case "+":
                result = var1Int + var2Int;
                break;

            case "-":
                result = var1Int - var2Int;
                break;

            case "*":
                result = var1Int * var2Int;
                break;

            case "/":
                result = var1Int / var2Int;
                break;
        }

        return result;
    }
}