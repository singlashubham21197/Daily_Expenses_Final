using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Daily_Expenses_Final.Models
{
    public class ExpenseRecord
    {


        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public UserAccount UserAccount { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

    }
}
