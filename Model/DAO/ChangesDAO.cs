using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class ChangesDAO
    {
        private ProductsdbContext db = new ProductsdbContext();
        public bool OrdersStatus(int id)
        {
            var status = db.Orders.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool ProductStatus(int id)
        {
            var status = db.Products.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool SliseStatus(int id)
        {
            var status = db.Slides.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool PostsStatus(int id)
        {
            var status = db.Posts.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool PostsCateStatus(int id)
        {
            var status = db.PostCategories.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool ProjectProductsStatus(int id)
        {
            var status = db.ProjectProducts.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool ProductCategoriesStatus(int id)
        {
            var status = db.ProductCategories.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool CalibrationsStatus(int id)
        {
            var status = db.Calibrations.Find(id);
            if(status.Status == true)
            {
                status.Status = false;
            }
            else
            {
                status.Status = true;
            }
            db.SaveChanges();
            if(status.Status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool LibrariesStatus(int id)
        {
            var status = db.Libraries.Find(id);
            if (status.Status == true)
            {
                status.Status = false;
            }
            else
            {
                status.Status = true;
            }
            db.SaveChanges();
            if (status.Status == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
