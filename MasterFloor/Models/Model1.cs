using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MasterFloor
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<EmployeeAccess> EmployeeAccess { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<MaterialType> MaterialType { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PartnerProducts> PartnerProducts { get; set; }
        public virtual DbSet<Partners> Partners { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TypePartners> TypePartners { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeAccess>()
                .Property(e => e.access_type)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.full_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.passport_data)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.bank_details)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.family_status)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .Property(e => e.health_status)
                .IsUnicode(false);

            modelBuilder.Entity<Employees>()
                .HasMany(e => e.EmployeeAccess)
                .WithOptional(e => e.Employees)
                .HasForeignKey(e => e.employee_id);

            modelBuilder.Entity<MaterialType>()
                .Property(e => e.type)
                .IsUnicode(false);

            modelBuilder.Entity<MaterialType>()
                .Property(e => e.percentag_marriage)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Orders>()
                .Property(e => e.total_cost)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Orders>()
                .Property(e => e.prepayment)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Orders>()
                .Property(e => e.delivery_status)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.name_partner)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.director)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.mail)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.legal_address)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .Property(e => e.inn)
                .IsUnicode(false);

            modelBuilder.Entity<Partners>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Partners)
                .HasForeignKey(e => e.partner_id);

            modelBuilder.Entity<Partners>()
                .HasMany(e => e.PartnerProducts)
                .WithOptional(e => e.Partners)
                .HasForeignKey(e => e.parnter_id);

            modelBuilder.Entity<Products>()
                .Property(e => e.name_product)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.min_cost_for_partner)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.name_type)
                .IsUnicode(false);

            modelBuilder.Entity<ProductType>()
                .Property(e => e.coefficient_product_type)
                .HasPrecision(10, 2);

            modelBuilder.Entity<ProductType>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.ProductType)
                .HasForeignKey(e => e.product_type);

            modelBuilder.Entity<TypePartners>()
                .Property(e => e.type_partner)
                .IsUnicode(false);

            modelBuilder.Entity<TypePartners>()
                .HasMany(e => e.Partners)
                .WithOptional(e => e.TypePartners)
                .HasForeignKey(e => e.name_type);
        }
    }
}
