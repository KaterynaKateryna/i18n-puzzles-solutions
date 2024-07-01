using System.Text;

string[] lines = await File.ReadAllLinesAsync("input.txt");

int width = 0;
foreach (char ch in lines[0])
{
    if (char.IsLowSurrogate(ch))
    {
        continue;
    }
    width++;
}

int height = lines.Length;

int x = 0;

int count = 0;
for (int y = 0; y < height; y++)
{
    char[] chars = lines[y].ToCharArray();
    int offset = x;
    for (int i = 0; i < offset; ++i)
    {
        if (char.IsHighSurrogate(chars[i]))
        {
            offset++;
        }
    }
    if (char.IsHighSurrogate(chars[offset]) && $"{chars[offset]}{chars[offset + 1]}" == "💩")
    {
        count++;
    }

    x += 2;
    x %= width;
}

Console.WriteLine(count);