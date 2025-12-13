using System.Runtime.CompilerServices;

Console.WriteLine("Enter Text");
Random rnd = new Random();

RunGuesser();
RunQuiz(5);
bool GiveQuestion(int rightAnswers)
{
    var question = Question.Generate(true);

    Console.WriteLine(question.ToString());

    int number;
    while (!int.TryParse(Console.ReadLine(), out number))
    {
        Console.WriteLine("Input is not a valid number");
    }

    if (question.IsValid(number))
    {
        Console.WriteLine($"Right! You have answered {rightAnswers + 1} correct so far!");
        return true;
    }
    else
    {
        Console.WriteLine($" Wrong! Solution is {question.Result}");
        return false;
    }
}

void RunQuiz(int maxHP)
{
    int currentHP = maxHP;
    int rightAnswers = 0;
    while (currentHP != 0)
    {
        while (GiveQuestion(rightAnswers)) { rightAnswers++; }
        currentHP--;
        Console.WriteLine("Wrong! Lifes remaining: " + new String('o', currentHP) + new String('-', maxHP - currentHP));
    }

    Console.WriteLine($"Game over, Total Score: {rightAnswers}");
}

void RunGuesser()
{
    NumberGuesser numberClass = new NumberGuesser();
    numberClass.PrintIntervall();
    int numberGuessed = -1;
    while (!numberClass.IsNumber(numberGuessed))
    {
        while (!int.TryParse(Console.ReadLine(), out numberGuessed))
        {
            Console.WriteLine("Input is not a valid number");
        }

        Console.WriteLine($" The right number is {numberClass.Relation(numberGuessed)}");
    }
}

var userid = 0;
var Bog = new Bogus.Faker<User>()
    .RuleFor(u => u.Id, f => userid++)
    .RuleFor(u => u.Name, f => Guid.NewGuid().ToString());

List<User> users = Bog.Generate(20);
foreach (User user in users)
{
    Console.WriteLine($"{user.Id}\t{user.Name}");
}

internal class Question
{
    private const int ValueMin = 1;
    private const int ValueMax = 1000;
    private static readonly Random Random = new ();
    private readonly int _value1;
    private readonly int _value2;
    private readonly char _sign;

    public int Result { get; }

    private Question(int value1, int value2, char sign, int result)
    {
        _value1 = value1;
        _value2 = value2;
        _sign = sign;
        this.Result = result;
    }

    public static Question Generate(bool isEasyMode)
    {
        var value1 = Random.Next(ValueMin, ValueMax);
        var value2 = Random.Next(ValueMin, ValueMax);
        var (sign, result) = Random.Next(1,4) switch
        {
            1 => ('+', value1 + value2),
            2 => ('-', value1 - value2),
            3 => ('*', value1 * value2),
            _ => throw new InvalidOperationException()
        };
        if (isEasyMode && sign == '*')
        {
            value1 = value1 / 10;
            value2 = value1 / 10;
            result = value1 * value2;
        }

        return new Question(value1, value2, sign, result);
    }

    public bool IsValid(int result) => this.Result == result;

    public override string ToString()
    {
        return $"{_value1} {_sign} {_value2}";
    }
}

internal class User()
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public User(string name)
        : this()
    {
        Name = name;
    }
}

internal class NumberGuesser{
    private readonly int _lowerBorder;
    private readonly int _higherBorder;
    private readonly int _number;

    private static readonly Random _random = new();

    public NumberGuesser()
    {
        int intervallBorder1 = _random.Next(0, 100);
        int intervallBorder2 = _random.Next(0, 100);
        _lowerBorder = Math.Min(intervallBorder1, intervallBorder2);
        _higherBorder = Math.Max(intervallBorder1, intervallBorder2);
        _number = _random.Next(_lowerBorder, _higherBorder);
    }

    public bool IsNumber(int numberGuessed)
    {
        return numberGuessed == _number;
    }

    public string Relation(int numberGuessed)
    {
        return IsNumber(numberGuessed) ? "same value!" : numberGuessed < _number ? "higher" : "lower";
    }

    public void PrintIntervall()
    {
        Console.WriteLine($"Number is between {_lowerBorder} and {_higherBorder} !");
    }

}