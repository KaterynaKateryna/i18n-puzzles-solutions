string[] lines = await File.ReadAllLinesAsync("input.txt");

var utcDates = new List<DateTime>();
foreach (var line in lines)
{ 
    DateTime date = DateTime.Parse(line);
    DateTime utc = date.ToUniversalTime();
    utcDates.Add(utc);
}

DateTime res = utcDates.GroupBy(x => x).FirstOrDefault(x => x.Count() >= 4).Key;
DateTimeOffset offset = new DateTimeOffset(res);
Console.WriteLine(offset.ToString("o"));