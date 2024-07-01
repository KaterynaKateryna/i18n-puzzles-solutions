using System.Text;

string[] lines = await File.ReadAllLinesAsync("input.txt");

long cost = 0;
foreach (var line in lines)
{
    int characters = line.Length;
    int bytes = UnicodeEncoding.UTF8.GetByteCount(line);

    if (bytes <= 160 && characters <= 140)
    {
        cost += 13;
    }
    else if (bytes <= 160)
    {
        cost += 11;
    }
    else if (characters <= 140)
    {
        cost += 7;
    }
}

Console.WriteLine(cost);
