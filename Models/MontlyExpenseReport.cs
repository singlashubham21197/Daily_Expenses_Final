using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daily_Expenses_Final.Models
{
    public class MontlyExpenseReport
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }
        public int Year { get; set; }

        public int Month { get; set;  }

        public decimal TotalExpenses { get; set; }


    }
}
