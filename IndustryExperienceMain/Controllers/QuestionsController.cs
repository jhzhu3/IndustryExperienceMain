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

        private int points;

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

        public IActionResult QuestionIndex()
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();
            //pointsList = new List<int>(new int[7]);
            

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);

            return View(tupleModel);
        }

        public ActionResult QuestionTwo(int answer1)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>( new int[7]);
            //pointsList[0] = answer1;
            points = answer1;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
        }

        public ActionResult QuestionThree(int answer2)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>(new int[7]);
            points = answer2;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
        }

        public ActionResult QuestionFour(int answer3)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>(new int[7]);
            points = answer3;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
        }

        public ActionResult QuestionFive(int answer4)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>(new int[7]);
            points = answer4;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
        }

        public ActionResult QuestionSix(int answer5)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>(new int[7]);
            points = answer5;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
        }

        public ActionResult QuestionSeven(int answer6)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>(new int[7]);
            points = answer6;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
        }

        public ActionResult QuizFinish(int answer7)
        {
            var questionsTable = _context.Questions.ToList();
            var answersTable = _context.Answers.ToList();

            //var pointsList = new List<int>(new int[7]);
            points = answer7;

            var tupleModel = new Tuple<List<Question>, List<Answer>, int>(questionsTable, answersTable, points);
            return View(tupleModel);
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
