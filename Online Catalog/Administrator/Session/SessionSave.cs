

using ProjectLogic.BLL.Entities;
using System.Web;

namespace Administrator.Session
{
    public static class SessionSave
    {
        public static dtUsers loggedUser
        {
            get { return HttpContext.Current.Session["user"] as dtUsers; }
            set
            {
                HttpContext.Current.Session["user"] = value;
            }
        }

        public static bool Auth()
        {
            return loggedUser == null;
        }
    }
}