namespace Calgroup.Models.DAO
{
    public class ChangesDAO
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();
        public bool OrdersStatus(int id)
        {
            Order status = db.Orders.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool ProductStatus(int id)
        {
            Product status = db.Products.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool SliseStatus(int id)
        {
            Slide status = db.Slides.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool PostsStatus(int id)
        {
            Post status = db.Posts.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool PostsCateStatus(int id)
        {
            PostCategory status = db.PostCategories.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool ProjectProductsStatus(int id)
        {
            ProjectProduct status = db.ProjectProducts.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool ProductCategoriesStatus(int id)
        {
            ProductCategory status = db.ProductCategories.Find(id);
            status.Status = !status.Status;
            db.SaveChanges();
            return status.Status;
        }
        public bool CalibrationsStatus(int id)
        {
            Calibration status = db.Calibrations.Find(id);
            db.SaveChanges();
            return status.Status;
        }

        public bool LibrariesStatus(int id)
        {
            Library status = db.Libraries.Find(id);
            db.SaveChanges();
            return status.Status;
        }
    }
}
