using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NeosoftController : Controller
    {
        // GET: Neosoft

        SQLHelper helper = new SQLHelper();
        public List<Country> CountryList()
        {
            List<Country> countris = helper.GetAllCountry().ToList();
            return countris;
        }

        public ActionResult StateList(int CountryId)
        {

            List<State> Slist= helper.GetAllState().Where(x => x.CountryId == CountryId).ToList();
            ViewBag.StateList = new SelectList(Slist, "Row_Id", "StateName");
            return PartialView("DisplayState");
        }

        public ActionResult CityList(int StateId)
        {
            List<City> Clist = helper.GetAllCity().Where(x => x.StateId == StateId).ToList();
            ViewBag.CityList = new SelectList(Clist, "Row_Id", "CityName");
            return PartialView("DisplayCity");
        }

        [HttpGet]
        public ActionResult DisplayNeosoftList()
        {
            
           var result= helper.GetAllNeosoftData().ToList();

            return View(result);
        }
        [HttpGet]
        public ActionResult DisplayList()
        {

            var result = helper.GetAllNeosoftData().ToList();
             return Json(new { data = result }, JsonRequestBehavior.AllowGet);
            
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.CountryList = new SelectList(CountryList(), "Row_Id", "CountryName");

            return View();

        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase file, Neo_Test neoTest)
        {
            string filename = Path.GetFileName(file.FileName);
            string extension = Path.GetExtension(file.FileName);
            string path = Path.Combine(Server.MapPath("~/Image"), filename);
            neoTest.ProfileImage = "~/Image/" + filename;
            if (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png")
            {

                if (file.ContentLength <= 1000000)
                {
                    file.SaveAs(path);

                    helper.AddNeo_Test(neoTest);
                    return RedirectToAction("DisplayNeosoftList");
                }
            }

            return View();
            
        }

        [HttpGet]
        public ActionResult Edit(int? Id)
        {

            List<Country> countris = helper.GetAllCountry().ToList();
            ViewBag.CountryList = new SelectList(CountryList(), "Row_Id", "CountryName");
            List<State> Slist = helper.GetAllState().ToList();
            ViewBag.StateList = new SelectList(Slist, "Row_Id", "StateName");

            List<City> Clist = helper.GetAllCity().ToList();
            ViewBag.CityList = new SelectList(Clist, "Row_Id", "CityName");



            return View(helper.GetNeosoftById(Id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(Neo_Test neosoft)
        {
            if (ModelState.IsValid)
            {
                 helper.Update_Neo(neosoft);
                ModelState.Clear();
                return RedirectToAction("DisplayNeosoftList");
            }
            else
            {
                ModelState.AddModelError("", "Error In Saving Data");
                return View();
            }
        }
        
        [HttpGet]
        public JsonResult IsPanNumberExist(string PanNumber)
        {
            return Json(!helper.GetAllNeosoftData().Any(x=> x.PanNumber == PanNumber), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public JsonResult IsPassportNumberExist(string PassportNumber)
        {
            return Json(!helper.GetAllNeosoftData().Any(x => x.PassportNumber == PassportNumber), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int Id)
        {
            helper.DeleteNeoData(Id);
            ModelState.Clear();
             return RedirectToAction("DisplayNeosoftList");
           
        }



    }
}