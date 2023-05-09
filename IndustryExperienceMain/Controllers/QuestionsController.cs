using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IndustryExperienceMain.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Mvc.Infrastructure;
//using AutoMapper;
using System.Dynamic;

namespace IndustryExperienceMain.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IndustryExperienceMainDbContext _context;

        //private Tuple quizTuple;

        public QuestionsController(IndustryExperienceMainDbContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            var industryExperienceMainDbContext = _context.Questions.Include(q => q.Quiz);
            return View(await industryExperienceMainDbContext.ToListAsync());
        }

        /*        public IActionResult Test()
                {
                    var questionsTable = _context.Questions.ToList();
                    var answersTable = _context.Answers.ToList();
                    var individualAnswerList = new List<Answer>();

                    var viewModelList = (from t1 in questionsTable
                                         join t2 in answersTable on t1.Id equals t2.QuestionId
                                         select new MyItem
                                         {
                                             Id = t1.Id,
                                             Title = t1.Text,
                                             Answer = t2.Text,
                                             Points = t2.Points 
                                         }).ToList();
                    var model = new QuestionAnswerViewModel { Questions = viewModelList };
                    var query = model.AsQueryable();
                    var result = query.ToList();
                    return View(model); 
                }*/
        public IActionResult QuestionIndex()
        {
/*            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var viewModelList = (from t1 in questionsTable
                                 join t2 in answersTable on t1.Id equals t2.QuestionId
                                 select new QuestionAnswerViewModel
                                 {
                                     Question = t1.Text,
                                     Answers = t2.Text.Where(t2.QuestionId.Equals(t1.Id)),
                                     Points = t2.Points
                                 }).ToList();

            var query = viewModelList.AsQueryable();

            var results = query.ToList();

            return View(results);*/
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);

            return View(tupleModel);
        }

        //[HttpPost]
        //public IActionResult Test(IFormCollection SelectedAnswerId)
        //{
        //    return View(SelectedAnswerId);
        //}

        public ActionResult QuestionTwo() {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);
            return View(tupleModel);
        }

        public ActionResult QuestionThree()
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);
            return View(tupleModel);
        }

        public ActionResult QuestionFour()
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);
            return View(tupleModel);
        }

        public ActionResult QuestionFive()
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);
            return View(tupleModel);
        }

        public ActionResult QuestionSix()
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);
            return View(tupleModel);
        }

        public ActionResult QuestionSeven()
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            var tupleModel = new Tuple<List<Question>, List<Answer>>(questionsTable, answersTable);
            return View(tupleModel);
        }

        public ActionResult QuizFinish()
        {
            return View();
        }

        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // GET: Questions/Create
        public IActionResult Create()
        {
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "Id", "Id");
            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Text,QuizId")] Question question)
        {
            if (ModelState.IsValid)
            {
                _context.Add(question);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "Id", "Id", question.QuizId);
            return View(question);
        }

        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "Id", "Id", question.QuizId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Text,QuizId")] Question question)
        {
            if (id != question.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(question);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuestionExists(question.Id))
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
            ViewData["QuizId"] = new SelectList(_context.Quizzes, "Id", "Id", question.QuizId);
            return View(question);
        }

        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Questions == null)
            {
                return NotFound();
            }

            var question = await _context.Questions
                .Include(q => q.Quiz)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (question == null)
            {
                return NotFound();
            }

            return View(question);
        }

        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Questions == null)
            {
                return Problem("Entity set 'IndustryExperienceMainDbContext.Questions'  is null.");
            }
            var question = await _context.Questions.FindAsync(id);
            if (question != null)
            {
                _context.Questions.Remove(question);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuestionExists(int id)
        {
          return (_context.Questions?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
