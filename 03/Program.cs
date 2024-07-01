string[] lines = await File.ReadAllLinesAsync("input.txt");

int res = 0;

foreach (string line in lines)
{ 
    if (line.Length < 4 || line.Length > 12)
    { 
        continue; 
    }

    bool hasUpper = false, hasLower = false, hasNonStandard = false, hasDigit = false;
    foreach (char ch in line)
    {
        if (char.IsDigit(ch))
        { 
            hasDigit = true;
        }
        if (char.IsUpper(ch))
        { 
            hasUpper = true;
        }
        if (char.IsLower(ch)) 
        {
            hasLower = true;
        }
        if (!char.IsAscii(ch))
        { 
            hasNonStandard = true;
        }
    }

    if (hasUpper && hasLower && hasNonStandard && hasDigit)
    {
        res++;
    }
}

Console.WriteLine(res);