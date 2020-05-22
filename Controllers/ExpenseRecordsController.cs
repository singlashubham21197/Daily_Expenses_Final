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
    public class ExpenseRecordsController : Controller
    {
        private readonly Daily_Expenses_DataContext _context;

        public ExpenseRecordsController(Daily_Expenses_DataContext context)
        {
            _context = context;
        }

        // GET: ExpenseRecords

        [Authorize(Roles="admin,user")]
        public async Task<IActionResult> Index()
        {
            var daily_Expenses_DataContext = _context.ExpenseRecord.Include(e => e.UserAccount);
            if (User.IsInRole("user")) {
                
                var daily_Expenses_DataContextUser = _context.ExpenseRecord.Include(e => e.UserAccount)
                                        .Where(e=>e.UserAccount.Email.Equals(User.Identity.Name)).ToList();


                return View(daily_Expenses_DataContextUser);

            }



            return View(await daily_Expenses_DataContext.ToListAsync());
        }

        // GET: ExpenseRecords/Details/5
        [Authorize(Roles = "admin,user")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseRecord = await _context.ExpenseRecord
                .Include(e => e.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseRecord == null)
            {
                return NotFound();
            }

            return View(expenseRecord);
        }

        // GET: ExpenseRecords/Create

        [Authorize(Roles = "user")]
        public IActionResult Create()
        {


            return View();
        }

        // POST: ExpenseRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Amount,Date")] ExpenseRecord expenseRecord)
        {
            if (ModelState.IsValid)
            {

                var user = (from account in _context.UserAccount
                            where account.Email.Equals(User.Identity.Name)
                            select account).FirstOrDefault();
                expenseRecord.UserAccountId = user.Id;
                _context.Add(expenseRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           
            return View(expenseRecord);
        }

        // GET: ExpenseRecords/Edit/5

        [Authorize(Roles = "user")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseRecord = await _context.ExpenseRecord.FindAsync(id);
            if (expenseRecord == null)
            {
                return NotFound();
            }
         
            return View(expenseRecord);
        }

        // POST: ExpenseRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "user")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserAccountId,Description,Amount,Date")] ExpenseRecord expenseRecord)
        {
            if (id != expenseRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(expenseRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExpenseRecordExists(expenseRecord.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserAccountId"] = new SelectList(_context.Set<UserAccount>(), "Id", "Id", expenseRecord.UserAccountId);
            return View(expenseRecord);
        }

        [Authorize(Roles = "admin,user")]
        // GET: ExpenseRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var expenseRecord = await _context.ExpenseRecord
                .Include(e => e.UserAccount)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (expenseRecord == null)
            {
                return NotFound();
            }

            return View(expenseRecord);
        }

        // POST: ExpenseRecords/Delete/5
        [Authorize(Roles = "admin,user")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var expenseRecord = await _context.ExpenseRecord.FindAsync(id);
            _context.ExpenseRecord.Remove(expenseRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExpenseRecordExists(int id)
        {
            return _context.ExpenseRecord.Any(e => e.Id == id);
        }
    }
}
