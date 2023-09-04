using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using Administrator.Session;
using ProjectLogic.BLL;
using ProjectLogic.BLL.Entities;

namespace Administrator.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductsBLL _products;
        private readonly CategoriesBLL _categories;

        public ProductsController(
            ProductsBLL productsBLL, 
            CategoriesBLL categories)
        {
            _products = productsBLL;
            _categories = categories;
        }

        public ActionResult ProductsView()
        {
            if(SessionSave.Auth())
                return RedirectToAction("LoginView","Users");

            List<dtCategories> categories = _categories.GetCategories();
            return View(categories);
        }

        public JsonResult ProductsList()
        {
            return Json(_products.GetProducts(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsAdd(dtProducts product)
        {
            string Author = $"{SessionSave.loggedUser.UserName} {SessionSave.loggedUser.LastName}";
            return Json(_products.AddProduct(product, Author) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }       
        public JsonResult ProductsByID(int id)
        {
            return Json(_products.GetProductByID(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsUpdate(dtProducts product)
        {
            string Author = $"{SessionSave.loggedUser.UserName} {SessionSave.loggedUser.LastName}";
            return Json(_products.UpdateProduct(product, Author) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ProductsDelete(int Id)
        {
            return Json(_products.DeleteProduct(Id) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
    }
}