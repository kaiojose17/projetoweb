using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMotors.Application.Interface;
using WebMotors.Domain.Entities;
using WebMotors.MVC.ViewModels;

namespace WebMotors.MVC.Controllers
{
    public class AnuncioWebMotorsController : Controller
    {
        private readonly IWebMotorsServiceBase _webMotorsServiceBase;

        public AnuncioWebMotorsController(IWebMotorsServiceBase webMotorsServiceBase)
        {
            _webMotorsServiceBase = webMotorsServiceBase;
        }

        // GET: AnuncioWebMotors
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<AnuncioWebMotors>, IEnumerable<AnuncioWebMotorsViewModel>>(_webMotorsServiceBase.GetAll());
            return View(viewModel);
        }

        // GET: AnuncioWebMotors/Details/5
        public ActionResult Details(int id)
        {
            var domain = _webMotorsServiceBase.GetById(id);
            var viewModel = Mapper.Map<AnuncioWebMotors, AnuncioWebMotorsViewModel>(domain);

            return View(viewModel);
        }

        // GET: AnuncioWebMotors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AnuncioWebMotors/Create
        [HttpPost]
        public ActionResult Create(AnuncioWebMotorsViewModel anuncioWebMotors)
        {
            try
            {
                var domain = Mapper.Map<AnuncioWebMotorsViewModel, AnuncioWebMotors>(anuncioWebMotors);

                _webMotorsServiceBase.Add(domain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(anuncioWebMotors);
            }
        }

        // GET: AnuncioWebMotors/Edit/5
        public ActionResult Edit(int id)
        {
            var domain = _webMotorsServiceBase.GetById(id);
            var viewModel = Mapper.Map<AnuncioWebMotors, AnuncioWebMotorsViewModel>(domain);

            return View(viewModel);
        }

        // POST: AnuncioWebMotors/Edit/5
        [HttpPost]
        public ActionResult Edit(AnuncioWebMotorsViewModel viewModel)
        {
            try
            {
                var domain = Mapper.Map<AnuncioWebMotorsViewModel, AnuncioWebMotors>(viewModel);
                _webMotorsServiceBase.Update(domain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View(viewModel);
            }
        }

        // GET: AnuncioWebMotors/Delete/5
        public ActionResult Delete(int id)
        {
            var domain = _webMotorsServiceBase.GetById(id);
            var viewModel = Mapper.Map<AnuncioWebMotors, AnuncioWebMotorsViewModel>(domain);

            return View(viewModel);
        }

        // POST: AnuncioWebMotors/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var domain = _webMotorsServiceBase.GetById(id);
                _webMotorsServiceBase.Remove(domain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
