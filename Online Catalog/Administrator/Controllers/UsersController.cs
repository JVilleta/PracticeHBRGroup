using ProjectLogic.BLL;
using ProjectLogic.BLL.Entities;
using Administrator.Session;
using System.Web.Mvc;
using System.Net;

namespace Administrator.Controllers
{
    public class UsersController : Controller
    {
        private readonly UsersBLL _users;
        public UsersController(UsersBLL userBLL)
        {
            _users = userBLL;
        }

        public ActionResult LoginView()
        {
            return View();
        }
        public ActionResult RegisterView()
        {
            return View();
        }
        public ActionResult HomeView()
        {
            if (SessionSave.Auth())
                return RedirectToAction("LoginView");

            dtUsers user = SessionSave.loggedUser;
            return View(user);
        }

        public RedirectToRouteResult SignOff()
        {
            SessionSave.loggedUser = null;
            return RedirectToAction("LoginView");
        }

        public JsonResult LoginValidate(dtUsers user)
        {
            return Json(SessionSave.loggedUser = _users.LoginValidate(user), JsonRequestBehavior.AllowGet);
        }
        public JsonResult UsersAdd(dtUsers user)
        {
            return Json(_users.AddUser(user) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
        public JsonResult UsersUpdate(dtUsers user)
        {
            return Json(_users.UpdateUser(user) ? Response.StatusCode = (int)HttpStatusCode.OK : Response.StatusCode = (int)HttpStatusCode.InternalServerError, JsonRequestBehavior.AllowGet);
        }
    }
}