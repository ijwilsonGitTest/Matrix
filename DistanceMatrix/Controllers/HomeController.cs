using DistanceMatrix.DAL.Repositories;
using DistanceMatrix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DistanceMatrix.Controllers
{
    public class HomeController : Controller
    {
        DistanceRepository _repository;
        public HomeController()
        {
            //Inject repository ultimately
            _repository = new DistanceRepository();
        }
        public async Task<ActionResult> Index()
        {
            Distance distance = await _repository.GetDistance("Manchester,UK", "London,UK");
            return View("Home");
        }

        public async Task<ActionResult> GetDistance(string origin, string destination)
        {
            Distance distance = await _repository.GetDistance("Manchester,UK", "London,UK");
            return PartialView("Distance", distance);
        }

        public ActionResult GetHistory()
        {
            return PartialView("History", _repository.GetHistory());
        }

        public ActionResult AddHistory(Distance savedDistance)
        {

            return PartialView("History", _repository.AddToHistory(savedDistance));
        }
    }
}