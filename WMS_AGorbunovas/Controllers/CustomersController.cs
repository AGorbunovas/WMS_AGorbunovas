using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WMS_AGorbunovas.Data;
using WMS_AGorbunovas.Models;
using WMS_AGorbunovas.ViewModels;

namespace WMS_AGorbunovas.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;

        public CustomersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            List<Customer> objList = _context.Customers.Include(u => u.CustomerTypes)
                .ThenInclude(u => u.LoyaltyType).ToList();
            return View(objList);
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            CustomerVM model = GetCustomerWithLoyaltyType();

            return View(model);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerVM customerModel)
        {
            if (ModelState.IsValid)
            {
                Customer newRecord = new Customer()
                {
                    FirstName = customerModel.FirstName,
                    LastName = customerModel.LastName,
                    BirthDate = customerModel.BirthDate,
                    PhoneNumber = customerModel.PhoneNumber.Value,
                    CustomerTypes = customerModel.LoyaltyTypeId.Where(t => t.HasValue).Distinct().Select((t, i) => new CustomerType() { OrderNr = i, TypeId = t.Value}).ToList()
                };
                _context.Add(newRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));            
            }
            return View(customerModel);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,BirthDate,PhoneNumber,CustomerType")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.CustomerId))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }

        private CustomerVM GetCustomerWithLoyaltyType()
        {
            var loyaltyTypeData = _context.LoyaltyTypes.Select(x => new SelectListItem()
            {
                Value = x.LoyaltyName,
                Text = x.LoyaltyName.ToString()
            }).ToList();

            var viewModel = new CustomerVM()
            {
                LoyaltyTypes = loyaltyTypeData
            };

            return viewModel;
        }
    }
}
