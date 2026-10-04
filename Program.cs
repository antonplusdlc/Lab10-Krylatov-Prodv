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

// Итоговая задача

bool TryParsePurchase(string input, out string name, out double price, out int cnt)
{
    name = "";
    price = 0;
    cnt = 0;

    string[] da = input.Split(',');

    if (da.Length != 3) return false;

    name = da[0].Trim();
    string priceTxt = da[1].Trim();
    string cntTxt = da[2].Trim();

    if (string.IsNullOrEmpty(name)) return false;

    if (!double.TryParse(priceTxt, out price)) return false;

    if (price < 0) return false;

    if (!int.TryParse(cntTxt, out cnt)) return false;

    if (cnt <= 0) return false;

    return true;
}

string BuildRep(string[] names, double[] prices, int[] cnts, int cnt, double total)
{
    StringBuilder rep = new();

    rep.AppendLine("========== ПОКУПКИ ==========")
    .AppendLine()
    .AppendLine($"{"Товар", -18} {"Кол-во", 7} {"Цена", 10} {"Сумма", 10}")
    .AppendLine(new string('-', 48));

    for (int i = 0; i < cnt; i++)
    {
        double sum = prices[i] * cnts[i];

        rep.AppendLine($"{names[i], -18} {cnts[i], 7} {prices[i], 10:N2} {sum, 10:N2}");
    }

    rep.AppendLine()
    .AppendLine($"{"ИТОГО:", -37} {total, 10:N2}");

    return rep.ToString();
}

Console.WriteLine();

Console.Write("Введите кол-во товаров: ");
int cnt;

while (!int.TryParse(Console.ReadLine(), out cnt) || cnt <= 0)
{
    Console.Write("ENTER INT > 0!!!");
}

string[] names = new string[cnt];
double[] pricess = new double[cnt];
int[] cnts = new int[cnt];

double tot = 0;

for (int i = 0; i < cnt; i++)
{
    while (true)
    {
        Console.Write($"Товар {i + 1}: ");
        string input = Console.ReadLine();

        if (TryParsePurchase(input, out string name, out double price, out int cntt))
        {
            names[i] = name;
            pricess[i] = price;
            cnts[i] = cntt;

            tot += price * cntt;

            break;
        }

        Console.WriteLine("ERROR! название,цена,количество!!!");
    }
}

string repp = BuildRep(names, pricess, cnts, cnt, tot);

Console.WriteLine();
Console.WriteLine(repp);

Console.WriteLine();

// Самостоятельные задания

// Телефон по шаблону

Console.Write("enter phone number (11 symbols): ");
string num = Console.ReadLine();

if (num.Length != 11) return; // мне лень простите

Console.WriteLine($"+7 ({num.Substring(1, 3)}) {num.Substring(4, 3)}-{num.Substring(7, 2)}-{num.Substring(9, 2)}");

// Слова предложения

Console.WriteLine();
Console.Write("Enter predloshenie: ");
string predl = Console.ReadLine();

string[] predlm = predl.Split(' ', StringSplitOptions.RemoveEmptyEntries);

Console.WriteLine($"кол-во слов: {predlm.Length}");

if (predlm.Length > 0)
{
    string longest = predlm[0];

    for (int i = 1; i < predlm.Length; i++)
    {
        if (predlm[i].Length > longest.Length) longest = predlm[i];
    }

    Console.WriteLine($"longest word: {longest}");

    Console.Write("enter bukvu: ");
    string da1 = Console.ReadLine();

    if (da1.Length > 0)
    {
        char let = da1[0];

        Console.WriteLine($"слова на букву {let}");

        bool f = false;

        for (int i = 0; i < predlm.Length; i++)
        {
            if (predlm[i].Length > 0 && char.ToLower(predlm[i][0]) == char.ToLower(let))
            {
                Console.WriteLine(predlm[i]);
                f = true;
            }
        }

        if (!f) Console.WriteLine("net slov takix");
    }
}
else Console.WriteLine("slov net.");

// Маскирование данных

string MaskData(string text)
{
    StringBuilder result = new();

    int dgs = 0;

    for (int i = 0; i < text.Length; i++)
    {
        if (char.IsDigit(text[i])) dgs++;
    }

    if (dgs <= 4) return text; // если кол-во цифр в строке <= 4, вернем просто исходную строку.

    int dgsNum = 0;

    for (int i = 0; i < text.Length; i++)
    {
        if (char.IsDigit(text[i]))
        {
            dgsNum++;

            if (dgsNum <= dgs - 4) result.Append('*');
            else result.Append(text[i]);
        }
        else result.Append(text[i]);
    }

    return result.ToString();
}

Console.WriteLine(MaskData("1234 5678 9012 3456"));