using Microsoft.EntityFrameworkCore;

public static class PupuseriaContextMemory<TContext> where TContext : DbContext
{
    public static TContext CreateDbContext(string dbname)
    {
        var options = new DbContextOptionsBuilder<TContext>()
            .UseInMemoryDatabase(databaseName: dbname)
            .Options;

        return (TContext)Activator.CreateInstance(typeof(TContext), options);
    }
}
