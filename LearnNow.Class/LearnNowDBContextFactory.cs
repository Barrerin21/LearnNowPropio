using LearnNow.Class;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

public class LearnNowDBContextFactory : IDesignTimeDbContextFactory<LearnNowDB>
{
     LearnNowDB IDesignTimeDbContextFactory<LearnNowDB>.CreateDbContext(string[] args)
    {
        var optionBuilder = new DbContextOptionsBuilder<LearnNowDB>();
        optionBuilder.UseSqlServer("Server=LAPTOP-DOP3PHE3;Database=learnNowDB;Trusted_Connection=True;TrustServerCertificate=True;");

        return new LearnNowDB(optionBuilder.Options);

    }
}
