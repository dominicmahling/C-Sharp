
using System.Runtime.CompilerServices;

Console.WriteLine("Enter Text");
Random rnd = new Random();

bool correctAnswer = true;
while (giveQuestion())
{
    
}
string textInput = Console.ReadLine();
Console.WriteLine(textInput);
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
    int firstNumber = rnd.Next(1,1000);
    int secondNumber = rnd.Next(1,1000);
    Console.WriteLine($"{firstNumber} + {secondNumber}");
    string input = Console.ReadLine();
    if (firstNumber + secondNumber ==  Int32.Parse(input)){
        Console.WriteLine("Right!");
        return true;
    }
    else{
        Console.WriteLine($" Wrong! {firstNumber} + {secondNumber} = {firstNumber+secondNumber}");
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