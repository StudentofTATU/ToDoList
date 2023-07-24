using Microsoft.EntityFrameworkCore;
using ToDoList.Models.Items;
using ToDoList.Models.ToDoes;

namespace ToDoList.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<ToDo> ToDoes{ set; get; }
        public DbSet<Item>  Items{ set; get; }
    }
}
