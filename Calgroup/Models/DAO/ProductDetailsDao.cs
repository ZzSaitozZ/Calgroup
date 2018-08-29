 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calgroup.Models.DAO
{
  public  class ProductDetailsDao
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();
       
        public IEnumerable<Product> getProductDetails(int id)
        {
            return db.Products.Where(x => x.Status == true && x.ID==id).ToList();


        }
    }
}
