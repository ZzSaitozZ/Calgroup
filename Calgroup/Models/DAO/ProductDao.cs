using System;
using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class ProductDao
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();
        public IEnumerable<Product> getProduct()
        {
            return db.Products.Where(x => x.Status == true).ToList();
        }

        public IEnumerable<Product> getProductCata(int top, int t)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Where(x => x.Status == true && x.CategoryID == t).Take(top).ToList();
        }

        public IEnumerable<Product> getProductCa(int id)
        {
            return db.Products.Where(x => x.Status == true && x.CategoryID == id).ToList();
        }
        public IEnumerable<Product> getProductHot(int top, int t)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Where(x => x.Status == true && x.CategoryID == t).Take(top).ToList();
        }

        public int maxDisplayOrder()
        {
            return (int)db.Linhvucs.Where(x => x.DisplayOrder < 999).Max(x => x.DisplayOrder);
        }

        public bool Delete(int id)
        {
            try
            {
                Product product = db.Products.Find(id);
                db.Products.Remove(product);
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