using System.Globalization;
using System.Text;

string[] lines = await File.ReadAllLinesAsync("input.txt");

int res = 0;

foreach (string line in lines)
{
    if (line.Length < 4 || line.Length > 12)
    {
        continue;
    }

    string normalized = RemoveDiacritics(line).ToLower();

    bool hasDigit = false, hasVowel = false, hasConsonant = false;
    for(int i = 0; i < normalized.Length; ++i)
    {
        char ch = normalized[i];
        if (char.IsDigit(ch))
        {
            hasDigit = true;
        }

        if ("aeiou".Contains(ch))
        {
            hasVowel = true;
        }

        if (char.IsLetter(ch) && !"aeiou".Contains(ch))
        { 
            hasConsonant = true; 
        }
    }

    bool recurring = normalized.GroupBy(x => x).Any(x => x.Count() > 1);

    if (hasDigit && hasVowel && hasConsonant && !recurring)
    {
        res++;
    }
}

Console.WriteLine(res);

static string RemoveDiacritics(string text)
{
    string formD = text.Normalize(NormalizationForm.FormD);
    StringBuilder sb = new StringBuilder();

    foreach (char ch in formD)
    {
        UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(ch);
        if (uc != UnicodeCategory.NonSpacingMark)
        {
            sb.Append(ch);
        }
    }

    return sb.ToString().Normalize(NormalizationForm.FormC);
}