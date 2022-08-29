using AspNetCoreMvc.Data;
using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreMvc.Controllers
{
    public class PessoaController : Controller
    {
 
        private readonly DataContext _context;

        public PessoaController(DataContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Pessoas = _context.Pessoas.ToList();
            return View();
        }

        #region [ CREATE ]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();
            return RedirectToAction("index", "pessoa");
        }
        #endregion

        #region [ DETAILS ]
        [HttpGet]
        public IActionResult Details(int id)
        {
            Pessoa pessoa = _context.Pessoas.Find(id);
            return View(pessoa);
        }
        #endregion

        #region [ EDIT ]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Pessoa pessoa = _context.Pessoas.Find(id);
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Edit(Pessoa pessoa)
        {
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        #endregion

        #region [ DELETE ]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Pessoa pessoa = _context.Pessoas.Find(id);
            return View(pessoa);
        }

        [HttpPost]
        public IActionResult Delete(Pessoa pessoa)
        {
            _context.Pessoas.Remove(pessoa);
            _context.SaveChanges();
            return RedirectToAction("index", "pessoa");
        }
        #endregion
    }
}
