using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Models;

namespace TicTacToeApi.Data {
    public class ApiDbContext : DbContext {
        public DbSet<GameModel> Games { get; set; }

        public ApiDbContext() {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlite(@$"Data Source={AppContext.BaseDirectory}TicTacToe.db");

    }
}
