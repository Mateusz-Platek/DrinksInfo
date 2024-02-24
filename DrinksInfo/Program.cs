namespace DrinksInfo;

public static class Program
{
    public static async Task Main()
    {
        DatabaseHelper.CreateDatabase();
        DatabaseHelper.CreateTables();
        await Menu.Run();
    }
}