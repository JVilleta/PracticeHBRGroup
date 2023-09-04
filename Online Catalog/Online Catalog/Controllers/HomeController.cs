using ProjectLogic.BLL;
using ProjectLogic.BLL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Online_Catalog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductsBLL _products;
        private readonly CategoriesBLL _categories;
        public HomeController(ProductsBLL products, CategoriesBLL categories)
        {
            _products = products;
            _categories = categories;
        }

        public ActionResult Index()
        {
            List<dtCategories> categories = _categories.GetCategories();
            return View(categories);
        }


        public JsonResult ProductsList()
        {
            return Json(_products.GetProducts(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsById(int id)
        {
            return Json(_products.GetProductByID(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetByName(string id)
        {
            return Json(_products.GetProductsByName(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetListProductsByCategory(int id)
        {
            return Json(_products.GetProductsByCategoryID(id), JsonRequestBehavior.AllowGet);
        }
    }
}