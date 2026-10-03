string text = "  Строки в C# неизменяемы  ";
string clean = text.Trim();

Console.WriteLine(text.Length);
Console.WriteLine(clean);
Console.WriteLine(clean.Length);
Console.WriteLine($"{clean[0]} {clean[clean.Length - 1]}");
Console.WriteLine(clean.ToUpper());

Console.WriteLine(clean.Contains("C#"));
Console.WriteLine(clean.Contains("c#"));
Console.WriteLine(clean.IndexOf("C#"));
string da = clean.Replace("неизменяемы", "удобны");
Console.WriteLine(da);

clean.ToUpper();

Console.WriteLine(clean);

// не изменилась. потому-что ToUpper как и другие подобные методы возвращают новую строку а не заменяют текущую.

string date = "15.09.2025";

Console.WriteLine($"den {date.Substring(0, 2)}, mesac {date.Substring(3, 2)}, god {date.Substring(6, 4)}");

string line = "Иванов,25,Программист";

string[] linem = line.Split(',');

Console.WriteLine(linem.Length);

for (int i = 0; i < linem.Length; i++)
{
    Console.WriteLine($"i {i}    {linem[i]}");
}

Console.WriteLine($"{linem[0]}, {linem[1]} years old, {linem[2]}");

string sentence = "  Сегодня   хорошая   погода  ";

string[] probel = sentence.Split(' ');
Console.WriteLine(probel.Length); // 11. пробелы прост
string[] norm = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
Console.WriteLine(norm.Length);

foreach (string daa in norm)
{
    Console.WriteLine(daa);
}

// потому что Split возвращает массив. в ПР9 мы точно массивы не изучали ну вот 1000%

string? str;

do
{
    Console.Write("enter string: ");
    str = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(str)) Console.WriteLine("empty string!");
} while (string.IsNullOrWhiteSpace(str));

string trimStr = str.Trim();

Console.WriteLine($"Содержит слово «код»: {(trimStr.ToLower().Contains("код") ? "да" : "нет")}");
Console.WriteLine($"Начинается с 'Привет': {(trimStr.ToLower().Contains("привет") ? "да" : "нет")}");