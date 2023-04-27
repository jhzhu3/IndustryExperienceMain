using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndustryExperienceMain.Models;

namespace IndustryExperienceMain.Controllers
{
    public class JobsController : Controller
    {
        private readonly IndustryExperienceSqldatabaseContext _context;

        public JobsController(IndustryExperienceSqldatabaseContext context)
        {
            _context = context;
        }

        // GET: Jobs
        public async Task<IActionResult> Index()
        {
            var industryExperienceSqldatabaseContext = _context.Jobs.Include(j => j.Agency);
            return View(await industryExperienceSqldatabaseContext.ToListAsync());
        }

        public IActionResult PreferenceCheck()
        {
            return View();
        }

        /*public IActionResult PreferenceDisplay(string workplace, string typeOfWork)
        {
            var query = _context.Jobs.AsQueryable();

            if (!string.IsNullOrEmpty(workplace) && !string.IsNullOrEmpty(typeOfWork))
            {
                query = query.Where(j => j.Workplace.Contains(workplace) && j.TypeOfWork.Contains(typeOfWork));
                var results = query.ToList();
                return View(results);
            } else if(!string.IsNullOrEmpty(workplace) && string.IsNullOrEmpty(typeOfWork))
            {
                query = query.Where(j => j.Workplace.Contains(workplace));
                var results = query.ToList();
                return View(results);
            }
            else if (string.IsNullOrEmpty(workplace) && !string.IsNullOrEmpty(typeOfWork))
            {
                query = query.Where(j => j.TypeOfWork.Contains(typeOfWork));
                var results = query.ToList();
                return View(results);
            }
            else
            {
                List<Job> empty = new List<Job>();
                return View(empty);
            }
        }*/

        public async Task<IActionResult> SearchLocation() 
        {
            string prefix = HttpContext.Request.Query["term"].ToString();
            var jobs = _context.Jobs.Where(j => j.Workplace.Contains(prefix))
                .Select(j => j.Workplace).Distinct().ToList();
            return Ok(jobs);
        }

        public async Task<IActionResult> SearchType()
        {
            string prefix = HttpContext.Request.Query["term"].ToString();
            var jobs = _context.Jobs.Where(j => j.TypeOfWork.Contains(prefix))
                .Select(j => j.TypeOfWork).Distinct().ToList();
            return Ok(jobs);
        }

        public IActionResult PreferenceDisplay(string workplace, string typeOfWork)
        {
            var dataAgencyTable = _context.Agencies.ToList();
            var dataJobTable = _context.Jobs.ToList();

            var viewModelList = (from t1 in dataAgencyTable
                                 join t2 in dataJobTable on t1.AgencyId equals t2.AgencyId
                                 select new AgencyJobViewModel
                                 { 
                                    AgencyName = t1.AgencyName,
                                    TypeOfWork = t2.TypeOfWork,
                                    Commitment = t2.Commitment,
                                    TimeSection = t2.TimeSection,
                                    Workplace = t2.Workplace,
                                    AgencyLink = t1.Link
                                 }).ToList();

            var query = viewModelList.AsQueryable();

            if (!string.IsNullOrEmpty(workplace) && !string.IsNullOrEmpty(typeOfWork))
            {
                query = query.Where(j => j.Workplace.Contains(workplace) && j.TypeOfWork.Contains(typeOfWork));
                var results = query.ToList();
                return View(results);
            }
            else if (!string.IsNullOrEmpty(workplace) && string.IsNullOrEmpty(typeOfWork))
            {
                query = query.Where(j => j.Workplace.Contains(workplace));
                var results = query.ToList();
                return View(results);
            }
            else if (string.IsNullOrEmpty(workplace) && !string.IsNullOrEmpty(typeOfWork))
            {
                query = query.Where(j => j.TypeOfWork.Contains(typeOfWork));
                var results = query.ToList();
                return View(results);
            }
            else
            {
                List<Job> empty = new List<Job>();
                return View(empty);
            }
        }

        /*        public async Task<IActionResult> PreferenceDisplay(string jobLocationString, string jobTypeString) 
                {
                    var dbContext = _context.Jobs.Include(j => j.Agency);

                    ViewData["FirstFilter"] = jobLocationString;
                    ViewData["SecondFilter"] = jobTypeString;

                    List<Job> jobList = dbContext.ToList();
                    if (jobList.Any(j => j.Workplace.Contains(jobLocationString)) || jobList.Any(j => j.TypeOfWork.Contains(jobTypeString)))
                    {
                        List<Job> found = (List<Job>)jobList.Where(j => j.Workplace.Contains(jobLocationString));
                        return View(found);
                    }
                }*/

        // GET: Jobs/Details/5
        public async Task<IActionResult> Details(decimal? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Agency)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // GET: Jobs/Create
        public IActionResult Create()
        {
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyId");
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("JobId,AgencyId,TypeOfWork,Commitment,TimeSection,Workplace")] Job job)
        {
            if (ModelState.IsValid)
            {
                _context.Add(job);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyId", job.AgencyId);
            return View(job);
        }

        // GET: Jobs/Edit/5
        public async Task<IActionResult> Edit(decimal? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs.FindAsync(id);
            if (job == null)
            {
                return NotFound();
            }
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyId", job.AgencyId);
            return View(job);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(decimal id, [Bind("JobId,AgencyId,TypeOfWork,Commitment,TimeSection,Workplace")] Job job)
        {
            if (id != job.JobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(job);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobExists(job.JobId))
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
            ViewData["AgencyId"] = new SelectList(_context.Agencies, "AgencyId", "AgencyId", job.AgencyId);
            return View(job);
        }

        // GET: Jobs/Delete/5
        public async Task<IActionResult> Delete(decimal? id)
        {
            if (id == null || _context.Jobs == null)
            {
                return NotFound();
            }

            var job = await _context.Jobs
                .Include(j => j.Agency)
                .FirstOrDefaultAsync(m => m.JobId == id);
            if (job == null)
            {
                return NotFound();
            }

            return View(job);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(decimal id)
        {
            if (_context.Jobs == null)
            {
                return Problem("Entity set 'IndustryExperienceSqldatabaseContext.Jobs'  is null.");
            }
            var job = await _context.Jobs.FindAsync(id);
            if (job != null)
            {
                _context.Jobs.Remove(job);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JobExists(decimal id)
        {
          return (_context.Jobs?.Any(e => e.JobId == id)).GetValueOrDefault();
        }
    }
}
