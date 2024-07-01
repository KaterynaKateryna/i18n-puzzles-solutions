string[] lines = await File.ReadAllLinesAsync("input.txt");

long res = 0;
for(int i  = 0; i < lines.Length; i++)
{
    string[] parts = lines[i].Split(new string[] { "\t", " " }, StringSplitOptions.RemoveEmptyEntries);
    DateTimeOffset date = DateTimeOffset.Parse(parts[0]);

    DateTimeOffset one = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
        date, "America/Halifax");
    DateTimeOffset two = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
        date, "America/Santiago");

    string tz = "America/Santiago";
    if (one.Offset == date.Offset)
    {
        tz = "America/Halifax";
    }

    date = date.AddMinutes(-int.Parse(parts[2]));
    date = date.AddMinutes(int.Parse(parts[1]));

    DateTimeOffset fix = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
        date, tz);

    res += fix.Hour * (i + 1);
}

Console.WriteLine(res);