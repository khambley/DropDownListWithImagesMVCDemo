using DropDownListDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Mvc.Html;

namespace DropDownListDemo.Controllers
{
    public class HomeController : Controller
    {
        DropDownListDemoDbContext _db = new DropDownListDemoDbContext();
        public ActionResult Index()
        {
            var model = _db.Contestants.Include(c => c.Country).ToList();
                
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Create()
        {
            var reservationViewModel = new ContestantViewModel
            {
                AllCountries = this.GetAllCountries()
            };

            return View(reservationViewModel);
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "ContestantId,FirstName,LastName,Age,CountryId")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                _db.Contestants.Add(contestant);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contestant);
        }
        private IEnumerable<ImageSelectListItem> GetAllCountries()
        {
            IEnumerable<Country> countryList = _db.Countries.ToList();
            return AutoMapper.Mapper.Map<IEnumerable<Country>, IEnumerable<ImageSelectListItem>>(countryList);
            
        }
        protected override void Dispose(bool disposing)
        {
            if(_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }
}