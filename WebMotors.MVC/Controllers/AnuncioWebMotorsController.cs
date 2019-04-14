using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using WebMotors.Domain.Entities;
using WebMotors.MVC.ViewModels;
using WebMotors.Proxy.Interface;

namespace WebMotors.MVC.Controllers
{
    public class AnuncioWebMotorsController : Controller
    {
        private readonly IAnuncioWebMotorsProxy _anuncioWebMotorsProxy;

        public AnuncioWebMotorsController(IAnuncioWebMotorsProxy anuncioWebMotorsProxy)
        {
            _anuncioWebMotorsProxy = anuncioWebMotorsProxy;
        }
        // GET: AnuncioWebMotors
        public ActionResult Index()
        {
            var viewModel = Mapper.Map<IEnumerable<AnuncioWebMotors>, IEnumerable<AnuncioWebMotorsViewModel>>(_anuncioWebMotorsProxy.GetAll());
            return View(viewModel);
        }

        // GET: AnuncioWebMotors/Details/5
        public ActionResult Details(int id)
        {
            var domain = _anuncioWebMotorsProxy.GetById(id);
            var viewModel = Mapper.Map<AnuncioWebMotors, AnuncioWebMotorsViewModel>(domain);

            return View(viewModel);
        }

        // GET: AnuncioWebMotors/Create
        public ActionResult Create()
        {
            var marcas = _anuncioWebMotorsProxy.GetMakes();
            ViewBag.Marcas = marcas;
            return View();
        }

        // POST: AnuncioWebMotors/Create
        [HttpPost]
        public ActionResult Create(AnuncioWebMotorsViewModel anuncioWebMotors)
        {
            try
            {
                var domain = Mapper.Map<AnuncioWebMotorsViewModel, AnuncioWebMotors>(anuncioWebMotors);

                _anuncioWebMotorsProxy.Add(domain);

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
            var domain = _anuncioWebMotorsProxy.GetById(id);
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
                _anuncioWebMotorsProxy.Update(domain);

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
            var domain = _anuncioWebMotorsProxy.GetById(id);
            var viewModel = Mapper.Map<AnuncioWebMotors, AnuncioWebMotorsViewModel>(domain);

            return View(viewModel);
        }

        // POST: AnuncioWebMotors/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var domain = _anuncioWebMotorsProxy.GetById(id);
                _anuncioWebMotorsProxy.Remove(domain);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
