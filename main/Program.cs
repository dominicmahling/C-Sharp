
using System.Runtime.CompilerServices;

Console.WriteLine("Enter Text");
Random rnd = new Random();

while (giveQuestion());
var userid = 0;
var Bog = new Bogus.Faker<User>()
    .RuleFor( u => u.Id, f => userid++)
    .RuleFor(u => u.Name, f => Guid.NewGuid().ToString());

List<User> users = Bog.Generate(20);
foreach (User user in users)
{
    Console.WriteLine($"{user.Id}\t{user.Name}");
}

bool giveQuestion()
{
    int operationValue = rnd.Next(1,4);
    int result;
    if (operationValue == 1)
    {
        int firstNumber = rnd.Next(1,1000);
        int secondNumber = rnd.Next(1,1000);
        Console.WriteLine($"{firstNumber} + {secondNumber}");
        result = firstNumber + secondNumber;
        
    }

    else if (operationValue == 2)
    {
        int firstNumber = rnd.Next(1,1000);
        int secondNumber = rnd.Next(1,1000);
        Console.WriteLine($"{firstNumber} - {secondNumber}");
        result = firstNumber - secondNumber;
        
    }
    else
    {
        int firstNumber = rnd.Next(1,100);
        int secondNumber = rnd.Next(1,10);
        Console.WriteLine($"{firstNumber} * {secondNumber}");
        result = firstNumber * secondNumber;
    }
    
    string input = Console.ReadLine();
    if (result ==  Int32.Parse(input)){
        Console.WriteLine("Right!");
        return true;
    }
    else{
        Console.WriteLine($" Wrong! Solution ist {result}");
        return false;
    }
     
}

class User()
{
    public int Id{get;set;}
    public string? Name{get;set;}

    public User(string name):this()
    {
        Name = name;
    }    
}