using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MS_Learn_Scoreboard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MS_Learn_Scoreboard.Models
{
    public class InitDatabase
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MS_Learn_ScoreboardContext(
                serviceProvider.GetRequiredService<DbContextOptions<MS_Learn_ScoreboardContext>>()))
            {
                context.SaveChanges();
            }
        }
 
    }
}
