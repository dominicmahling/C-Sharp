public static class PasswordChecker
{
    public static void CheckPassword()
    {
        Console.WriteLine("Enter a Password");
        var eingabe = Console.ReadLine();
        int score = 0;
        var checks = new List<Func<string, bool>>
        {
            p => p.Length >= 8,
            p => p.Any(char.IsUpper),
            p => p.Any(char.IsDigit),
            p => p.Any(ch => !char.IsLetterOrDigit(ch)),
        };
        score = checks.Count(check => check(eingabe));
        Console.WriteLine($"Score on a Scale fomr 0-4 ist {score}");
    }
}