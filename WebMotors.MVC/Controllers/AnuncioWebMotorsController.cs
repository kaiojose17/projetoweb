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

            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "Selecione", Value = "0"});

            foreach (var marca in marcas)
            {
                listItems.Add(new SelectListItem { Text = $"{marca.Id} - {marca.Name}", Value = marca.Name });
                ViewBag.Marcas = listItems;
            }

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
            var marcas = _anuncioWebMotorsProxy.GetMakes();

            List<SelectListItem> listItems = new List<SelectListItem>();
            listItems.Add(new SelectListItem { Text = "Selecione", Value = "0" });

            foreach (var marca in marcas)
            {
                listItems.Add(new SelectListItem { Text = $"{marca.Id} - {marca.Name}", Value = marca.Name });
                ViewBag.Marcas = listItems;
            }

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

        public JsonResult GetModel(int makeId)
        {
            var models = _anuncioWebMotorsProxy.GetModels(makeId);


            var listItens = new List<SelectListItem>();

            listItens.Add(new SelectListItem { Text = "Selecione", Value = "0" });

            foreach (var modelo in models)
            {
                listItens.Add(new SelectListItem { Text = $"{modelo.Id} - {modelo.Name}", Value = modelo.Name });
            }

            return Json(new SelectList(listItens, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVersion(int modelId)
        {
            var versions = _anuncioWebMotorsProxy.GetVersions(modelId);

            var listItens = new List<SelectListItem>();

            listItens.Add(new SelectListItem { Text = "Selecione", Value = "0" });

            foreach (var version in versions)
            {
                listItens.Add(new SelectListItem { Text = $"{version.Id} - {version.Name}", Value = version.Name });
            }

            return Json(new SelectList(listItens, "Value", "Text"), JsonRequestBehavior.AllowGet);
        }
    }
}
