public class MyExport
{
    public uint UserId = 42;

    public uint GetCurrentUserId()
    {
        Console.WriteLine("GetCurrentUserId");
        return UserId;
    }
    public void Start()
    {
        Console.WriteLine("Start");
        UserId++;
    }
    public void Stop()
    {
        Console.WriteLine("Stopped");
    }
}