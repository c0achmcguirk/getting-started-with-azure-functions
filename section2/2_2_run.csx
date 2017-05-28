#load "library.csx"
#r "Newtonsoft.Json"

using System;

public static void Run(string input, TraceWriter log)
{
    log.Info($"C# manually triggered function called with input: {input}");

    var numbers = input.Split(',');

    var num1 = Int32.Parse(numbers[0]);
    var num2 = Int32.Parse(numbers[1]);

    var sum = MySum(num1, num2);

    log.Info($"The sum of {num1} and {num2} is {sum}");

    var Summary = new {
        Num1 = num1,
        Num2 = num2,
        Sum = sum
    }

    log.Info($"Summary: {Newtonsoft.Json.JsonConvert.SerializeObject(Summary)}");
}
