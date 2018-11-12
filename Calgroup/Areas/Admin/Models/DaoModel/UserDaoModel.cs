using Calgroup.Areas.Admin.Models.BusinessModel;

using System;
using System.Linq;

namespace Calgroup.Areas.Admin.Models.DaoModel
{
    public class UserDaoModel
    {
        private AdminDbContext db = new AdminDbContext();
        private Calgroup_v2DB db1 = new Calgroup_v2DB();
        public bool ChangeStatus(int id)
        {
            UserAdministrator user = db.Administrators.Find(id);
            user.Allowed = !user.Allowed;
            db.SaveChanges();
            return user.Allowed;
        }

        public bool Delete(int id)
        {
            try
            {
                UserAdministrator user = db.Administrators.Find(id);
                db.Administrators.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public int CountUserName()
        {
            return db.Administrators.Count();
        }

        public bool CheckUserName(string userName)
        {
            return db.Administrators.Count(x => x.UserName == userName) > 0;
        }

        public bool CheckEmail(string email)
        {
            return db.Administrators.Count(x => x.Email == email) > 0;
        }

        public int CountOder()
        {
            return db1.Orders.Count();
        }
    }
}