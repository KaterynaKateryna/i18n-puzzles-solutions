string[] lines = await File.ReadAllLinesAsync("input.txt");

Dictionary<string, List<int[]>> people = new Dictionary<string, List<int[]>>();
foreach (var line in lines)
{
    string[] parts = line.Split(":");
    string date = parts[0];
    int[] dateParts = date.Split('-').Select(int.Parse).ToArray();

    string[] names = parts[1].Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
    foreach (string name in names)
    {
        if (people.ContainsKey(name))
        {
            people[name].Add(dateParts);
        }
        else
        {
            people[name] = new List<int[]>() { dateParts };
        }
    }
}

List<string> result = new List<string>();
foreach (var kv in people)
{
    if (kv.Value.All(i => { try { new DateTime(i[0] == 0 ? 2000 : i[0], i[1], i[2]); return true; } catch { return false; } })
        && kv.Value.Any(i => i[0] == 1 && i[1] == 9 && i[2] == 11))
    {
        result.Add(kv.Key);
    }
    if (kv.Value.All(i => { try { new DateTime(i[0] == 0 ? 2000 : i[0], i[2], i[1]); return true; } catch { return false; } })
        && kv.Value.Any(i => i[0] == 1 && i[2] == 9 && i[1] == 11))
    {
        result.Add(kv.Key);
    }
    if (kv.Value.All(i => { try { new DateTime(i[2] == 0 ? 2000 : i[2], i[1], i[0]); return true; } catch { return false; } })
        && kv.Value.Any(i => i[2] == 1 && i[1] == 9 && i[0] == 11))
    {
        result.Add(kv.Key);
    }
    if (kv.Value.All(i => { try { new DateTime(i[2] == 0 ? 2000 : i[2], i[0], i[1]); return true; } catch { return false; } })
        && kv.Value.Any(i => i[2] == 1 && i[0] == 9 && i[1] == 11))
    {
        result.Add(kv.Key);
    }
}

result.Sort();
string answer = string.Join(" ", result);
Console.WriteLine(answer);