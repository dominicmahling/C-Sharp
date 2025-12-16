using System.Runtime.CompilerServices;
using System;

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
        Console.WriteLine("Wrong! Lifes remaining: " + new string('o', currentHP) + new string('-', maxHP - currentHP));
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