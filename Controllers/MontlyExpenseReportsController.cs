using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Daily_Expenses_Final.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Daily_Expenses_Final.Controllers
{
    public class MontlyExpenseReportsController : Controller
    {
        private readonly Daily_Expenses_DataContext _context;

        private SignInManager<IdentityUser> SignInManager;

        public MontlyExpenseReportsController(Daily_Expenses_DataContext context,
            SignInManager<IdentityUser> SignInManager
            )
        {
            this.SignInManager = SignInManager;
            _context = context;
        }

        // GET: MontlyExpenseReports
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Index()
        {
            var daily_Expenses_DataContext = _context.MontlyExpenseReport.Include(m => m.UserAccount);

            if (User.IsInRole("user")) {
                var monthly_Expenses_DataContextUser = _context.MontlyExpenseReport.Include(e => e.UserAccount)
                                          .Where(e => e.UserAccount.Email.Equals(User.Identity.Name)).ToList();


                return View(monthly_Expenses_DataContextUser);


            }
            return View(await daily_Expenses_DataContext.ToListAsync());
        }

        // GET: MontlyExpenseReports/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montlyExpenseReport = await _context.MontlyExpenseReport
                .Include(m => m.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montlyExpenseReport == null)
            {
                return NotFound();
            }

            return View(montlyExpenseReport);
        }

        // GET: MontlyExpenseReports/Create
        [Authorize(Roles = "user")]
        public IActionResult Create()
        {

            if (User.IsInRole("user")) {

                var user = (from account in _context.UserAccount
                            where account.Email.Equals(User.Identity.Name)
                            select account).FirstOrDefault();

                //Delete the existing reports
                var reports = (from rep in _context.MontlyExpenseReport

                               where rep.UserAccountId == user.Id
                               select rep
                                 ).ToList();

                _context.RemoveRange(reports);

                _context.SaveChanges();


                //Group by monthly 


                var groupedMonthly = (from expenses in _context.ExpenseRecord
                                     where expenses.UserAccountId == user.Id
                                     group expenses by new { expenses.Date.Year, expenses.Date.Month } into monthly

                                     select new MontlyExpenseReport { Year = monthly.Key.Year, Month = monthly.Key.Month, TotalExpenses = monthly.Sum(e =>e.Amount), UserAccountId = user.Id}).ToList();

                _context.AddRange(groupedMonthly);

                _context.SaveChanges();

                return RedirectToAction(nameof(Index));


            }
           
            return View();
        }

        // POST: MontlyExpenseReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 

        // GET: MontlyExpenseReports/Edit/5



        [Authorize(Roles = "user,admin")]

        // GET: MontlyExpenseReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var montlyExpenseReport = await _context.MontlyExpenseReport
                .Include(m => m.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (montlyExpenseReport == null)
            {
                return NotFound();
            }

            return View(montlyExpenseReport);
        }

        // POST: MontlyExpenseReports/Delete/5
        [Authorize(Roles = "user,admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var montlyExpenseReport = await _context.MontlyExpenseReport.FindAsync(id);
            _context.MontlyExpenseReport.Remove(montlyExpenseReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MontlyExpenseReportExists(int id)
        {
            return _context.MontlyExpenseReport.Any(e => e.Id == id);
        }
    }
}
