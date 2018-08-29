 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
