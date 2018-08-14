using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Calgroup.Models;
using System.Web.Script.Serialization;



namespace Calgroup.VM
{
    public class LinhVucCha
    {
        public string Name;
        public List<string[]> LinhVucCon;
    }

    public class SanPhamPageVM
    {
        public SanPhamPageVM(List<Menu> a)
        {
            this.Menu = new List<LinhVucCha>();
            this.Menu.Add(new LinhVucCha { LinhVucCon = new List<string[]> { new string[2] { a[0].Category, a[0].AliasCat } }, Name = a[0].Linhvuc });
            for (int i = 1; i < a.Count(); i++)
            {
                if (a[i].Linhvuc == this.Menu.Last().Name)
                {
                    this.Menu.Last().LinhVucCon.Add(new string[] { a[i].Category, a[i].AliasCat });
                }
                else this.Menu.Add(new LinhVucCha { LinhVucCon = new List<string[]> { new string[2] { a[i].Category, a[i].AliasCat } }, Name = a[i].Linhvuc });
            }
        }
        public List<LinhVucCha> Menu;
        public string AliasCat;
    }
    public class getSanPhamVM
    {             
        public string Products;
        public string CategoryVi;
    }
}