using System.Collections.Generic;
using System.Linq;

namespace Calgroup.Models.DAO
{
    public class CalibrationDAO
    {
        private Calgroup_v2DB db = new Calgroup_v2DB();

        public IEnumerable<Calibration> ListAllCalibration()
        {
            return db.Calibrations.Where(x => x.Status == true).ToList();
        }
    }
}
