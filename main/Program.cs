// See https://aka.ms/new-console-template for more information

Console.WriteLine("Enter Text");
string input = Console.ReadLine();
Console.WriteLine(input);
var userid = 0;
var Bog = new Bogus.Faker<User>()
    .RuleFor( u => u.Id, f => userid++)
    .RuleFor(u => u.Name, f => Guid.NewGuid().ToString());

List<User> users = Bog.Generate(20);
foreach (User user in users)
{
    Console.WriteLine($"{user.Id}\t{user.Name}");
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