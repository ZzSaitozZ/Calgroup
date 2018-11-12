using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class MenuDAO
    {
        public Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<Calgroup.Menu> ListByGroupId()
        {
            return db.Menus.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
