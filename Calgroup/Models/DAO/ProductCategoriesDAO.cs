 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Calgroup.Models.DAO
{
    public class ProductCategoriesDAO
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<ProductCategory> getProductCategories(int id)
        {
            return db.ProductCategories.Where(x => x.Status == true && x.ID == id).ToList();


        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.ProductCategories.Find(id);
                db.ProductCategories.Remove(user);
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

