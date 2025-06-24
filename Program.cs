class Program
{
    static async Task Main()
    {
        var paths = new[] { "file1.txt", "file2.txt" };
        var readTask = paths.Select(async path =>
        {
            try
            {
                string text = await File.ReadAllTextAsync(path);
                int count = Counting(text);
                Console.WriteLine($"[{path}] - {count} words");
                return count;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"{path} - {ex.Message}");
                return 0;
            }
        }).ToList();

        int[] res = await Task.WhenAll(readTask);
        int sum = res.Sum();
        Console.WriteLine($"Total words - {sum}");
    }

    static int Counting(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return 0;
        var word = text.Split(new[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return word.Length;
    }
}