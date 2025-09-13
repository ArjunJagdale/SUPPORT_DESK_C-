using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportDeskAppNew.Data;
using SupportDeskAppNew.Models;

namespace SupportDeskAppNew.Controllers
{
    public class TicketsController : Controller
    {
        private readonly AppDbContext _context;

        public TicketsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Tickets
        public async Task<IActionResult> Index(string searchTerm, string statusFilter, string priorityFilter, string sortOrder)
        {
            var tickets = from t in _context.Tickets select t;

            // Search by Title or Description
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                tickets = tickets.Where(t =>
                    t.Title.Contains(searchTerm) ||
                    (t.Description != null && t.Description.Contains(searchTerm)));
            }

            // Filter by Status
            if (!string.IsNullOrWhiteSpace(statusFilter) && statusFilter != "All")
            {
                tickets = tickets.Where(t => t.Status == statusFilter);
            }

            // Filter by Priority
            if (!string.IsNullOrWhiteSpace(priorityFilter) && priorityFilter != "All")
            {
                tickets = tickets.Where(t => t.Priority == priorityFilter);
            }

            // Sorting
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["StatusSortParm"] = sortOrder == "Status" ? "status_desc" : "Status";
            ViewData["PrioritySortParm"] = sortOrder == "Priority" ? "priority_desc" : "Priority";

            switch (sortOrder)
            {
                case "title_desc":
                    tickets = tickets.OrderByDescending(t => t.Title);
                    break;
                case "Date":
                    tickets = tickets.OrderBy(t => t.Created);
                    break;
                case "date_desc":
                    tickets = tickets.OrderByDescending(t => t.Created);
                    break;
                case "Status":
                    tickets = tickets.OrderBy(t => t.Status);
                    break;
                case "status_desc":
                    tickets = tickets.OrderByDescending(t => t.Status);
                    break;
                case "Priority":
                    tickets = tickets.OrderBy(t => t.Priority);
                    break;
                case "priority_desc":
                    tickets = tickets.OrderByDescending(t => t.Priority);
                    break;
                default:
                    tickets = tickets.OrderByDescending(t => t.Created);
                    break;
            }

            ViewBag.SearchTerm = searchTerm;
            ViewBag.StatusFilter = statusFilter;
            ViewBag.PriorityFilter = priorityFilter;
            ViewBag.CurrentSort = sortOrder;

            // Get ticket statistics
            ViewBag.TotalTickets = await _context.Tickets.CountAsync();
            ViewBag.OpenTickets = await _context.Tickets.CountAsync(t => t.Status == "Open");
            ViewBag.InProgressTickets = await _context.Tickets.CountAsync(t => t.Status == "In Progress");
            ViewBag.ClosedTickets = await _context.Tickets.CountAsync(t => t.Status == "Closed");

            return View(await tickets.ToListAsync());
        }

        // GET: Tickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.Tickets.FirstOrDefaultAsync(m => m.Id == id);
            if (ticket == null) return NotFound();

            return View(ticket);
        }

        // GET: Tickets/Create
        public IActionResult Create()
        {
            var ticket = new Ticket
            {
                Status = "Open",
                Priority = "Medium"
            };
            return View(ticket);
        }

        // POST: Tickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Status,Priority")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.Created = DateTime.Now;
                ticket.Status = "Open"; // Ensure new tickets are always Open
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ticket created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            return View(ticket);
        }

        // POST: Tickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Status,Priority,Created")] Ticket ticket)
        {
            if (id != ticket.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Ticket updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Tickets.Any(e => e.Id == ticket.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Ticket deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Quick status update via AJAX
        [HttpPost]
        public async Task<IActionResult> QuickStatusUpdate(int id, string status)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null) return NotFound();

            ticket.Status = status;
            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "Status updated successfully" });
        }
    }
}