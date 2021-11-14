using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Controllers
{
    public class RegisterController : Controller
    {
        WriterManager wm = new WriterManager(new EfWriterRepository());
        CityManager cm = new CityManager(new EfCityRepository());
        
        [HttpGet]
        public IActionResult Index()
        {
            ViewModel viewModel = new ViewModel();
            viewModel.Writers= wm.GetList();
            viewModel.Cities = cm.GetList();
            var values = cm.GetList();
            List<SelectListItem> degerler = new List<SelectListItem>();
            degerler = (from i in values
                        select new SelectListItem
                        {
                            Text = i.CityName,
                            Value = i.CityId.ToString()

                        }).ToList();
            ViewBag.dgr = degerler;
            return View(viewModel);

            /*
            //ViewBag.dgr = values;
            //List<SelectListItem> deg = ViewBag.dgr;
            //return View(values);
            CityManager cm = new CityManager(new EfCityRepository());
            var values = cm.GetList();
            List<SelectListItem> degerler = new List<SelectListItem>();
            degerler = (from i in values
                        select new SelectListItem
                        {
                            Text = i.CityName,
                            Value = i.CityId.ToString()

                        }).ToList();
            ViewBag.dgr = degerler;
            return View();
            */

        }
        //ekleme işlemi yapılırken httpget ve httppost attribute lerinin tanımlandığı methodların isimleri aynı olmak zorunda.
        //httpget sayfa yüklenince, httppost sayfada button tetiklenince çalışacak
        //mesela httpget attribute sayfa yüklendiği anda listelenmesi istenen nineliklerde kullanılabilir
        //mesela httppost attribute update gibi insert gibi işlemlerde kullanılmalı
        [HttpPost]
        public IActionResult Index(Writer p)
        {
            WriterValidator wv = new WriterValidator();
            ValidationResult results = wv.Validate(p);
            if (results.IsValid)
            {
                p.WriterAbout = "deneme hazel";
                p.WriterStatus = true;
                wm.WriterAdd(p);
                return RedirectToAction("Index", "Blog");
            }
            else
            {
                foreach(var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
