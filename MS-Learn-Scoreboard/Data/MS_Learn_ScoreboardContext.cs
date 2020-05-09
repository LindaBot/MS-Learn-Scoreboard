using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MS_Learn_Scoreboard.Models;

namespace MS_Learn_Scoreboard.Data
{
    public class MS_Learn_ScoreboardContext : DbContext
    {

        public MS_Learn_ScoreboardContext (DbContextOptions<MS_Learn_ScoreboardContext> options)
            : base(options)
        {
        }

        public DbSet<MS_Learn_Scoreboard.Models.Student> Student { get; set; }

        public DbSet<MS_Learn_Scoreboard.Models.Debug> Debug { get; set; }
    }
}
