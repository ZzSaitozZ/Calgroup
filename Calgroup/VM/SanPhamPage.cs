using System.Collections.Generic;
using System.Linq;

namespace Calgroup.VM
{
    public class LinhVucCha
    {
        public string Name;
        public List<string[]> LinhVucCon;
    }

    public class SanPhamPageVM
    {
        public List<LinhVucCha> Menu;
        public string AliasCat;
        public int PageCount;
        public SanPhamPageVM(List<Calgroup.Models.Menu> a)
        {
            Menu = new List<LinhVucCha>
            {
                new LinhVucCha { LinhVucCon = new List<string[]> { new string[2] { a[0].Category, a[0].AliasCat } }, Name = a[0].Linhvuc }
            };
            for (int i = 1; i < a.Count(); i++)
            {
                if (a[i].Linhvuc == Menu.Last().Name)
                {
                    Menu.Last().LinhVucCon.Add(new string[] { a[i].Category, a[i].AliasCat });
                }
                else
                {
                    Menu.Add(new LinhVucCha { LinhVucCon = new List<string[]> { new string[2] { a[i].Category, a[i].AliasCat } }, Name = a[i].Linhvuc });
                }
            }
        }
    }

    public class Layoutmodel
    {
        public List<Staff> Nhanvien;
        public List<Question> FAQ;
        public List<DoiTac> Doitac;
        public List< ContactDetail> Lienlac;
    }

    public class getSanPhamVM
    {
        public string Products;
        public string CategoryVi;
    }
}