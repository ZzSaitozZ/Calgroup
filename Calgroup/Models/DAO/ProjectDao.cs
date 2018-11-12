using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class ProjectDao
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<Project> getProjectDao()
        {
            return db.Projects.Where(x => x.Status == true).ToList();
        }
    }
}
