
using System.Text;

string[] lines = await File.ReadAllLinesAsync("input.txt");

List<string> dictionary = new List<string>();
List<string> crossword = new List<string>();

int j = 0;
for (int i = 0; i < lines.Length; i++)
{
    if (lines[i] == string.Empty)
    {
        j = i + 1;
        break;
    }

    string word = lines[i];

    if ((i+1) % 5 == 0)
    {
        byte[] bytes = Encoding.Latin1.GetBytes(word);
        word = Encoding.UTF8.GetString(bytes);
    }
    if ((i+1) % 3 == 0)
    {
        byte[] bytes = Encoding.Latin1.GetBytes(word);
        word = Encoding.UTF8.GetString(bytes);
    }

    dictionary.Add(word);
}

for (int i = j; i < lines.Length; ++i)
{
    crossword.Add(lines[i].Trim());
}

int res = 0;
foreach (string word in crossword)
{
    int ind = -1;
    for (int i = 0; i < word.Length; ++i)
    {
        if (word[i] != '.')
        { 
            ind = i; 
            break;
        }
    }

    for (int i = 0; i < dictionary.Count; ++i)
    {
        if (dictionary[i].Length == word.Length && dictionary[i][ind] == word[ind])
        {
            res += (i + 1);
            break;
        }
    }
}

Console.WriteLine(res);