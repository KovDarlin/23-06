class Program
{
    static async Task Main()
    {
        var check = new[] { "№1", "№2", "№3" };
        var task = check.Select(Process).ToList();
        await Task.WhenAll(task);
    }

    static async Task Process(string num_task)
    {
        PRINT($"Take order: #{num_task}");
        await Task.Delay(1000);
        PRINT($"Order #{num_task} processing...");
        var rand = new Random();
        int delay = rand.Next(2000, 5001); 
        await Task.Delay(delay);
        PRINT($"Ready: #{num_task}");
    }
    static void PRINT(string message)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
    }
}