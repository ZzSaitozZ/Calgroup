using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

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
                var user = db.Slides.Find(id);
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
