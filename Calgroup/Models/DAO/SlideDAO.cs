using System;
using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class SlideDAO
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<Slide> SlideShow()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }

        public bool Delete(int id)
        {
            try
            {
                Slide user = db.Slides.Find(id);
                db.Slides.Remove(user);
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
