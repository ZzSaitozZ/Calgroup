using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;

namespace Model.DAO
{
    public class CalibrationDAO
    {
        private ProductsdbContext db = new ProductsdbContext();

        public IEnumerable<Calibration> ListAllCalibration()
        {
            return db.Calibrations.Where(x => x.Status == true).ToList();
        }
    }
}
