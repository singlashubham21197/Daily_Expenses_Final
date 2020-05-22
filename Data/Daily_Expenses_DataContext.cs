using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Daily_Expenses_Final.Models;

namespace Daily_Expenses_Final.Models
{
    public class Daily_Expenses_DataContext : DbContext
    {
        public Daily_Expenses_DataContext (DbContextOptions<Daily_Expenses_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Daily_Expenses_Final.Models.ExpenseRecord> ExpenseRecord { get; set; }

        public DbSet<Daily_Expenses_Final.Models.MontlyExpenseReport> MontlyExpenseReport { get; set; }

        public DbSet<Daily_Expenses_Final.Models.UserAccount> UserAccount { get; set; }
    }
}
