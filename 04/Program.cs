string[] lines = await File.ReadAllLinesAsync("input.txt");

long sum = 0;
for (int i = 0; i < lines.Length; i++)
{
    if (lines[i].StartsWith("Departure"))
    {
        DateTime departure = GetDateTimeUtc(lines[i]);
        DateTime arrival = GetDateTimeUtc(lines[i+1]);

        TimeSpan res = arrival - departure;
        long min = (long)res.TotalMinutes;
        sum += min;
    }
}

Console.WriteLine(sum);

DateTime GetDateTimeUtc(string line)
{
    string timeZone = line.Substring(11, 31).Trim();
    string dateTime = line.Substring(42).Trim();

    DateTime res = TimeZoneInfo.ConvertTimeToUtc(
        DateTime.Parse(dateTime),
        TimeZoneInfo.FindSystemTimeZoneById(timeZone)
    );

    return res;
}