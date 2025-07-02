using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace NotelyRestApi.Database
{
    public class NotelyDbContextFactory : IDesignTimeDbContextFactory<NotelyDbContext>
    {
        public NotelyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotelyDbContext>();

            // Connection string hardcoded aqui só para design-time.
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=NotelyDb;Trusted_Connection=True;");

            return new NotelyDbContext(optionsBuilder.Options);
        }
    }
}
