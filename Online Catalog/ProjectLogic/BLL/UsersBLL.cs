using ProjectLogic.BLL.Entities;
using ProjectLogic.DAL;

namespace ProjectLogic.BLL
{
    public class UsersBLL
    {
        private readonly UsersDAL _context;

        public UsersBLL(UsersDAL context)
        {
            _context = context;
        }

        public dtUsers LoginValidate(dtUsers user)
        {
            return _context.Login(user);
        }
        public bool AddUser(dtUsers user)
        {
            return _context.AddUser(user);
        }
        public bool UpdateUser(dtUsers user)
        {
            return _context.UpdateUser(user);
        }
    }
}
