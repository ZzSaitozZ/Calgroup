﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Calgroup
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Calgroup_v2DB : DbContext
    {
        public Calgroup_v2DB()
            : base("name=Calgroup_v2DB")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<LibraryCategory> LibraryCategories { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<LibraryView> LibraryViews { get; set; }
        public virtual DbSet<ShortProduct> ShortProducts { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
    
        public virtual ObjectResult<string> getFAQDetail(string alias)
        {
            var aliasParameter = alias != null ?
                new ObjectParameter("alias", alias) :
                new ObjectParameter("alias", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("getFAQDetail", aliasParameter);
        }
    
        public virtual ObjectResult<Nullable<long>> getNumberThuViens(string aliascat)
        {
            var aliascatParameter = aliascat != null ?
                new ObjectParameter("aliascat", aliascat) :
                new ObjectParameter("aliascat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<long>>("getNumberThuViens", aliascatParameter);
        }
    
        public virtual ObjectResult<getProductDetail_Result> getProductDetail(string alias)
        {
            var aliasParameter = alias != null ?
                new ObjectParameter("alias", alias) :
                new ObjectParameter("alias", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProductDetail_Result>("getProductDetail", aliasParameter);
        }
    
        public virtual ObjectResult<getProducts_Result> getProducts(string aliascat)
        {
            var aliascatParameter = aliascat != null ?
                new ObjectParameter("aliascat", aliascat) :
                new ObjectParameter("aliascat", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getProducts_Result>("getProducts", aliascatParameter);
        }
    
        public virtual ObjectResult<getThuViens_Result> getThuViens(string aliascat, Nullable<int> page)
        {
            var aliascatParameter = aliascat != null ?
                new ObjectParameter("aliascat", aliascat) :
                new ObjectParameter("aliascat", typeof(string));
    
            var pageParameter = page.HasValue ?
                new ObjectParameter("page", page) :
                new ObjectParameter("page", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getThuViens_Result>("getThuViens", aliascatParameter, pageParameter);
        }
    
        public virtual ObjectResult<searchProducts_Result> searchProducts(string alias)
        {
            var aliasParameter = alias != null ?
                new ObjectParameter("alias", alias) :
                new ObjectParameter("alias", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchProducts_Result>("searchProducts", aliasParameter);
        }
    }
}
