using CRUDAPI_DOTNET8.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUDAPI_DOTNET8.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<myCrud> myCruds { get; set; }
    }
}
