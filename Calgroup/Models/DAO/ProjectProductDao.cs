using System;
using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class ProjectProductDao
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<ProjectProduct> getProjectProductDao()
        {
            return db.ProjectProducts.Where(x => x.Status == true).ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                ProjectProduct user = db.ProjectProducts.Find(id);
                db.ProjectProducts.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
