using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMotors.Application.Interface;

namespace WebMotors.WebApi.Controllers
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
            return View();
        }
    }
}