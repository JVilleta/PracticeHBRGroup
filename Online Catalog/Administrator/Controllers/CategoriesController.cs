using Administrator.Session;
using ProjectLogic.BLL;
using ProjectLogic.BLL.Entities;
using System.Net;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly CategoriesBLL _categories;
        string UserName;

        public CategoriesController (CategoriesBLL categories)
        {
            _categories = categories;
        }

        public ActionResult CategoriesView()
        {
            if (SessionSave.Auth())
                return RedirectToAction("LoginView", "Users");
            
            return View();
        }

        public JsonResult CategoriesList()
        { 
            return Json(_categories.GetCategories(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesByID(int id) 
        {
            return Json(_categories.GetCategoriesByID(id), JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesAdd(dtCategories category)
        {
            UserName = $"{SessionSave.loggedUser.UserName} {SessionSave.loggedUser.LastName}";
            return Json(_categories.AddCategory(category, UserName) ? Response.StatusCode = (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesUpdate(dtCategories category)
        {
            UserName = $"{SessionSave.loggedUser.UserName} {SessionSave.loggedUser.LastName}";
            return Json(_categories.UpdateCategory(category, UserName) ? Response.StatusCode = (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CategoriesDelete(int id)
        {
            return Json(_categories.DeleteCategory(id) ? Response.StatusCode = (int)HttpStatusCode.OK : (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
    }
}