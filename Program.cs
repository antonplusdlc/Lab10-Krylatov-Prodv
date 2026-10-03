using System.Globalization;
using System.Text;

CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

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

string result = "";

for (int i = 1; i <= 5; i++)
{
    result += i + " ";
}

Console.WriteLine(result);   // 1 2 3 4 5

StringBuilder sb = new();

for (int i = 1; i <= 5; i++)
{
    sb.Append(i + " ");
}

Console.WriteLine(sb.ToString());

// при += создается новая строка в которую копируется старое содержимое и добавляется новое значение так как строки неизменяемы.
// StringBuilder предназначен для многократного изменения собираемой строки поэтому например метод Append добавляет данныем в его внутренний буфер не создавая новую строку на каждой итерации.

string[] students = ["Иван", "Анна", "Пётр"];

StringBuilder rep = new();

rep.AppendLine("=== ОТЧЁТ ===")
.Append("Группа: ")
.AppendLine("ИСП-253")
.Append("Студентов: ")
.AppendLine(students.Length.ToString());

for (int i = 0; i < students.Length; i++)
{
    rep.Append(i + 1)
    .Append(". ")
    .AppendLine(students[i]);
}

Console.WriteLine(rep.ToString());

string[] products = ["Хлеб", "Молоко", "Ноутбук"];
double[] prices = [45, 89.5, 65999.99];

Console.WriteLine($"{"№", -3} {"Товар", -15} {"Цена", 10}");
Console.WriteLine(new string('-', 30));

for (int i = 0; i < products.Length; i++)
{
    Console.WriteLine($"{i + 1:D2}  {products[i], -15} {prices[i], 10:N2}");
}

Console.WriteLine($"{0.256:P0}");
Console.WriteLine($"{255:X}");