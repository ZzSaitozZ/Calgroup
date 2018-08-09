using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
namespace Model.DAO
{
    public class MenuDAO
    {
        private ProductsdbContext db = new ProductsdbContext();

        public IEnumerable<Menu> ListByGroupId()
        {
            return db.Menus.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
