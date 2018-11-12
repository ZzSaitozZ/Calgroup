using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class ProjectMenuDao
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<ProductCategory> getProjectMenuDao()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
