//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityFramework_Örnek_Proje
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entity_ProjeEntities : DbContext
    {
        public Entity_ProjeEntities()
            : base("name=Entity_ProjeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_DERSLER> TBL_DERSLER { get; set; }
        public virtual DbSet<TBL_NOTLAR> TBL_NOTLAR { get; set; }
        public virtual DbSet<TBL_OGRENCILER> TBL_OGRENCILER { get; set; }
    }
}
